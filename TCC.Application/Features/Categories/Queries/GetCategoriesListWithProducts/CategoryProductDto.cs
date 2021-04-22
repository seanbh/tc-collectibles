using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Categories.Queries.GetCategoriesListWithProducts
{
	public class CategoryProductDto
	{
		public Guid ProductId { get; set; }
		public string Name { get; set; }
		public Guid CategoryId { get; set; }

	}
}
