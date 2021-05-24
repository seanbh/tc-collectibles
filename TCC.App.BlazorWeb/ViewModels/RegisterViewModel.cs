using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.App.BlazorWeb.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; } = "Sean";
        public string LastName { get; set; } = "Haddock";
        public string Email { get; set; } = "seanhaddock@live.com";
        public string UserName { get; set; } = "seanhaddock";
        public string Password { get; set; } = "Password2021!";
    }
}
