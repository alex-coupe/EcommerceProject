using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gateway.Interfaces;
using Gateway.DataTransfer.ProductService;
using Gateway.DataTransfer.CheckoutService;
using Gateway.DataTransfer.CartService;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private IDataService<CategoryTransferObject> _categoriesService;
        private IProductService _productsService;
        private ICartService _cartService;
        private ICheckoutService _checkoutService;
            

        public GatewayController(IDataService<CategoryTransferObject> categoriesService, IProductService productsService, ICartService cartService,
            ICheckoutService checkoutService)
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
       
        [HttpGet]
        [Route("v1/Cart")]
        public async Task<ActionResult<CartTransferObject>> GetCart(string cartId)
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
       

        [HttpPost]
        [Route("v1/Products")]
        public async Task<ActionResult<ProductTransferObject>> PostProduct(IFormFile file, [FromForm] ProductTransferObject newProduct)
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

       

        [HttpPost]
        [Route("v1/Checkout")]
        public async Task<ActionResult<OrderConfirmationTransferObject>> PostCheckout(CheckoutTransferObject checkout)
        {
            try
            {
                var response = await _checkoutService.PostOrder(checkout);
                return Ok(response);
              
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
             
        [HttpPost]
        [Route("v1/Cart")]
        public async Task<ActionResult<CartTransferObject>> UpdateCart(CartTransferObject cart)
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

        
    }
}
