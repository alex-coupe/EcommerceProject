using Gateway.DataTransfer.InventoryService;
using Gateway.Interfaces;
using ProductService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class InventoryServiceClient : IInventoryServiceClient
    {
        private IHttpService _httpService;
        private string baseUri = "http://inventory_service:5005/";

        public InventoryServiceClient(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<IEnumerable<InventoryTransferObject>> GetInventoryForProduct(int productId)
        {
            return await _httpService.Get<IEnumerable<InventoryTransferObject>>($"{baseUri}api/inventoryservice/v1/StockDetails?productId={productId}");
        }
    }
}
