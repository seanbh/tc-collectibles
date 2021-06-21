using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.MVC.Models;

namespace TCC.App.MVC.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository productRepository;

		public ProductController(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		public ViewResult List()
		{
			return View(productRepository.GetProducts());
		}
	}
}
