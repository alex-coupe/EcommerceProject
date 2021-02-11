using System.Collections.Generic;
using Gateway.DataTransfer.InventoryService;
using Gateway.DataTransfer.ProductService;
using Gateway.DataTransfer.RelatedProductService;
using Gateway.DataTransfer.ReviewService;

namespace Gateway.DataTransfer.ProductService
{
    public class CompositeProduct
    {
        public ProductTransferObject ProductDetails { get; set; }

        public IEnumerable<ProductTransferObject> RelatedProducts { get; set; }

        public IEnumerable<ReviewTransferObject> Reviews { get; set; }

        public IEnumerable<InventoryTransferObject> Inventory { get; set; }
    }
}
