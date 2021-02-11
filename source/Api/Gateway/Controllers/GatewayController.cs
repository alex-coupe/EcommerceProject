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

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private IDataService<CategoryTransferObject> _categoriesService;
        private IDataService<ProductTransferObject> _productsService;
        private IDataService<CartTransferObject> _cartService;
        private IDataService<Checkout> _checkoutService;
        private IDataService<Review> _reviewService;
        private IDataService<RelatedProduct> _relatedProductsService;
        private IDataService<Inventory> _inventoryService;
     

        public GatewayController(IDataService<CategoryTransferObject> categoriesService, IDataService<ProductTransferObject> productsService, IDataService<CartTransferObject> cartService,
            IDataService<Checkout> checkoutService, IDataService<Review> reviewService, IDataService<RelatedProduct> relatedProductsService,
            IDataService<Inventory> inventoryService)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
            _cartService = cartService;
            _checkoutService = checkoutService;
            _reviewService = reviewService;
            _relatedProductsService = relatedProductsService;
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("v1/ProductDetails")]
        public async Task<ActionResult<CompositeProduct>> GetProductDetails(string Slug)
        {
           
            try
            {
                var productTask = Task.Run(() => _productsService.Get(Slug));
                //  var reviewsTask = Task.Run(() => _reviewService.GetAll(new string[] { Slug }));
                // var relatedProductsTask =  Task.Run(() => _relatedProductsService.GetAll(new string[] { Slug }));
                //  var inventoryTask = Task.Run(() => _inventoryService.Get(Slug));

                await Task.WhenAll(productTask);//, reviewsTask, relatedProductsTask, inventoryTask);

                var product = await productTask;
               // var reviews = await reviewsTask;
              //  var relatedProducts = await relatedProductsTask;
              //  var inventory = await inventoryTask;

                var CompositeProduct = new CompositeProduct
                {
                    ProductDetails = product
               /*     Reviews = reviews.Select(review => new Review
                    {
                        Rating = review.Rating,
                        ReviewBody = review.ReviewBody,
                        Id = review.Id,
                        ReviewDate = review.ReviewDate,
                        ReviewerName = review.ReviewerName
                    }).ToList(),
                    RelatedProducts = relatedProducts.Select(relpr => new RelatedProduct
                    {
                        ProductDetails = relpr.ProductDetails,
                    }).ToList(),
                    Inventory = inventory
               */
                };
                return Ok(CompositeProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpGet]
        [Route("v1/CategoryProducts/{Category}/{SubCategory}")]
        public async Task<ActionResult<IEnumerable<CompositeProduct>>> GetCategoryProducts(string Category, string SubCategory)
        {
            var CompositeProducts = new List<CompositeProduct>();

            try
            {
                var products = await _productsService.GetAll(new string[] { Category, SubCategory });

                CompositeProducts = products.Select(details => new CompositeProduct
                {
                    ProductDetails = details
                }).ToList();
                return Ok(CompositeProducts);
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
