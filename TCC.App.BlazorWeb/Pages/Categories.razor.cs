using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.BlazorWeb.Contracts;
using TCC.App.BlazorWeb.ViewModels;

namespace TCC.App.BlazorWeb.Pages
{
    public partial class Categories
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        public ICollection<CategoryViewModel> CategoryList { get; set; }

        protected async override Task OnInitializedAsync()
        {

            CategoryList = await CategoryDataService.GetAllCategories();
        }
    }
}
