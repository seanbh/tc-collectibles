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
using Microsoft.Extensions.Logging;

namespace TCC.Application.Features.Categories.Queries.GetCategoriesList
{
	public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
	{
		private readonly IMapper mapper;
		private readonly IAsyncRepository<Category> repository;
        private readonly ILogger<GetCategoriesListQueryHandler> logger;

        public GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> repository)
		{
			this.mapper = mapper;
			this.repository = repository;
			//, ILogger<GetCategoriesListQueryHandler> logger this.logger = logger;
		}
		public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
		{
			//logger.LogInformation("Logger works");
			var categories = (await repository.ListAllAsync()).OrderBy(c => c.Name);
			return mapper.Map<List<CategoryListVm>>(categories);
		}
	}
}
