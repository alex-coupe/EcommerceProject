using Gateway.DataModels.Components;
using Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class CategoryService : IDataService<Category>
    {
        private IHttpService _httpService;
        private string baseUri = "http://categories_service:5001/";
        public CategoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Delete(string slug)
        {
            await _httpService.Delete($"{baseUri}api/v1/categories/{slug}");
        }

        public async Task<Category> Get(string slug)
        {
            return await _httpService.Get<Category>($"{baseUri}api/v1/categories/{slug}");
        }

        public async Task<IEnumerable<Category>> GetAll(string _)
        {
            return await _httpService.Get<IEnumerable<Category>>($"{baseUri}api/v1/categories");
        }

        public async Task<Category> Post(Category entity)
        {
            return await _httpService.Post<Category>($"{baseUri}api/v1/categories", entity);
        }

        public async Task<Category> Put(Category entity)
        {
            return await _httpService.Put<Category>($"{baseUri}api/v1/categories", entity);
        }
    }
}
