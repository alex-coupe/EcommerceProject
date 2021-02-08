using Gateway.DataModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels
{
    public class Cart
    {
        public string Id { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }

        public decimal Net { get; set; }

        public decimal Tax { get; set; }

        public decimal Gross { get; set; }
    }
}
