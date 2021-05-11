using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.BlazorWeb.Services.Base;
using TCC.App.BlazorWeb.ViewModels;

namespace TCC.App.BlazorWeb.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryProductsViewModel>> GetAllCategoriesWithEvents();
        Task<ApiResponse<CreateCategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
