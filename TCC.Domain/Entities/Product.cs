using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Domain.Entities
{
	public class Product : AuditableEntity
	{
		public Guid ProductId { get; set; }
		public string Name { get; set; }
		public DateTime Year { get; set; }
		public string ImageUrl { get; set; }
		public Guid CategoryId { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }
	}
}
