using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Catalog.Rest.DbContexts;
using TCC.Services.Catalog.Rest.Entities;

namespace TCC.Services.Catalog.Rest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext db;

        public ProductRepository(CatalogDbContext db)
        {
            this.db = db;
        }
        public async Task<Product> GetProductById(Guid productId)
        {
            var product = await db.Products
                .Include(p => p.Category)
                .Where(p => p.ProductId == productId).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts(Guid categoryId)
        {
            var products = await db.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId || categoryId == Guid.Empty)
                .ToListAsync();
            return products;
        }
    }
}
