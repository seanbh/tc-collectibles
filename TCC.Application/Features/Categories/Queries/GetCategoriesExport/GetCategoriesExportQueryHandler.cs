using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCC.Application.Contracts.Infrastructure;
using TCC.Application.Contracts.Persistence;

namespace TCC.Application.Features.Categories.Queries.GetCategoriesExport
{
	public class GetCategoriesExportQueryHandler : IRequestHandler<GetCategoriesExportQuery, CategoryExportFileVm>
	{
		private readonly IMapper mapper;
		private readonly ICategoryRepository repository;
		private readonly ICsvExporter csvExporter;

		public GetCategoriesExportQueryHandler(IMapper mapper, ICategoryRepository repository, ICsvExporter csvExporter)
		{
			this.mapper = mapper;
			this.repository = repository;
			this.csvExporter = csvExporter;
		}

		public async Task<CategoryExportFileVm> Handle(GetCategoriesExportQuery request, CancellationToken cancellationToken)
		{
			var categortExportDtos = mapper.Map<List<CategoryExportDto>>(await repository.ListAllAsync());

			var data = csvExporter.ExportCategoriesToCsv(categortExportDtos);

			return new CategoryExportFileVm() { FileName = $"{Guid.NewGuid()}.csv", ContentType = "text/csv", Data = data };
		}
	}
}
