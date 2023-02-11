using CartService.Interfaces;
using Gateway.DataTransfer.InventoryService;
using Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Services
{
    public class InventoryService : IInventoryService
    {
        private IHttpService _httpService;
        private string baseUri = "http://inventory_service:5005/";
        public InventoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task ReserveStock(InventoryTransferObject inventoryTransferObject)
        {
             await _httpService.Post<InventoryTransferObject>($"{baseUri}api/inventoryservice/v1/updatestock", inventoryTransferObject);
        }
    }
}
