using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.App.MVC.Models
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext db;

		public ProductRepository(AppDbContext db)
		{
			this.db = db;
		}

		public Product GetById(int id)
		{
			var product = db.Products.Find(id);

			return product;
		}

		public List<Product> GetProducts()
		{
			return db.Products.ToList();
		}
	}
}
