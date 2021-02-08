using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Gateway.DataModels.Components;

namespace Gateway.DataModels
{
    public class CompositeProduct
    {
        public Product ProductDetails { get; set; }

        public IEnumerable<RelatedProduct> RelatedProducts { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public Inventory Inventory { get; set; }
    }
}
