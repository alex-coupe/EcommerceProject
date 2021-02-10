using Gateway.DataTransfer.ProductService;
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
      
      
        public ProductServiceController(IProductRepository productRepository, ICategoryRepository categoryRepository, IImageRepository imageRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;
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
        public async Task<ActionResult<ProductTransferObject>> GetProduct(string slug)
        {
            var product = await _productRepository.GetOne(slug);

            if (product != null)
            {
             
                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("v1/product/price/{slug}")]
        public async Task<ActionResult> GetPrice(string slug)
        {
            var product = await _productRepository.GetOne(slug);

            if (product != null)
                return Ok(new { UnitPrice = product.UnitPrice });

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
        public async Task<ActionResult<ProductTransferObject>> CreateProduct(IFormFile file, IFormCollection form)
        {
            var test = (form["form"]);
            var productInput = JsonSerializer.Deserialize<ProductTransferObject>(form["form"]);
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
                    AltText = productInput.AltText,
                    FileName = fileName,
                    FilePath = filePath
                };
                _imageRepository.Create(image);

                await _imageRepository.SaveChanges();

                var product = new Product
                {
                    Name = productInput.Name,
                    Sku = productInput.Sku,
                    Description = productInput.Description,
                    ProductImageId = image.Id,
                    Slug = productInput.Slug,
                    UnitPrice = productInput.UnitPrice,
                    Category = productInput.Category,
                    SubCategory = productInput.SubCategory
                };

                productInput.ImagePath = fullPath;

                _productRepository.Create(product);
                await _productRepository.SaveChanges();
                

                return CreatedAtAction("CreateProduct", productInput);
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
