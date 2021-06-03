using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Cart.Rest.DbContexts;

namespace TCC.Services.Cart.Rest.Respositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDbContext db;

        public CartRepository(CartDbContext shoppingCartDbContext)
        {
            db = shoppingCartDbContext;
        }

        public async Task<Entities.Cart> GetCartById(Guid CartId)
        {
            return await db.Carts.Include(sb => sb.CartLines)
                .Where(b => b.CartId == CartId).FirstOrDefaultAsync();
        }

        public async Task<bool> CartExists(Guid CartId)
        {
            return await db.Carts
                .AnyAsync(b => b.CartId == CartId);
        }

        public void AddCart(Entities.Cart Cart)
        {
            db.Carts.Add(Cart);
        }

        public async Task<bool> SaveChanges()
        {
            return (await db.SaveChangesAsync() > 0);
        }
    }
}
