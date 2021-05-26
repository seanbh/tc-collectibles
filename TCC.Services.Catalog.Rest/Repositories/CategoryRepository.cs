using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Catalog.Rest.DbContexts;
using TCC.Services.Catalog.Rest.Entities;

namespace TCC.Services.Catalog.Rest.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDbContext dbContext;

        public CategoryRepository(CatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {            
            var categories = await dbContext.Categories.ToListAsync();
            return categories;
        }

        public Task<Category> GetCategoryById(string categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
