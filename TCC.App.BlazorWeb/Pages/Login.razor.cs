using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.BlazorWeb.Contracts;
using TCC.App.BlazorWeb.ViewModels;

namespace TCC.App.BlazorWeb.Pages
{
    public partial class Login
    {
        public LoginViewModel LoginViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Login()
        {

        }

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginViewModel();
        }

        protected async void HandleValidSubmit()
        {
            if(await AuthenticationService.Authenticate(LoginViewModel.Email, LoginViewModel.Password))
            {
                NavigationManager.NavigateTo("home");
            }
            Message = "Username/password combination unknown";
        }
    }
}
