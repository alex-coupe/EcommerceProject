using CartService.Interfaces;
using Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Services
{
    public class ProductServiceClient : IProductServiceClient
    {
        private IHttpService _httpService;
        private string baseUri = "http://product_service:5001/";

        public ProductServiceClient(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<decimal> GetItemBasePrice(int Sku)
        {
            return await _httpService.Get<decimal>($"{baseUri}api/productservice/v1/product/price?id={Sku}");
        }
    }
}
