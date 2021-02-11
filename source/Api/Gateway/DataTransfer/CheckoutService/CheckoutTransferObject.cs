using Gateway.DataTransfer.CartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataTransfer.CheckoutService
{
    public class CheckoutTransferObject
    {
        public int Id { get; set; }
        public CartTransferObject Cart { get; set; }

        public decimal DeliveryCost { get; set; }

        public decimal DeliveryTax { get; set; }

        public decimal Total { get; set; }

        public PaymentInfoTransferObject PaymentInfo { get; set; }

        public UserTransferObject Customer { get; set; }

        public bool CheckoutSuccess { get; set; } = false;
    }
}
