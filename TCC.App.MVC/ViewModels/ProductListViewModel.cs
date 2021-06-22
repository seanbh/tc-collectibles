using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.MVC.Models;

namespace TCC.App.MVC.ViewModels
{
	public class ProductListViewModel
	{
		public IEnumerable<Product> Products { get; set; }
		public string CurrentCategory { get; set; }
	}
}
