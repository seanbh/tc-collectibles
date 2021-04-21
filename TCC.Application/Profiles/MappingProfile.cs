using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Features.Products;
using TCC.Domain.Entities;

namespace TCC.Application.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, ProductListVm>().ReverseMap();
			CreateMap<Product, ProductDetailVm>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
		}
	}
}
