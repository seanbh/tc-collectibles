﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TCC.App.BlazorWeb.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
