using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TCC.App.BlazorWeb.Services.Base
{
    public class BaseDataService
    {
        protected readonly IClient client;
        protected readonly ILocalStorageService localStorage;

        public BaseDataService(IClient client, ILocalStorageService localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }

        protected ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new ApiResponse<Guid>() { Message = "Validation errors have occured.", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new ApiResponse<Guid>() { Message = "The requested item could not be found.", Success = false };
            }
            else
            {
                return new ApiResponse<Guid>() { Message = "Something went wrong, please try again.", Success = false };
            }
        }

        protected async Task AddBearerToken()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzZWFuaGFkZG9jayIsImp0aSI6ImJjZDA5MzNmLTEwYmEtNDMzOC04MTc0LTU4MGJlY2JmNzcwZSIsImVtYWlsIjoic2VhbmhhZGRvY2tAbGl2ZS5jb20iLCJ1aWQiOiJmNTNlNDBkMi1jN2I3LTQyMTAtYmQ1Yi01ODI1NDFmMjE5ZDEiLCJleHAiOjE2MjE5NzczNzgsImlzcyI6IlRjY0lkZW50aXR5IiwiYXVkIjoiVGNjSWRlbnRpdHlVc2VyIn0.Ams1izDOXlH7OuUSjFaW834SpEB6gaSjdotg38bdJKo";
            client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //if (await localStorage.ContainKeyAsync("token"))
            //    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await localStorage.GetItemAsStringAsync("token"));
        }
    }
}
