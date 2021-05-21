using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.BlazorWeb.Contracts;
using TCC.App.BlazorWeb.ViewModels;

namespace TCC.App.BlazorWeb.Pages
{
    public partial class Register
    {
        public RegisterViewModel RegisterViewModel { get; set; } //= new RegisterViewModel();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Register()
        {

        }
        protected override void OnInitialized()
        {
            RegisterViewModel = new RegisterViewModel();
        }

        protected async void HandleValidSubmit()
        {
            var result = await AuthenticationService.Register(RegisterViewModel.FirstName, RegisterViewModel.LastName, RegisterViewModel.UserName, RegisterViewModel.Email, RegisterViewModel.Password);

            if (result)
            {
                NavigationManager.NavigateTo("home");
            }
            Message = "Something went wrong, please try again.";
        }
    }
}
