using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TCC.App.BlazorWeb.Services.Catalog
{
    public class CatalogDataService
    {
        private readonly ICatalogServiceClient catalogServiceClient;

        public CatalogDataService(ICatalogServiceClient catalogServiceClient)
        {
            this.catalogServiceClient = catalogServiceClient;
        }

        public async Task<ICollection<ProductDto>> GetProductsAsync(Guid? categoryId)
        {
            return await catalogServiceClient.ProductAllAsync(categoryId);
        }
    }
}
