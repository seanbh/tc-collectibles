using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Products.Queries.GetProductDetail
{
	public class GetProductDetailQuery : IRequest<ProductDetailVm>
	{
		public Guid ProductId { get; set; }
		public GetProductDetailQuery(Guid id)
		{
			ProductId = id;
		}
	}
}
