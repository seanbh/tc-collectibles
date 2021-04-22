﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;

namespace TC.Persistence.Repositories
{
	public class BaseRepository<T> : IAsyncRepository<T> where T: class
	{
		protected readonly TccDbContext dbContext;

		public BaseRepository(TccDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<T> AddAsync(T entity)
		{
			await dbContext.Set<T>().AddAsync(entity);
			await dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task DeleteAsync(T entity)
		{
			dbContext.Set<T>().Remove(entity);
			await dbContext.SaveChangesAsync();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await dbContext.Set<T>().FindAsync(id);
		}

		//public Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
		//{
		//	return await dbContext.Set<T>().Skip(page * size).ToListAsync();
		//}

		public async Task<IReadOnlyList<T>> ListAllAsync()
		{
			return await dbContext.Set<T>().ToListAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			dbContext.Entry(entity).State = EntityState.Modified;
			await dbContext.SaveChangesAsync();
		}
	}
}
