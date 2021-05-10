
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Contracts.Infrastructure;
using TCC.Application.Features.Categories.Queries.GetCategoriesExport;

namespace TCC.Infrastructure.FileExport
{
	public class CsvExporter : ICsvExporter
	{
		public byte[] ExportCategoriesToCsv(List<CategoryExportDto> categoryExportDtos)
		{
			using var memoryStream = new MemoryStream();
			using (var streamWriter = new StreamWriter(memoryStream))
			{
				using var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture);
				csvWriter.WriteRecords(categoryExportDtos);
			}

			return memoryStream.ToArray();
		}
	}
}
