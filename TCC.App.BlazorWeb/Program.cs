using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using TCC.App.BlazorWeb.Auth;
using TCC.App.BlazorWeb.Contracts;
using TCC.App.BlazorWeb.Services;
using TCC.App.BlazorWeb.Services.Base;

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

            builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            await builder.Build().RunAsync();
        }
    }
}
