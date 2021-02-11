using Gateway.DataTransfer.CheckoutService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutService.Interfaces
{
    public interface IInventoryService
    {
        Task<bool> Post(CheckoutTransferObject entity);
    }
}
