using System;
using System.Collections.Generic;
using AutoMapper;
using TCC.App.BlazorWeb.Services;
using TCC.App.BlazorWeb.Services.Base;
using TCC.App.BlazorWeb.ViewModels;

namespace TCC.App.BlazorWeb.Profiles
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //Vms are coming in from the API, ViewModel are the local entities in Blazor
            

            CreateMap<CategoryProductDto, ProductNestedViewModel>().ReverseMap();

            //CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryListVm, CategoryViewModel>().ReverseMap();
           // CreateMap<CategoryEventListVm, CategoryProductsViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryDto, CategoryViewModel>().ReverseMap();

        }
    }
}
