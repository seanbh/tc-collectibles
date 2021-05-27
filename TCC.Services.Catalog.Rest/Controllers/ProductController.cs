using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Catalog.Rest.Models;
using TCC.Services.Catalog.Rest.Repositories;

namespace TCC.Services.Catalog.Rest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDto[]>> Get([FromQuery] Guid categoryId)
        {
            var products = await productRepository.GetProducts(categoryId);
            var dtos = mapper.Map<ProductDto[]>(products);
            return Ok(dtos);
        }
		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var product = await productRepository.GetProductById(id);
            var dto = mapper.Map<ProductDto>(product);
            return Ok(dto);
        }

	}
}
