using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.App.MVC.Models;
using TCC.App.MVC.ViewModels;

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
			var vm = new ProductListViewModel();
			vm.CurrentCategory = "Cards";
			vm.Products = productRepository.GetProducts();
			return View(vm);
		}

		public IActionResult Details(int id)
		{
			var product = productRepository.GetById(id);
			return product != null ? View(product) : NotFound();
		}
	}
}
