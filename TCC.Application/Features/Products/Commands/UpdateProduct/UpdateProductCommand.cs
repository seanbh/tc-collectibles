using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Domain.Entities;

namespace TCC.Application.Features.Products.Commands.UpdateProduct
{
	public class UpdateProductCommand: IRequest
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid CategoryId { get; set; }
		public decimal Price { get; set; }
	}
}
