using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.Domain.Entities
{
	public class Order
	{
		public Guid OrderId { get; set; }
		public Guid UserId { get; set; }
		public decimal OrderTotal { get; set; }
	}
}
