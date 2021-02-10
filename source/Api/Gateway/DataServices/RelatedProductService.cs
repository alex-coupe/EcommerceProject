using Gateway.DataModels.Components;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class RelatedProductService : IDataService<RelatedProduct>
    {
        private IHttpService _httpService;
        private string baseUri = "http://relatedproducts_service:5006";

        public RelatedProductService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task Delete(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<RelatedProduct> Get(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RelatedProduct>> GetAll(string[] parameters)
        {
            string uri = $"{baseUri}api/v1/relatedproducts/";
            foreach (var param in parameters)
            {
                uri += $"{param}/";
            }
            return await _httpService.Get<IEnumerable<RelatedProduct>>(uri);
        }

        public Task<RelatedProduct> Post(RelatedProduct entity)
        {
            throw new NotImplementedException();
        }

        public Task<RelatedProduct> PostFile(IFormFile file, string altText)
        {
            throw new NotImplementedException();
        }

        public Task<RelatedProduct> Put(RelatedProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
