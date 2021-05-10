using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Contracts;
using TCC.Domain.Entities;
using Xunit;

namespace TCC.Persistence.IntegrationTests
{
	public class TccDbContextTest
	{
		private readonly string loggedInUserId;
		private readonly Mock<ILoggedInUserService> loggedInUserServiceMock;
		private readonly TccDbContext db;

		public TccDbContextTest()
		{
			var dbContextOptions = new DbContextOptionsBuilder<TccDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
			loggedInUserId = "abcdefg";
			loggedInUserServiceMock = new Mock<ILoggedInUserService>();
			loggedInUserServiceMock.Setup(m => m.UserId).Returns(loggedInUserId);

			db = new TccDbContext(dbContextOptions, loggedInUserServiceMock.Object);
		}

		[Fact]
		public async Task SaveSetCreatedByTest()
		{
			var category = new Category() { Name = "Test" };
			db.Categories.Add(category);
			await db.SaveChangesAsync();
			category.CreatedBy.ShouldBe(loggedInUserId);
		}
	}
}
