using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TCC.App.BlazorWeb.Auth;
using TCC.App.BlazorWeb.Contracts;
using TCC.App.BlazorWeb.Services.Base;

namespace TCC.App.BlazorWeb.Services
{
    public class AuthenticationService : BaseDataService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthenticationService(IClient client, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
        {
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthenticationRequest authenticationRequest = new AuthenticationRequest() { Email = email, Password = password };
                var authenticationResponse = await client.AuthenticateAsync(authenticationRequest);

                if (authenticationResponse.Token != string.Empty)
                {
                    await localStorage.SetItemAsync("token", authenticationResponse.Token);
                    ((CustomAuthenticationStateProvider)authenticationStateProvider).SetUserAuthenticated(email);
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authenticationResponse.Token);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
            var response = await client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider)authenticationStateProvider).SetUserLoggedOut();
            client.HttpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
