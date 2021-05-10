using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Categories.Queries.GetCategoriesExport
{
	public class GetCategoriesExportQuery : IRequest<CategoryExportFileVm>
	{
	}
}
