using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Gateway.DataModels.Components;
using Gateway.DataTransfer.InventoryService;
using Gateway.DataTransfer.ProductService;

namespace Gateway.DataModels
{
    public class CompositeProduct
    {
        public ProductTransferObject ProductDetails { get; set; }

        public IEnumerable<RelatedProduct> RelatedProducts { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public InventoryTransferObject Inventory { get; set; }
    }
}
