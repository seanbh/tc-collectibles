using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Features.Categories.Queries.GetCategoriesExport;

namespace TCC.Application.Contracts.Infrastructure
{
	public interface ICsvExporter
	{
		byte[] ExportCategoriesToCsv(List<CategoryExportDto> categoryExportDtos);
	}
}
