using Gateway.DataTransfer.CartService;
using Gateway.DataTransfer.CheckoutService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Interfaces
{
    public interface ICheckoutService
    {

        Task<OrderConfirmationTransferObject> PostOrder(CheckoutTransferObject checkoutTransferObject);
    }
}
