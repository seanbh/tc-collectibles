using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;
using TCC.Domain.Entities;

namespace TCC.Application.UnitTests.Mocks
{
	public class RepositoryMocks
	{
		public static Mock<ICategoryRepository> GetCategoryRepository()
		{
            var baseballCardGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var footballCardGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var basketballCardGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var hockeyCardGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

			var mockCategories = new List<Category>
			{
				new Category
				{
					CategoryId = baseballCardGuid,
					Name = "Baseball Cards"
				},
				new Category
				{
					CategoryId = footballCardGuid,
					Name = "Football Cards"
				},
				new Category
				{
					CategoryId = basketballCardGuid,
					Name = "Basketball Cards"
				},
				new Category
				{
					CategoryId = hockeyCardGuid,
					Name = "Hockey Cards"
				}
			};

			var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.ListAllAsync()).ReturnsAsync(mockCategories);

			mock.Setup(m => m.AddAsync(It.IsAny<Category>())).ReturnsAsync((Category c) =>
			{
				mockCategories.Add(c);
				return c;
			});

            return mock;
        }
	}
}
