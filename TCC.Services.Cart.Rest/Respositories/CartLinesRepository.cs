using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Cart.Rest.DbContexts;
using TCC.Services.Cart.Rest.Entities;

namespace TCC.Services.Cart.Rest.Respositories
{
    public class CartLinesRepository : ICartLinesRepository
    {
        private readonly CartDbContext db;

        public CartLinesRepository(CartDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CartLine>> GetCartLines(Guid CartId)
        {
            return await db.CartLines.Include(bl => bl.Product)
                .Where(b => b.CartId == CartId).ToListAsync();
        }

        public async Task<CartLine> GetCartLineById(Guid CartLineId)
        {
            return await db.CartLines.Include(bl => bl.Product)
                .Where(b => b.CartLineId == CartLineId).FirstOrDefaultAsync();
        }

        public async Task<CartLine> AddOrUpdateCartLine(Guid CartId, CartLine CartLine)
        {
            var existingLine = await db.CartLines.Include(bl => bl.Product)
                .Where(b => b.CartId == CartId && b.ProductId == CartLine.ProductId).FirstOrDefaultAsync();
            if (existingLine == null)
            {
                CartLine.CartId = CartId;
                db.CartLines.Add(CartLine);
                return CartLine;
            }
            existingLine.Qty += CartLine.Qty;
            return existingLine;
        }

        public void UpdateCartLine(CartLine CartLine)
        {
            // empty on purpose
        }

        public void RemoveCartLine(CartLine CartLine)
        {
            db.CartLines.Remove(CartLine);
        }

        public async Task<bool> SaveChanges()
        {
            return (await db.SaveChangesAsync() > 0);
        }
    }
}
