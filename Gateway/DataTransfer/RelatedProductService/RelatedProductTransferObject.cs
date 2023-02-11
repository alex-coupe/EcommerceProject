using Gateway.DataTransfer.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataTransfer.RelatedProductService
{
    public class RelatedProductTransferObject
    {
        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }
    }
}
