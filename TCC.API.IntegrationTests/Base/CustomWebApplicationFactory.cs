﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using TCC.Persistence;

namespace TCC.API.IntegrationTests.Base
{
	public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{
				services.AddDbContext<TccDbContext>(options =>
				{
					options.UseInMemoryDatabase("TccDbContextTest");
				});

				var sp = services.BuildServiceProvider();

				using (var scope = sp.CreateScope())
				{
					var scopedServices = scope.ServiceProvider;
					var context = scopedServices.GetRequiredService<TccDbContext>();
					var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
					context.Database.EnsureCreated();

					try
					{
						Utility.InitializeDbForTests(context);
					}
					catch (Exception ex)
					{
						logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
					}
				}
			});
		}

		public HttpClient GetAnonymousClient()
		{
			return CreateClient();
		}

	}
}
