using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Api;
using TCC.API.IntegrationTests.Base;
using TCC.Application.Features.Categories.Queries.GetCategoriesList;
using Xunit;

namespace TCC.API.IntegrationTests.Controllers
{
	public class CategoryControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
	{
		private readonly CustomWebApplicationFactory<Startup> factory;

		public CategoryControllerTest(CustomWebApplicationFactory<Startup> factory)
		{
			this.factory = factory;
		}

		//[Fact]
		//public async Task AllCategoriesTest()
		//{
		//	var client = factory.GetAnonymousClient();
		//	var response = await client.GetAsync("/api/category/all");
		//	response.EnsureSuccessStatusCode();
		//	var responseString = await response.Content.ReadAsStringAsync();
		//	var result = JsonConvert.DeserializeObject<List<CategoryListVm>>(responseString);
		//	Assert.IsType<List<CategoryListVm>>(result);
		//	Assert.NotEmpty(result);
		//}
	}
}
