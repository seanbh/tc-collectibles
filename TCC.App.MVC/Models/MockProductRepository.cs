using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.App.MVC.Models
{
	public class MockProductRepository : IProductRepository
	{
		public Product GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetProducts()
		{
            return new List<Product>() {
                new Product
            {
                ProductId = 1,
                Name = "Ryne Sandberg",              
                CategoryId = 1
            },

             new Product
            {
                ProductId = 2,
                Name = "Drew Brees",
                CategoryId = 2
            },           
        };

		}
	}
}
