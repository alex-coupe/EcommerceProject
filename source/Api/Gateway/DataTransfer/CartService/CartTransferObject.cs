using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataTransfer.CartService
{
    public class CartTransferObject
    {
        public string Id { get; set; }

        public IEnumerable<CartItemTransferObject> CartItems { get; set; }

        public decimal Net { get; set; }

        public decimal Tax { get; set; }

        public decimal Gross { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
