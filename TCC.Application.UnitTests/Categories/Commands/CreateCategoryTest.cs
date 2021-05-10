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
using TCC.Application.Features.Categories.Commands;
using TCC.Application.Profiles;
using TCC.Application.UnitTests.Mocks;
using Xunit;

namespace TCC.Application.UnitTests.Categories.Commands
{
	public class CreateCategoryTest
	{
		private readonly Mock<ICategoryRepository> mockCategoryRepository;
		private readonly IMapper mapper;

		public CreateCategoryTest()
		{
			mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
			var configProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});
			mapper = configProvider.CreateMapper();
		}

		[Fact]
		public async Task HandleCreateCategoryTest()
		{
			var handler = new CreateCategoryCommandHandler(mapper, mockCategoryRepository.Object);
			await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);
			var categories = await mockCategoryRepository.Object.ListAllAsync();
			categories.Count.ShouldBe(5);
		}
	}
}
