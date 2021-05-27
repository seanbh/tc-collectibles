using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Catalog.Rest.Entities;

namespace TCC.Services.Catalog.Rest.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(Guid categoryId);
        Task<Product> GetProductById(Guid productId);
    }
}
