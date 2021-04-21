using System;

namespace TCC.Application.Features.Products
{
	public class ProductDetailVm
	{
		public Guid ProductId { get; set; }
		public CategoryDto CategoryDto { get; set; }
	}
}