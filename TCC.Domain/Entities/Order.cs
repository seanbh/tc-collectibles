using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Domain.Entities
{
	public class Order : AuditableEntity
	{
		public Guid OrderId { get; set; }
		public Guid UserId { get; set; }
		public decimal OrderTotal { get; set; }
		public bool OrderPaid { get; set; }
		public DateTime OrderPlaced { get; set; }
	}
}
