using AutoMapper;
using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.BlazorWeb.Contracts;
using TCC.App.BlazorWeb.Services.Base;
using TCC.App.BlazorWeb.ViewModels;
using TCC.App.Services;

namespace TCC.App.BlazorWeb.Services
{
    public class CategoryDataService : BaseDataService, ICategoryDataService
    {
        public CategoryDataService(IClient client, IMapper mapper, ILocalStorageService localStorage): base(client, localStorage)
        {

        }

        public Task<List<CategoryViewModel>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryProductsViewModel>> GetAllCategoriesWithEvents()
        {
            throw new NotImplementedException();
        }
    }
}
