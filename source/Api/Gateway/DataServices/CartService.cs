using Gateway.DataModels;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class CartService : IDataService<Cart>
    {
        private string baseUri = "http://cart_service:5003/";
        private IHttpService _httpService;
        public CartService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public Task Delete(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> Get(string slug)
        {
            return await _httpService.Get<Cart>($"{baseUri}api/v1/cart/{slug}");
        }

        public Task<IEnumerable<Cart>> GetAll(string[] parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> Post(Cart entity)
        {
            return await _httpService.Post<Cart>($"{baseUri}api/v1/cart", entity);
        }

        public Task<Cart> PostFile(IFormFile file, string altText)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> Put(Cart entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
