using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Interfaces;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        [Route("v1/products/{subcategory}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string subcategory)
        {
            var products = await _productRepository.GetAll(subcategory);

            return Ok(products);
        }

        [HttpGet]
        [Route("v1/product/{slug}")]
        public async Task<ActionResult<Product>> GetProduct(string slug)
        {
            var product = await _productRepository.GetOne(slug);

            if (product != null)
                return Ok(product);

            return NotFound();
        }

        [HttpGet]
        [Route("v1/product/price/{slug}")]
        public async Task<ActionResult<decimal>> GetPrice(string slug)
        {
            var product = await _productRepository.GetOne(slug);

            if (product != null)
                return Ok(product.UnitPrice);

            return NotFound();
        }


        [HttpGet]
        [Route("v1/categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAll();

            return Ok(categories);
        }

        [HttpGet]
        [Route("v1/categories/{baseCategory}")]
        public async Task<ActionResult<Category>> GetCategory(string baseCategory)
        {
            var category = await _categoryRepository.GetOne(baseCategory);

            if (category != null)
                return Ok(category);

            return NotFound();
        }

        [HttpGet]
        [Route("v1/images/")]
        public async Task<ActionResult<IEnumerable<Image>>> GetImage()
        {
            var images = await _imageRepository.GetAll();

            return Ok(images);
        }

        [HttpGet]
        [Route("v1/images/{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
            var image = await _imageRepository.GetOne(id);

            if (image != null)
                return Ok(image);

            return NotFound();
        }

        [HttpPost]
        [Route("v1/products")]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _productRepository.Create(product);

            await _productRepository.SaveChanges();

            return CreatedAtAction("CreateProduct", product);
        }

        [HttpPost]
        [Route("v1/categories")]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            _categoryRepository.Create(category);

            await _categoryRepository.SaveChanges();

            return CreatedAtAction("CreateCategory", new { id = category.Id }, category);
        }

        [HttpPost]
        [Route("v1/images")]
        public async Task<ActionResult<Image>> CreateImage(IFormFile file)
        {
            string altText = Request.Form["altText"];
            string[] permittedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
            var _fileSizeLimit = 5000000;
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext) || file.Length > _fileSizeLimit)
                return null;
            var fileName = file.FileName;
            var filePath = "C:\\Users\\Alexander\\Documents\\TestDocs";
            var fullPath = Path.Combine(filePath,fileName);

            using (var stream = System.IO.File.Create(fullPath))
            {
                await file.CopyToAsync(stream);
            }
            try
            {
                var image = new Image
                {
                    AltText = altText,
                    FileName = fileName,
                    FilePath = filePath
                };
                _imageRepository.Create(image);

                await _imageRepository.SaveChanges();

                return CreatedAtAction("CreateImage", new { id = image.Id }, image);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPut]
        [Route("v1/products/{product}")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            _productRepository.Update(product);

            await _productRepository.SaveChanges();

            return Ok(product);
        }

        [HttpPut]
        [Route("v1/categories/{category}")]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);

            await _categoryRepository.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("v1/images/{image}")]
        public async Task<ActionResult<Image>> UpdateImage(Image image)
        {
            _imageRepository.Update(image);

            await _imageRepository.SaveChanges();

            return Ok(image);
        }

        [HttpDelete]
        [Route("v1/products/{product}")]
        public async Task<ActionResult> RemoveProduct(Product product)
        {
             _productRepository.Remove(product);

            await _productRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("v1/categories/{category}")]
        public async Task<ActionResult> RemoveCategory(Category category)
        {
            _categoryRepository.Remove(category);

            await _productRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("v1/images/{image}")]
        public async Task<ActionResult> RemoveImage(Image image)
        {
            _imageRepository.Remove(image);

            await _productRepository.SaveChanges();

            return Ok();
        }

    }
}
