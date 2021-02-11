using Gateway.DataModels;
using Gateway.DataModels.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Interfaces;
using Gateway.DataTransfer.ProductService;
using Gateway.DataTransfer.CartService;
using Gateway.DataTransfer.InventoryService;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private IDataService<CategoryTransferObject> _categoriesService;
        private IDataService<CompositeProduct> _productsService;
        private IDataService<CartTransferObject> _cartService;
        private IDataService<Checkout> _checkoutService;
            

        public GatewayController(IDataService<CategoryTransferObject> categoriesService, IDataService<CompositeProduct> productsService, IDataService<CartTransferObject> cartService,
            IDataService<Checkout> checkoutService)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
            _cartService = cartService;
            _checkoutService = checkoutService;
        }

        [HttpGet]
        [Route("v1/ProductDetails")]
        public async Task<ActionResult<ProductTransferObject>> GetProductDetails(string Slug)
        {
           
            try
            {
                var product = await _productsService.Get(Slug);
               
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpGet]
        [Route("v1/CategoryProducts/{Category}/{SubCategory}")]
        public async Task<ActionResult<IEnumerable<ProductTransferObject>>> GetCategoryProducts(string Category, string SubCategory)
        {
            
            try
            {
                var products = await _productsService.GetAll(new string[] { Category, SubCategory });

                
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/Categories")]
        public async Task<ActionResult<IEnumerable<CategoryTransferObject>>> GetCategories()
        {
            try
            {
                var response = await _categoriesService.GetAll(new string[0]); ;         
                return Ok(response);
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /*
        [HttpGet]
        [Route("v1/Cart")]
        public async Task<ActionResult<Cart>> GetCart(string cartId)
        {
            try
            {
                var response = await _cartService.Get(cartId);

                return Ok(response);
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */

        [HttpPost]
        [Route("v1/Products")]
        public async Task<ActionResult<ProductTransferObject>> PostProduct(IFormFile file, [FromForm] CompositeProduct newProduct)
        {
            try
            {
                var response = await _productsService.PostForm(file, newProduct);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/Category")]
        public async Task<ActionResult<CategoryTransferObject>> CreateCategory(CategoryTransferObject category)
        {
            try
            {
                var response = await _categoriesService.Post(category);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        [HttpPost]
        [Route("v1/Reviews")]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            try
            {
                var response = await _reviewService.Post(review);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/Checkout")]
        public async Task<ActionResult> PostCheckout(Checkout checkout)
        {
            try
            {
                var response = await _checkoutService.Post(checkout);
                
                return Ok(new OrderConfirmation
                {
                    Id = response.Id,
                    DeliveryCost = response.DeliveryCost,
                    DeliveryTax = response.DeliveryTax,
                    OrderDate = DateTime.Now,
                    OrderItems = response.Cart.CartItems,
                    Total = response.Total
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
             
        [HttpPost]
        [Route("v1/Cart")]
        public async Task<ActionResult> UpdateCart(Cart cart)
        {            
            try
            {
                var response = await _cartService.Post(cart);
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        */
    }
}
