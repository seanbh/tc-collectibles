using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Products.Queries.GetProductsList
{
	public class GetProductsListQuery : IRequest<List<ProductListVm>>
	{
	}
}
