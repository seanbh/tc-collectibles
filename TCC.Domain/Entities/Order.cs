using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Domain.Entities
{
	public class Order : AuditableEntity
	{
		public Guid OrderId { get; set; }
		public Guid UserId { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal OrderTotal { get; set; }
		public bool OrderPaid { get; set; }
		public DateTime OrderPlaced { get; set; }
	}
}
