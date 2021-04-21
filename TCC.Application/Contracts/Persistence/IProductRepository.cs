using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;
using TCC.Domain.Entities;

namespace TCC.Application.Contracts.Persistence
{
	public interface IProductRepository : IAsyncRepository<Product>
	{
	}
}
