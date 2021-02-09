using Gateway.DataModels.Components;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class ProductService : IDataService<Product>
    {
        private string baseUri = "http://products_service:5001/";
        private IHttpService _httpService;
        public ProductService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Delete(string slug)
        {
            await _httpService.Delete($"{baseUri}api/v1/products/{slug}");
        }

        public async Task<Product> Get(string slug)
        {
            return await _httpService.Get<Product>($"{baseUri}api/v1/products/{slug}");
        }

        public async Task<IEnumerable<Product>> GetAll(string category)
        {
            return await _httpService.Get<IEnumerable<Product>>($"{baseUri}api/v1/categoryproducts/{category}");
        }

        public async Task<Product> Post(Product entity)
        {
            return await _httpService.Post<Product>($"{baseUri}api/v1/products", entity);
        }

        public Task<Product> PostFile(IFormFile file, string altText)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Put(Product entity)
        {
            return await _httpService.Put<Product>($"{baseUri}api/v1/products", entity);
        }
    }
}
