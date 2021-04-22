using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Categories.Queries.GetCategoriesListWithProducts
{
	public class GetCategoriesListWithProductsQuery : IRequest<List<CategoryProductListVm>>
	{
	}
}
