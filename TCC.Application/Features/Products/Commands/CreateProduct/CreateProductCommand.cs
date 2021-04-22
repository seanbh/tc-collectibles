using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Products.Commands.CreateProduct
{
	public class CreateProductCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid CategoryId { get; set; }
		public decimal Price { get; set; }
	}
}
