using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.App.MVC.Models
{
	public interface IProductRepository
	{
		List<Product> GetProducts();
	}
}
