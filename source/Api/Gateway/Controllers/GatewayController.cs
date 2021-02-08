using Gateway.DataModels;
using Gateway.DataModels.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using Gateway.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private IDataService<Category> _categoriesService;
        private IDataService<Product> _productsService;
        private IDataService<Cart> _cartService;
        private IDataService<Checkout> _checkoutService;
        private IDataService<Review> _reviewService;
        private IDataService<RelatedProduct> _relatedProductsService;
        private IDataService<Inventory> _inventoryService;
        private IDataService<Image> _imageService;
        private IDataCache<Cart> _cartCache;
        private IDataCache<IEnumerable<Category>> _categoryCache;

        public GatewayController(IDataService<Category> categoriesService, IDataService<Product> productsService, IDataService<Cart> cartService,
            IDataService<Checkout> checkoutService, IDataService<Review> reviewService, IDataService<RelatedProduct> relatedProductsService,
            IDataService<Inventory> inventoryService, IDataCache<Cart> cartCache, IDataCache<IEnumerable<Category>> categoryCache,
            IDataService<Image> imageService)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
            _cartService = cartService;
            _checkoutService = checkoutService;
            _reviewService = reviewService;
            _relatedProductsService = relatedProductsService;
            _inventoryService = inventoryService;
            _cartCache = cartCache;
            _categoryCache = categoryCache;
            _categoryCache.Cache = new List<Category>();
            _imageService = imageService;
        }

        [HttpGet]
        [Route("/ProductDetails/{Slug}")]
        public async Task<ActionResult<CompositeProduct>> GetProductDetails(string Slug)
        {
           
            try
            {
                var productTask = Task.Run(() => _productsService.Get(Slug));
                var reviewsTask = Task.Run(() => _reviewService.GetAll(Slug));
                var relatedProductsTask =  Task.Run(() => _relatedProductsService.GetAll(Slug));
                var inventoryTask = Task.Run(() => _inventoryService.Get(Slug));

                await Task.WhenAll(productTask, reviewsTask, relatedProductsTask, inventoryTask);

                var product = await productTask;
                var reviews = await reviewsTask;
                var relatedProducts = await relatedProductsTask;
                var inventory = await inventoryTask;

                var CompositeProduct = new CompositeProduct
                {
                    ProductDetails = product,
                    Reviews = reviews.Select(review => new Review
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
                };
                return Ok(CompositeProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Images")]
        public async Task<ActionResult<Image>> PostImage(IFormFile file, string altText)
        {
            string[] permittedExtensions = { ".png", ".jpg", ".jpeg", ".gif" };
            var _fileSizeLimit = 5000;
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext) || file.Length > _fileSizeLimit)
                return null;

            try
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                var response = _imageService.Post(new Image { FilePath = filePath, AltText = altText });

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Products")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                var response = await _productsService.Post(product);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("/Images")]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            try
            {
                var response = await _imageService.GetAll("");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("/Reviews")]
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
        [Route("/Checkout")]
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

        [HttpGet]
        [Route("/CategoryProducts/{Category}")]
        public async Task<ActionResult<IEnumerable<CompositeProduct>>> GetCategoryProducts(string Category)
        {
            var CompositeProducts = new List<CompositeProduct>(); 

            try
            {
                var products = await _productsService.GetAll(Category);

                CompositeProducts = products.Select(details => new CompositeProduct
                {
                    ProductDetails = details
                }).ToList();
                return Ok(CompositeProducts);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Category")]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            try
            {
                var response = await _categoriesService.Post(category);
                _categoryCache.Valid = false;
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/Category")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            try
            {
                if (!_cartCache.Valid)
                {
                    var response = await _categoriesService.GetAll(""); ;

                    _categoryCache.Cache = response;
                    _categoryCache.Valid = true;

                    return Ok(response);
                }
                return Ok(_categoryCache.Cache);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Cart")]
        public async Task<ActionResult> UpdateCart(Cart cart)
        {
            _cartCache.Valid = false;
            try
            {
                var response = await _cartService.Post(cart);
                _cartCache.Cache = response;
                _cartCache.Valid = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/Cart")]
        public async Task<ActionResult<Cart>> GetCart(string cartId)
        {
            try
            {
                if (!_cartCache.Valid)
                {
                    var response = await _cartService.Get(cartId);

                    _cartCache.Cache = response;
                    _cartCache.Valid = true;

                    return Ok(response);
                }
                else
                {
                    return Ok(_cartCache.Cache);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
