using Gateway.DataTransfer.InventoryService;
using Gateway.DataTransfer.ProductService;
using Gateway.DataTransfer.RelatedProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Interfaces;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceController : ControllerBase
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IImageRepository _imageRepository;
        private IReviewServiceClient _reviewService;
        private IRelatedProductServiceClient _relatedProductService;
        private IInventoryServiceClient _inventoryService;

        public ProductServiceController(IProductRepository productRepository, ICategoryRepository categoryRepository, IImageRepository imageRepository,
            IReviewServiceClient reviewService, IRelatedProductServiceClient relatedProductService, IInventoryServiceClient inventoryService)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;
            _reviewService = reviewService;
            _relatedProductService = relatedProductService;
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("v1/categoryproducts/{category}/{subcategory}")]
        public async Task<ActionResult<IEnumerable<ProductTransferObject>>> GetProducts(string category, string subcategory)
        {
            var products = await _productRepository.GetAll(category, subcategory);

            return Ok(products);
        }

        [HttpGet]
        [Route("v1/products/{slug}")]
        public async Task<ActionResult<CompositeProduct>> GetProduct(string slug)
        {
            var product = await _productRepository.GetOne(slug);

            var reviewsTask = Task.Run(() => _reviewService.GetReviews(product.Id));
            var relatedProductsTask = Task.Run(() => _relatedProductService.GetRelatedProducts(product.Id));
            var inventoryTask = Task.Run(() => _inventoryService.GetInventoryForProduct(product.Id));

            await Task.WhenAll(reviewsTask, relatedProductsTask, inventoryTask);

            var reviews = await reviewsTask;
            var relatedProducts =  await relatedProductsTask;
            var inventory =  await inventoryTask;

            var CompositeProduct = new CompositeProduct
            {
                ProductDetails = product,
                Reviews = reviews,
                Inventory = inventory
            };

            var relatedProductsList = new List<ProductTransferObject>();

            foreach (var entry in relatedProducts)
            {
                var relatedProduct = await _productRepository.GetProductById(entry.RelatedProductId);

                relatedProductsList.Add(relatedProduct);
            }

            CompositeProduct.RelatedProducts = relatedProductsList;

            return Ok(CompositeProduct);
        }

        [HttpGet]
        [Route("v1/product/price")]
        public async Task<ActionResult> GetPrice(int id)
        {
            var product = await _productRepository.GetProductById(id);

            if (product != null)
                return Ok(product.UnitPrice );

            return NotFound();
        }


        [HttpGet]
        [Route("v1/categories")]
        public async Task<ActionResult<IEnumerable<CategoryTransferObject>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAll();

            return Ok(categories);
        }


        //Get subcategories by main category
        [HttpGet]
        [Route("v1/categories/{Category}")]
        public async Task<ActionResult<CategoryTransferObject>> GetCategory(string Category)
        {
            var categoryTransferObject = await _categoryRepository.GetOne(Category);

            if (categoryTransferObject != null)
                return Ok(categoryTransferObject);

            return NotFound();
        }

        [HttpPost]
        [Route("v1/categories")]
        public async Task<ActionResult<CategoryTransferObject>> CreateCategory(CategoryTransferObject category)
        {
            _categoryRepository.Create(category);

            await _categoryRepository.SaveChanges();

            return CreatedAtAction("CreateCategory", category);
        }

        [HttpPost]
        [Route("v1/products")]
        public async Task<ActionResult<ProductTransferObject>> CreateProduct(IFormFile file)
        {
            var newProduct = JsonSerializer.Deserialize<ProductTransferObject>(Request.Form["product-details"]);
            string[] permittedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".webp" };
            var _fileSizeLimit = 5000000;
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext) || file.Length > _fileSizeLimit)
                return null;
            var fileName = file.FileName;
            var filePath = "C:\\Users\\Alexander\\Documents\\ShopImages";
            var fullPath = Path.Combine(filePath,fileName);
            try
            {
                using (var stream = System.IO.File.Create(fullPath))
                {
                    await file.CopyToAsync(stream);
                }
           
                var image = new Image
                {
                    AltText = newProduct.AltText,
                    FileName = fileName,
                    FilePath = filePath
                };
                _imageRepository.Create(image);

                await _imageRepository.SaveChanges();

                var product = new Product
                {
                    Name = newProduct.Name,
                    Description = newProduct.Description,
                    ProductImageId = image.Id,
                    Slug = newProduct.Slug,
                    UnitPrice = newProduct.UnitPrice,
                    Category =  newProduct.Categories.MainCategory,
                    SubCategory = newProduct.Categories.SubCategories.FirstOrDefault(),
                    Sizes = newProduct.ProductVariants.Select (x => new ProductVariant
                    {
                        Size = x.Size,
                        Sku = x.Sku,
                    })                    
                };

                newProduct.ImagePath = fullPath;

                _productRepository.Create(product);
                await _productRepository.SaveChanges();
                

                return CreatedAtAction("CreateProduct", newProduct);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPut]
        [Route("v1/products")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            _productRepository.Update(product);

            await _productRepository.SaveChanges();

            return Ok(product);
        }

        [HttpPut]
        [Route("v1/categories")]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);

            await _categoryRepository.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        [Route("v1/products")]
        public async Task<ActionResult> RemoveProduct(int id)
        {
             _productRepository.Remove(id);

            await _productRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("v1/categories")]
        public async Task<ActionResult> RemoveCategory(int id)
        {
            _categoryRepository.Remove(id);

            await _productRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("v1/images")]
        public async Task<ActionResult> RemoveImage(int id)
        {
            _imageRepository.Remove(id);

            await _productRepository.SaveChanges();

            return Ok();
        }

    }
}
