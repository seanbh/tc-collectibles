using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Products
{
	public class GetProductDetailQuery : IRequest<ProductDetailVm>
	{
		public Guid Id { get; set; }
		public GetProductDetailQuery(Guid id)
		{
			Id = id;
		}
	}
}
