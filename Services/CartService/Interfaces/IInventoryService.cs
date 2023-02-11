using Gateway.DataTransfer.InventoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Interfaces
{
    public interface IInventoryService
    {
        Task ReserveStock(InventoryTransferObject inventoryTransferObject);
    }
}
