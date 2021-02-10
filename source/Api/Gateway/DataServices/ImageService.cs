using Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.DataModels.Components;
using Microsoft.AspNetCore.Http;
using Gateway.DataTransfer.ProductService;

namespace Gateway.DataServices
{
    public class ImageService : IDataService<ImageTransferObject>
    {
        private string baseUri = "https://localhost:44376/";
        private IHttpService _httpService;

        public ImageService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public Task Delete(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<ImageTransferObject> Get(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ImageTransferObject>> GetAll(string[] parameters)
        {
            string uri = $"{baseUri}api/productservice/v1/images/";

            foreach (var param in parameters)
            {
                uri += $"{param}/";
            }
            return await _httpService.Get<IEnumerable<ImageTransferObject>>(uri);
        }

        public async Task<ImageTransferObject> Post(ImageTransferObject entity)
        {
            return await _httpService.Post<ImageTransferObject>($"{baseUri}api/v1/images", entity);
        }

        public async Task<ImageTransferObject> PostFile(IFormFile file, string altText)
        {
            return await _httpService.PostFile<ImageTransferObject>($"{baseUri}api/productservice/v1/images/", file, altText);
        }

        public Task<ImageTransferObject> Put(ImageTransferObject entity)
        {
            throw new NotImplementedException();
        }


    }
}
