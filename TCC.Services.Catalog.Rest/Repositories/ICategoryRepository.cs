using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Catalog.Rest.Entities;

namespace TCC.Services.Catalog.Rest.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string categoryId);
    }
}
