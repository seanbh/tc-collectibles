using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Features.Categories.Queries.GetCategoriesList;
using TCC.Application.Features.Categories.Queries.GetCategoriesListWithProducts;
using TCC.Application.Features.Products.Queries.GetProductDetail;
using TCC.Application.Features.Products.Queries.GetProductsList;
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
			CreateMap<Category, CategoryListVm>().ReverseMap();
			CreateMap<Category, CategoryProductListVm>().ReverseMap();
		}
	}
}
