using Gateway.DataModels.Components;
using Gateway.DataTransfer.ProductService;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class ProductService : IDataService<ProductTransferObject>
    {
        private string baseUri = "https://localhost:44376/";
        private IHttpService _httpService;
        public ProductService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Delete(string slug)
        {
            await _httpService.Delete($"{baseUri}api/productservice/v1/products/{slug}");
        }

        public async Task<ProductTransferObject> Get(string slug)
        {
            return await _httpService.Get<ProductTransferObject>($"{baseUri}api/productservice/v1/products/{slug}");
        }

        public async Task<IEnumerable<ProductTransferObject>> GetAll(string[] parameters)
        {
            string uri = $"{baseUri}api/productservice/v1/categoryproducts/";
            foreach (var param in parameters)
            {
                uri += $"{param}/";
            }
            return await _httpService.Get<IEnumerable<ProductTransferObject>>(uri);
        }

        public async Task<ProductTransferObject> Post(ProductTransferObject entity)
        {
            return await _httpService.Post<ProductTransferObject>($"{baseUri}api/productservice/v1/products", entity);
        }

        public Task<ProductTransferObject> PostFile(IFormFile file, string altText)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductTransferObject> Put(ProductTransferObject entity)
        {
            return await _httpService.Put<ProductTransferObject>($"{baseUri}api/v1/products", entity);
        }
    }
}
