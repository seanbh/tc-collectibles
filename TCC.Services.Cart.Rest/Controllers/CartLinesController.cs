using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Cart.Rest.Models;
using TCC.Services.Cart.Rest.Respositories;
using TCC.Services.Cart.Rest.Services;

namespace TCC.Services.Cart.Rest.Controllers
{
    [Route("api/carts/{cartId}/cartLines")]
    [ApiController]
    public class CartLinesController : ControllerBase
    {
        private readonly ICartLinesRepository cartLinesRepository;
        private readonly ICartRepository cartRepository;
        private readonly IProductRepository productRepository;
        private readonly ICatalogService catalogService;
        private readonly IMapper mapper;

        public CartLinesController(ICartLinesRepository cartLinesRepository, ICartRepository cartRepository, IProductRepository productRepository, ICatalogService catalogService, IMapper mapper)
        {
            this.cartLinesRepository = cartLinesRepository;
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.catalogService = catalogService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.CartLine>>> Get(Guid cartId)
        {
            if(!await cartRepository.CartExists(cartId))
            {
                return NotFound();
            }

            var cartLines = await cartLinesRepository.GetCartLines(cartId);
            var cartLineModels = mapper.Map<IEnumerable<Models.CartLine>>(cartLines);

            return Ok(cartLineModels);
        }

        [HttpGet("{cartLineId}", Name = "GetCartLine")]
        public async Task<ActionResult<Models.CartLine>> Get(Guid cartId, Guid cartLineId)
        {
            if(!await cartRepository.CartExists(cartId))
            {
                return NotFound();
            }

            var cartLine = await cartLinesRepository.GetCartLineById(cartLineId);
            if(cartLine == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Models.CartLine>(cartLine));
        }

        [HttpPost]
        public async Task<ActionResult> Post (Guid cartId, [FromBody] CartLineForCreation cartLineForCreation)
		{
            if(!await cartRepository.CartExists(cartId))
			{
                return NotFound();
			}

            if(!await productRepository.ProductExists(cartLineForCreation.ProductId))
			{
                var product = await catalogService.GetProduct(cartLineForCreation.ProductId);
                productRepository.AddProduct(product);
                await productRepository.SaveChanges();
			}

            var cartLineEntity = mapper.Map<Entities.CartLine>(cartLineForCreation);
            var processedCartLine = await cartLinesRepository.AddOrUpdateCartLine(cartId, cartLineEntity);
            await cartLinesRepository.SaveChanges();

            var cartLineToReturn = mapper.Map<Models.CartLine>(processedCartLine);

            return CreatedAtRoute("GetCartLine", new { cartId = cartLineEntity.CartId, cartLineId = cartLineEntity.CartLineId }, cartLineToReturn);
		}

        [HttpPut("{cartLineId}")]
        public async Task<ActionResult<CartLine>> Put(Guid cartId,
           Guid cartLineId,
           [FromBody] CartLineForUpdate cartLineForUpdate)
        {
            if (!await cartRepository.CartExists(cartId))
            {
                return NotFound();
            }

            var cartLineEntity = await cartLinesRepository.GetCartLineById(cartLineId);

            if (cartLineEntity == null)
            {
                return NotFound();
            }

            // map the entity to a dto
            // apply the updated field values to that dto
            // map the dto back to an entity
            mapper.Map(cartLineForUpdate, cartLineEntity);

            cartLinesRepository.UpdateCartLine(cartLineEntity);
            await cartLinesRepository.SaveChanges();

            return Ok(mapper.Map<CartLine>(cartLineEntity));
        }

        [HttpDelete("{cartLineId}")]
        public async Task<IActionResult> Delete(Guid cartId,
            Guid cartLineId)
        {
            if (!await cartRepository.CartExists(cartId))
            {
                return NotFound();
            }

            var cartLineEntity = await cartLinesRepository.GetCartLineById(cartLineId);

            if (cartLineEntity == null)
            {
                return NotFound();
            }

            cartLinesRepository.RemoveCartLine(cartLineEntity);
            await cartLinesRepository.SaveChanges();

            return NoContent();
        }

    }
}
