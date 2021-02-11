using Gateway.DataModels.Components;
using Gateway.DataTransfer.CartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels
{
    public class OrderConfirmation
    {
        public int Id { get; set; }

        public IEnumerable<CartItem> OrderItems { get; set; }

        public decimal DeliveryCost { get; set; }

        public decimal DeliveryTax { get; set; }

        public decimal Total { get; set; }

        public DateTime OrderDate { get; set; }

    }
}
