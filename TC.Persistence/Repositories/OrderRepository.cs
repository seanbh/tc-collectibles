using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Domain.Entities;

namespace TC.Persistence.Repositories
{
	public class OrderRepository : BaseRepository<Order>
	{
		public OrderRepository(TccDbContext dbContext) : base(dbContext)
		{
		}
	}
}
