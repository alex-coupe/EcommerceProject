using Gateway.DataModels;
using Gateway.DataTransfer.CartService;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class CartService : IDataService<CartTransferObject>
    {
        private string baseUri = "https://localhost:44378";
        private IHttpService _httpService;
        public CartService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public Task Delete(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<CartTransferObject> Get(string slug)
        {
            return await _httpService.Get<CartTransferObject>($"{baseUri}api/v1/cart/{slug}");
        }

        public Task<IEnumerable<CartTransferObject>> GetAll(string[] parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<CartTransferObject> Post(CartTransferObject entity)
        {
            return await _httpService.Post<CartTransferObject>($"{baseUri}api/v1/cart", entity);
        }

        public Task<CartTransferObject> PostForm(IFormFile file, CartTransferObject form)
        {
            throw new NotImplementedException();
        }

        public Task<CartTransferObject> Put(CartTransferObject entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
