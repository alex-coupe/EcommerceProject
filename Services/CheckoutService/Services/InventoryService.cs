using CheckoutService.Interfaces;
using Gateway.DataTransfer.CheckoutService;
using Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutService.Services
{
    public class InventoryService : IInventoryService
    {
        private IHttpService _httpService;
        private string baseUri = "http://inventory_service:5005/";
        public InventoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<bool> Post(CheckoutTransferObject entity)
        {
             return await _httpService.Post<bool>($"{baseUri}api/inventoryservice/v1/converttoorder", entity);
        }
    }
}
