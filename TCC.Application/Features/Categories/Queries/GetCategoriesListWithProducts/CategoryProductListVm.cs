using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Categories.Queries.GetCategoriesListWithProducts
{
	public class CategoryProductListVm
	{
		public Guid CategoryId { get; set; }
		public string Name { get; set; }
		public List<CategoryProductDto> Products { get; set; }
	}
}
