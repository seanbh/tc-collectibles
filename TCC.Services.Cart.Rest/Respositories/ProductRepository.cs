using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Cart.Rest.DbContexts;
using TCC.Services.Cart.Rest.Entities;

namespace TCC.Services.Cart.Rest.Respositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CartDbContext db;

        public ProductRepository(CartDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> ProductExists(Guid ProductId)
        {
            return await db.Products.AnyAsync(e => e.ProductId == ProductId);
        }

        public void AddProduct(Product theProduct)
        {
            db.Products.Add(theProduct);

        }

        public async Task<bool> SaveChanges()
        {
            return (await db.SaveChangesAsync() > 0);
        }
    }
}
