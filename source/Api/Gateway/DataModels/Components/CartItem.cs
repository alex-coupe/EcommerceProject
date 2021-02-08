using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels.Components
{
    public class CartItem
    {
        public string Sku { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal GrossPrice { get; set; }

        public decimal TaxPercentage { get; set; }

        public decimal NetPrice { get; set; }
    }
}
