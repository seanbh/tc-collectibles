using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Cart.Rest.Entities;

namespace TCC.Services.Cart.Rest.Respositories
{
    public interface IProductRepository
    {
        void AddProduct(Product theProduct);
        Task<bool> ProductExists(Guid ProductId);
        Task<bool> SaveChanges();
    }
}
