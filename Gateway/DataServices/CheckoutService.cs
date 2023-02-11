using Gateway.DataTransfer.CheckoutService;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class CheckoutService : ICheckoutService
    {
        private IHttpService _httpService;
        private string baseUri = "http://checkout_service:5004/";

        public CheckoutService(IHttpService httpService)
        {
            _httpService = httpService;
        }
      

        public async Task<OrderConfirmationTransferObject> PostOrder(CheckoutTransferObject entity)
        {
            return await _httpService.Post<OrderConfirmationTransferObject>($"{baseUri}api/checkoutservice/v1/Checkout", entity);
        }

       
    }
}
