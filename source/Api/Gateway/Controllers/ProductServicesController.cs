using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServicesController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;
        public ProductServicesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> TestProductsLink()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://products_api:5001/api/v1/products");

            var _client = _httpClientFactory.CreateClient();

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return Ok("Successfully Spoke To Products Service");
            }

            return NotFound("Couldn't reach products service :(");

        }
    }
}
