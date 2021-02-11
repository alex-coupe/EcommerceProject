using Gateway.DataTransfer.InventoryService;
using InventoryService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryServiceController : ControllerBase
    {
        private IInventoryRepository _inventoryRepository;
        public InventoryServiceController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        [Route("v1/StockDetails")]
        public async Task<ActionResult<IEnumerable<InventoryTransferObject>>> GetStockDetails(int productId)
        {
            var inventory = await _inventoryRepository.GetAll(productId);

            return Ok(inventory);
        }

        [HttpPost]
        [Route("v1/UpdateStock")]
        public async Task<ActionResult> ReserveStock(InventoryTransferObject transferObject)
        {
            var item = await _inventoryRepository.Get(transferObject.Sku);

            var reservedTotal = item.ReservedStock + transferObject.TransactionCount;
            switch(transferObject.TransactionType)
            {
                case "RESERVE":
                    if (reservedTotal <= item.TotalStock)
                    {
                        item.ReservedStock = reservedTotal;
                        await _inventoryRepository.SaveChanges();
                        return Ok();
                    }
                    return BadRequest();
                case "FREE":
                    item.ReservedStock-= transferObject.TransactionCount;
                    await _inventoryRepository.SaveChanges();
                    return Ok();
                case "CHECKOUT":
                    item.ReservedStock -= transferObject.TransactionCount;
                    item.TotalStock -= transferObject.TransactionCount;
                    await _inventoryRepository.SaveChanges();
                    return Ok();
            }

            return BadRequest();
        }
    }
}
