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
	public class CategoryController : ControllerBase
	{
        private readonly ICategoryRepository repo;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

		[HttpGet]
		[Route("all")]
		public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            var categories = await repo.GetAllCategories();
            return Ok(mapper.Map<CategoryDto[]>(categories));
        }
	}
}
