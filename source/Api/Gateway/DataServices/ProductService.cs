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
    public class ProductService : IDataService<CompositeProduct>
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

        public async Task<CompositeProduct> Get(string slug)
        {
            return await _httpService.Get<CompositeProduct>($"{baseUri}api/productservice/v1/products/{slug}");
        }

        public async Task<IEnumerable<CompositeProduct>> GetAll(string[] parameters)
        {
            string uri = $"{baseUri}api/productservice/v1/categoryproducts/";
            foreach (var param in parameters)
            {
                uri += $"{param}/";
            }
            return await _httpService.Get<IEnumerable<CompositeProduct>>(uri);
        }

        public async Task<CompositeProduct> Post(CompositeProduct entity)
        {
            return await _httpService.Post<CompositeProduct>($"{baseUri}api/productservice/v1/products", entity);
        }

        public async Task<CompositeProduct> PostForm(IFormFile file, CompositeProduct product)
        {
            return await _httpService.PostForm($"{baseUri}api/productservice/v1/products/", file, product);
        }

        public async Task<CompositeProduct> Put(CompositeProduct entity)
        {
            return await _httpService.Put<CompositeProduct>($"{baseUri}api/v1/products", entity);
        }
    }
}
