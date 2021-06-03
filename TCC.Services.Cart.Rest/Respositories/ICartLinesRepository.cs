using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Cart.Rest.Entities;

namespace TCC.Services.Cart.Rest.Respositories
{
    public interface ICartLinesRepository
    {
        Task<IEnumerable<CartLine>> GetCartLines(Guid CartId);

        Task<CartLine> GetCartLineById(Guid CartLineId);

        Task<CartLine> AddOrUpdateCartLine(Guid CartId, CartLine CartLine);

        void UpdateCartLine(CartLine CartLine);

        void RemoveCartLine(CartLine CartLine);

        Task<bool> SaveChanges();
    }
}
