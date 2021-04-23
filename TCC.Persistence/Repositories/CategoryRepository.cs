using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;
using TCC.Domain.Entities;

namespace TCC.Persistence.Repositories
{
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(TccDbContext dbContext): base(dbContext)
		{
		}

		public async Task<List<Category>> GetCategoriesWithProducts()
		{
			var categories = await dbContext.Categories.Include(c => c.Products).ToListAsync();
			return categories;
		}
	}
}
