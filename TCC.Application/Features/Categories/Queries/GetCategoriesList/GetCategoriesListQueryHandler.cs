using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;
using TCC.Domain.Entities;
using AutoMapper;

namespace TCC.Application.Features.Categories.Queries.GetCategoriesList
{
	public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
	{
		private readonly IMapper mapper;
		private readonly IAsyncRepository<Category> repository;

		public GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> repository)
		{
			this.mapper = mapper;
			this.repository = repository;
		}
		public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
		{
			var categories = (await repository.ListAllAsync()).OrderBy(c => c.Name);
			return mapper.Map<List<CategoryListVm>>(categories);
		}
	}
}
