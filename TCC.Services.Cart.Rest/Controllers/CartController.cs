using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Services.Cart.Rest.Models;
using TCC.Services.Cart.Rest.Respositories;

namespace TCC.Services.Cart.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository cartRepository;
        private readonly IMapper mapper;

        public CartController(ICartRepository cartRepository, IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.mapper = mapper;
        }

        [HttpGet("{cartId}", Name ="GetCart")]
        public async Task<ActionResult<Models.Cart>> Get(Guid cartId)
        {
            var cart = await cartRepository.GetCartById(cartId);
            if(cart == null)
            {
                return NotFound();
            }

            Models.Cart cartModel = mapper.Map<Models.Cart>(cart);
            cartModel.NumberOfItems = cart.CartLines.Sum(cl => cl.Qty);
            return base.Ok(cartModel);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Cart>> Post(CartForCreation cartModel)
        {
            var cart = mapper.Map<Entities.Cart>(cartModel);
            cartRepository.AddCart(cart);
            await cartRepository.SaveChanges();

            var returnModel = mapper.Map<Models.Cart>(cart);

            return CreatedAtRoute("GetCart", new { cartId = cart.CartId }, returnModel);
        }
    }
}
