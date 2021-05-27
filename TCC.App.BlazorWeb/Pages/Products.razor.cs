using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.BlazorWeb.Services.Catalog;

namespace TCC.App.BlazorWeb.Pages
{
    public partial class Products
    {
        public ICollection<ProductDto> ProductList { get; private set; }
        [Inject]
        private CatalogDataService catalogDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ProductList = await catalogDataService.GetProductsAsync(null);
        }
    }
}
