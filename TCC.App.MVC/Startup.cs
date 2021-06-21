using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.MVC.Models;
using TCC.Messages;

namespace TCC.App.MVC
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddScoped<IProductRepository, MockProductRepository>();

			//var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=paymentrequests;AccountKey=tyjsGm3LCkKqLD+jrqB2Lhan8Zq93GSxLwfETH0FQBi7GnQmtbgDUWNmSgmVNOPehIpfsdTlumQ+O62KAr/rAQ==;EndpointSuffix=core.windows.net");

			//services.AddRebus(c => c
			//	.Transport(t => t.UseAzureStorageQueuesAsOneWayClient(storageAccount))
			//	.Routing(r => r.TypeBased().Map<PaymentRequestMessage>(
			//		"paymentrequests"))
			//);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
