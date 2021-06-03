using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Cart.Rest.Entities;

namespace TCC.Services.Cart.Rest.Services
{
    public interface ICatalogService
    {
        Task<Product> GetProduct(Guid id);
    }
}
