using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TCC.Services.Cart.Rest.Entities;
using TCC.Services.Cart.Rest.Extensions;

namespace TCC.Services.Cart.Rest.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient httpClient;

        public CatalogService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Product> GetProduct(Guid id)
        {
            var response = await httpClient.GetAsync($"/api/products/{id}");
            return await response.ReadContentAs<Product>();
        }
    }
}
