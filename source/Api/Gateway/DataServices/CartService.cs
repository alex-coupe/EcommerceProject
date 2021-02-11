﻿using Gateway.DataModels;
using Gateway.DataTransfer.CartService;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class CartService : ICartService
    {
        private string baseUri = "https://localhost:44378";
        private IHttpService _httpService;
        public CartService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        

        public async Task<CartTransferObject> Get(string slug)
        {
            return await _httpService.Get<CartTransferObject>($"{baseUri}api/v1/cart/{slug}");
        }

        public async Task<CartTransferObject> Post(CartTransferObject entity)
        {
            return await _httpService.Post<CartTransferObject>($"{baseUri}api/v1/cart", entity);
        }
              
       
    }
}
