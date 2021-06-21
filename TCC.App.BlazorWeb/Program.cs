using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Azure.Storage;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using TCC.App.BlazorWeb.Auth;
using TCC.App.BlazorWeb.Contracts;
using TCC.App.BlazorWeb.Services;
using TCC.App.BlazorWeb.Services.Base;
using TCC.App.BlazorWeb.Services.Catalog;
using TCC.Messages;

namespace TCC.App.BlazorWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44343/") });
            builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:44343/"));
            builder.Services.AddHttpClient<ICatalogServiceClient, CatalogServiceClient>((provider, client) =>
            {
                client.BaseAddress = new Uri("https://localhost:44396/");
            });

            builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
            builder.Services.AddScoped<CatalogDataService, CatalogDataService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=paymentrequests;AccountKey=tyjsGm3LCkKqLD+jrqB2Lhan8Zq93GSxLwfETH0FQBi7GnQmtbgDUWNmSgmVNOPehIpfsdTlumQ+O62KAr/rAQ==;EndpointSuffix=core.windows.net");

            builder.Services.AddRebus(c => c
                .Transport(t => t.UseAzureStorageQueuesAsOneWayClient(storageAccount))
                .Routing(r => r.TypeBased().Map<PaymentRequestMessage>(
                    "paymentrequests"))
            );

            await builder.Build().RunAsync();
        }
    }
}
