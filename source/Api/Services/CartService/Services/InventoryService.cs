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
        private string baseUri = "https://localhost:44311/";
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
