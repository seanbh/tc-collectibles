using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Domain.Entities
{
	public class Product : AuditableEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid CategoryId { get; set; }
		public decimal Price { get; set; }
	}
}
