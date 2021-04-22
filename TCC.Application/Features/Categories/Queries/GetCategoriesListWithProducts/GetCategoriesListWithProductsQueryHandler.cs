using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;

namespace TCC.Application.Features.Categories.Queries.GetCategoriesListWithProducts
{
	public class GetCategoriesListWithProductsQueryHandler : IRequestHandler<GetCategoriesListWithProductsQuery, List<CategoryProductListVm>>
	{
		private readonly Mapper mapper;
		private readonly ICategoryRepository repository;

		public GetCategoriesListWithProductsQueryHandler(Mapper mapper, ICategoryRepository repository)
		{
			this.mapper = mapper;
			this.repository = repository;
		}
		public async Task<List<CategoryProductListVm>> Handle(GetCategoriesListWithProductsQuery request, CancellationToken cancellationToken)
		{
			var categories = await this.repository.GetCategoriesWithProducts();
			return mapper.Map<List<CategoryProductListVm>>(categories);
		}
	}
}
