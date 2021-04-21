using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.Domain.Entities
{
	public class Collectible
	{
		public Guid CollectibleId { get; set; }
		public string Name { get; set; }
		public Guid CategoryId { get; set; }
		public decimal Price { get; set; }
	}
}
