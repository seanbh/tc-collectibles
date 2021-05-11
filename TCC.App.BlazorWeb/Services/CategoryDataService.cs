using AutoMapper;
using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.BlazorWeb.Contracts;
using TCC.App.BlazorWeb.Services.Base;
using TCC.App.BlazorWeb.ViewModels;

namespace TCC.App.BlazorWeb.Services
{
    public class CategoryDataService : BaseDataService, ICategoryDataService
    {
        private readonly IMapper mapper;

        public CategoryDataService(IClient client, IMapper mapper, ILocalStorageService localStorage): base(client, localStorage)
        {
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CreateCategoryDto>> CreateCategory(CategoryViewModel categoryViewModel)
        {
            try
            {
                ApiResponse<CreateCategoryDto> apiResponse = new ApiResponse<CreateCategoryDto>();
                CreateCategoryCommand createCategoryCommand = mapper.Map<CreateCategoryCommand>(categoryViewModel);
                var response = await client.AddCategoryAsync(createCategoryCommand);
                if(response.Success)
                {
                    apiResponse.Data = response.Category;
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach (var error in response.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CreateCategoryDto>(ex);
            }
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            await AddBearerToken();
            var allCategories = await client.GetAllCategoriesAsync();
            var mappedCategories = mapper.Map<ICollection<CategoryViewModel>>(allCategories);
            return mappedCategories.ToList();
        }

        public async Task<List<CategoryProductsViewModel>> GetAllCategoriesWithEvents()
        {
            await AddBearerToken();
            var categoriesWithProducts = await client.GetCategoriesWithProductsAsync();
            var mappedCategories = mapper.Map<ICollection<CategoryProductsViewModel>>(categoriesWithProducts);
            return mappedCategories.ToList();
        }
    }
}
