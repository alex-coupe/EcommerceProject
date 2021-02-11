using Gateway.DataModels.Components;
using Gateway.DataTransfer.CartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels
{
    public class Checkout
    {
        public int Id { get; set; }
        public CartTransferObject Cart { get; set; }

        public decimal DeliveryCost { get; set; }

        public decimal DeliveryTax { get; set; }

        public decimal Total { get; set; }

        public PaymentInfo PaymentInfo { get; set; }

        public bool CheckoutSuccess { get; set; } = false;
    }
}
