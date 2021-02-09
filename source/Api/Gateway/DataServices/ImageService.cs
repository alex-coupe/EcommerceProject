using Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.DataModels.Components;
using Microsoft.AspNetCore.Http;

namespace Gateway.DataServices
{
    public class ImageService : IDataService<Image>
    {
        private string baseUri = "http://image_service:5008/";
        private IHttpService _httpService;

        public ImageService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public Task Delete(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<Image> Get(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Image>> GetAll(string parameter)
        {
            return await _httpService.Get<IEnumerable<Image>>($"{baseUri}api/v1/images/{parameter}");
        }

        public async Task<Image> Post(Image entity)
        {
            return await _httpService.Post<Image>($"{baseUri}api/v1/images", entity);
        }

        public Task<Image> PostFile(IFormFile file, string altText)
        {
            throw new NotImplementedException();
        }

        public Task<Image> Put(Image entity)
        {
            throw new NotImplementedException();
        }


    }
}
