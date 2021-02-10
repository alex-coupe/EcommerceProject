using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels.Components
{
    public class CartItem
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public string Sku { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal GrossPrice { get; set; }

        public decimal Tax { get; set; }

        public decimal NetPrice { get; set; }
    }
}
