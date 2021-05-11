using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.Services;

namespace TCC.App.BlazorWeb.Services.Base
{
    public class BaseDataService
    {
        private readonly IClient client;
        private readonly ILocalStorageService localStorage;

        public BaseDataService(IClient client, ILocalStorageService localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }
    }
}
