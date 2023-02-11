using Gateway.DataTransfer.InventoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Interfaces
{
    public interface IInventoryServiceClient
    {
        Task<IEnumerable<InventoryTransferObject>> GetInventoryForProduct(int productId);
    }
}
