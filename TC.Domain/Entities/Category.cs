using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.Domain.Entities
{
	public class Category
	{
		public Guid CategoryId { get; set; }
		public string Name { get; set; }
		public ICollection<Collectible> Collectibles { get; set; }
	}
}
