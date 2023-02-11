using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class ProductVariant
    {
        [Key]
        public int Sku { get; set; }

        public int ProductId { get; set; }

        public int Size { get; set; }
    }
}
