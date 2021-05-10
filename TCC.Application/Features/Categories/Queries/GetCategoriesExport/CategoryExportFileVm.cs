using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Categories.Queries.GetCategoriesExport
{
	public class CategoryExportFileVm
	{
		public string FileName { get; set; }
		public string  ContentType { get; set; }
		public byte[] Data { get; set; }
	}
}
