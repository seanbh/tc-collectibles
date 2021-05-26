using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Services.Catalog.Rest.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Models.ProductDto>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
        }
    }
}
