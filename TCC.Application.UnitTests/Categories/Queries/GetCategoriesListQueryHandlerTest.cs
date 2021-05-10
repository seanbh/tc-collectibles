using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;
using TCC.Application.Features.Categories.Queries.GetCategoriesList;
using TCC.Application.Profiles;
using TCC.Application.UnitTests.Mocks;
using Xunit;

namespace TCC.Application.UnitTests.Categories.Queries
{
	public class GetCategoriesListQueryHandlerTest
	{
		private readonly Mock<ICategoryRepository> mockCategoryRepository;
		private readonly IMapper mapper;

		public GetCategoriesListQueryHandlerTest()
		{
			mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
			var configProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});
			mapper = configProvider.CreateMapper();
		}

		[Fact]
		public async Task GetCategoriesListTest()
		{
			var handler = new GetCategoriesListQueryHandler(mapper, mockCategoryRepository.Object);

			var categories= await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

			categories.ShouldBeOfType<List<CategoryListVm>>();
			categories.Count.ShouldBe(4);
		}
	}
}
