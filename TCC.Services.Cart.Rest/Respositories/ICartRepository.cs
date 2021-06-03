using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Services.Cart.Rest.Respositories
{
    public interface ICartRepository
    {
        Task<bool> CartExists(Guid CartId);

        Task<Entities.Cart> GetCartById(Guid CartId);

        void AddCart(Entities.Cart Cart);

        Task<bool> SaveChanges();
    }
}
