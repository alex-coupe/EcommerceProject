using CartService.Interfaces;
using CartService.Models;
using Gateway.DataTransfer.CartService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartServiceController : ControllerBase
    {
        private ICartRepository _cartRepository;

        public CartServiceController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        [Route("v1/GetCart")]
        public async Task<ActionResult<Cart>> GetCart(string cartId)
        {
            var cart = await _cartRepository.Get(cartId);
            if (cart != null)
                return Ok(cart);

            return NotFound();
        }

        [HttpPost]
        [Route("v1/UpdateCart")]
        public async Task<ActionResult<CartTransferObject>> UpdateCart(CartTransferObject cart)
        {
            if (string.IsNullOrEmpty(cart.Id))
                cart.Id = new Guid().ToString();

            await _cartRepository.SaveChanges();

            return Ok(cart);
        }

        [HttpPost]
        [Route("v1/DestroyCart")]
        public async Task<ActionResult> DestroyCart(string cartId)
        {
            _cartRepository.Remove(cartId);

            await _cartRepository.SaveChanges();

            return Ok();
        }

    }
}
