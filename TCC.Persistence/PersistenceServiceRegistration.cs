using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;
using TCC.Persistence.Repositories;

namespace TCC.Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<TccDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TccConnectionString")));

			services.AddScoped (typeof(IAsyncRepository<>), typeof(BaseRepository<>));
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();

			return services;
		}
	}
}
