﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Application.Features.Categories.Commands;
using TCC.Application.Features.Categories.Queries.GetCategoriesExport;
using TCC.Application.Features.Categories.Queries.GetCategoriesList;
using TCC.Application.Features.Categories.Queries.GetCategoriesListWithProducts;
using TCC.Domain.Entities;

namespace TCC.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator mediator;

		public CategoryController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet("instance")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<string> GetInstanceId()
        {
			return Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID");
        }

		[HttpGet("all", Name = "GetAllCategories")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
		{
			var categories = await mediator.Send(new GetCategoriesListQuery());
			return Ok(categories);
		}

		[HttpGet("allwithproducts", Name = "GetCategoriesWithProducts")]
		[ProducesDefaultResponseType]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<CategoryProductListVm>>> GetCategoriesWithProducts()
		{
			var categoriesWithProduct = await mediator.Send(new GetCategoriesListWithProductsQuery());
			return Ok(categoriesWithProduct);
		}

		[HttpPost(Name = "AddCategory")]
		public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
		{
			var response = await mediator.Send(createCategoryCommand);
			return Ok(response);
		}

		[HttpGet("export", Name ="Export Categories")]
		public async Task<FileResult> ExportCategories()
		{
			var fileDto = await mediator.Send(new GetCategoriesExportQuery());
			return File(fileDto.Data, fileDto.ContentType, fileDto.FileName);
		}

	}
}
