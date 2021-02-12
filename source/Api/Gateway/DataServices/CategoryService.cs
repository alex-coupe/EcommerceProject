using Gateway.DataTransfer.ProductService;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class CategoryService : IDataService<CategoryTransferObject>
    {
        private IHttpService _httpService;
        private string baseUri = "http://products_service:5001/";
        public CategoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Delete(string slug)
        {
            await _httpService.Delete($"{baseUri}api/productservice/v1/categories/{slug}");
        }

        public async Task<CategoryTransferObject> Get(string slug)
        {
            return await _httpService.Get<CategoryTransferObject>($"{baseUri}api/productservice/v1/categories/{slug}");
        }

        public async Task<IEnumerable<CategoryTransferObject>> GetAll(string[] _)
        {
            return await _httpService.Get<IEnumerable<CategoryTransferObject>>($"{baseUri}api/productservice/v1/categories/");
        }

        public async Task<CategoryTransferObject> Post(CategoryTransferObject entity)
        {
            return await _httpService.Post<CategoryTransferObject>($"{baseUri}api/productservice/v1/categories/", entity);
        }

        public Task<CategoryTransferObject> PostForm(IFormFile file, CategoryTransferObject form)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryTransferObject> Put(CategoryTransferObject entity)
        {
            return await _httpService.Put<CategoryTransferObject>($"{baseUri}api/v1/categories", entity);
        }
    }
}
