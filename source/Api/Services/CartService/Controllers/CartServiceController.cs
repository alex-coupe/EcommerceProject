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
        private ICartItemRepository _cartItemRepository;
        private IProductServiceClient _productClient;
        private IInventoryService _inventoryService;
        public CartServiceController(ICartRepository cartRepository, IProductServiceClient productServiceClient, ICartItemRepository cartItemRepository, 
            IInventoryService inventoryService)
        {
            _cartRepository = cartRepository;
            _productClient = productServiceClient;
            _cartItemRepository = cartItemRepository;
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("v1/GetCart")]
        public async Task<ActionResult<CartTransferObject>> GetCart(string cartId)
        {
            var cart = await _cartRepository.Get(cartId);
            if (cart != null)
            {
                var transferObject = new CartTransferObject
                {
                    CartItems = cart.CartItems.Select(x => new CartItemTransferObject
                    {
                        CartId = x.CartId,
                        GrossPrice = x.GrossPrice,
                        Id = x.Id,
                        Name = x.Name,
                        NetPrice = x.NetPrice,
                        Sku = x.Sku,
                        Quantity = x.Quantity,
                        Tax = x.Tax,
                        UnitPrice = x.UnitPrice
                    }).ToList(),
                    CreatedDate = cart.CreatedDate,
                    Gross = cart.Gross,
                    Id = cart.Id,
                    LastUpdated = cart.LastUpdated,
                    Net = cart.Net,
                    Tax = cart.Tax
                };
                return Ok(transferObject);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("v1/UpdateCart")]
        public async Task<ActionResult<CartTransferObject>> UpdateCart(CartTransferObject cart)
        {
            double gross = 0.00;
            double tax = 0.00;
            double net = 0.00;
            var itemCount = 0;
            if (string.IsNullOrEmpty(cart.Id))
            {
                cart.Id = Guid.NewGuid().ToString();
              
                foreach(var item in cart.CartItems)
                {
                    await _inventoryService.ReserveStock(new Gateway.DataTransfer.InventoryService.InventoryTransferObject
                    {
                        Sku = item.Sku,
                        TransactionType = "RESERVE",
                        TransactionCount = item.Quantity
                    });
                    item.UnitPrice = await _productClient.GetItemBasePrice(item.Id);
                    item.NetPrice = item.UnitPrice * item.Quantity;
                    itemCount += item.Quantity;
                    net += (double)item.NetPrice;
                    item.Tax = item.NetPrice * (decimal)0.2;
                    tax += (double)item.Tax;
                    item.GrossPrice = item.NetPrice + item.Tax;
                    gross += (double)item.GrossPrice;

                    _cartItemRepository.Create(new CartItem
                    {
                        CartId = cart.Id,
                       
                        GrossPrice = item.GrossPrice,
                        Name = item.Name,
                        NetPrice = item.NetPrice,
                        Quantity = item.Quantity,
                        Sku = item.Sku,
                        Tax = item.Tax,
                        UnitPrice = item.UnitPrice,

                    });
                }

                var saveCart = new Cart
                {
                    Id = cart.Id,
                    CreatedDate = DateTime.Now,
                    Gross = (decimal)gross,
                    ItemCount = itemCount,
                    LastUpdated = DateTime.Now,
                    Net = (decimal)net,
                    Tax = (decimal)tax
                };

                cart.Gross = (decimal)gross;
                cart.Net = (decimal)net;
                cart.Tax = (decimal)tax;
                cart.CreatedDate = DateTime.Now;
                cart.LastUpdated = DateTime.Now;
               
                _cartRepository.Create(saveCart);
                await _cartRepository.SaveChanges();
                return Ok(cart);
            }
            else
            {
                var updateCart = await _cartRepository.Get(cart.Id);
                if (updateCart == null)
                    return NotFound();

                foreach (var item in cart.CartItems)
                {
                    item.NetPrice = item.UnitPrice * item.Quantity;
                    itemCount += item.Quantity;
                    net += (double)item.NetPrice;
                    item.Tax = item.NetPrice * (decimal)0.2;
                    tax += (double)item.Tax;
                    item.GrossPrice = item.NetPrice + item.Tax;
                    gross += (double)item.GrossPrice;
                }
                var cartUpdate = new Cart
                {
                    Id = cart.Id,
                    CreatedDate = DateTime.Now,
                    Gross = (decimal)gross,
                    ItemCount = itemCount,
                    LastUpdated = DateTime.Now,
                    Net = (decimal)net,
                    Tax = (decimal)tax
                };
                _cartRepository.Update(cartUpdate);
                await _cartRepository.SaveChanges();
                return Ok(cart);
            }

                      
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
