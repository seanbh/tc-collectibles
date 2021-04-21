using System;

namespace TCC.Application.Features.Products.Queries.GetProductDetail
{
	public class ProductDetailVm
	{
		public Guid ProductId { get; set; }
		public CategoryDto CategoryDto { get; set; }
	}
}