using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.App.MVC.Models
{
	public class Product
	{
		public Guid ProductId { get; set; }
		public string Name { get; set; }
		public DateTime Year { get; set; }
		public string ImageUrl { get; set; }
		public Guid CategoryId { get; set; }
		public decimal Price { get; set; }
	}
}
