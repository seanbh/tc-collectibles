using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;
using TCC.Domain.Entities;

namespace TCC.Persistence.Repositories
{
	public class OrderRepository : BaseRepository<Order>, IOrderRepository
	{
		public OrderRepository(TccDbContext dbContext) : base(dbContext)
		{
		}
	}
}
