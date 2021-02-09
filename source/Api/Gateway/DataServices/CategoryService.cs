using Gateway.DataModels.Components;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class CategoryService : IDataService<Category>
    {
        private IHttpService _httpService;
        private string baseUri = "https://localhost:44376/";
        public CategoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Delete(string slug)
        {
            await _httpService.Delete($"{baseUri}api/productservice/v1/categories/{slug}");
        }

        public async Task<Category> Get(string slug)
        {
            return await _httpService.Get<Category>($"{baseUri}api/productservice/v1/categories/{slug}");
        }

        public async Task<IEnumerable<Category>> GetAll(string _)
        {
            return await _httpService.Get<IEnumerable<Category>>($"{baseUri}api/productservice/v1/categories/");
        }

        public async Task<Category> Post(Category entity)
        {
            return await _httpService.Post<Category>($"{baseUri}api/productservice/v1/categories/", entity);
        }

        public Task<Category> PostFile(IFormFile file, string altText)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Put(Category entity)
        {
            return await _httpService.Put<Category>($"{baseUri}api/v1/categories", entity);
        }
    }
}
