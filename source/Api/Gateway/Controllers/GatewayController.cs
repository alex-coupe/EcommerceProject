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

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private IDataService<Category> _categoriesService;
        private IDataService<Product> _productsService;
        public GatewayController(IDataService<Category> categoriesService, IDataService<Product> productsService)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
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
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("/Category")]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            try
            {
                var response = await _categoriesService.Post(category);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
