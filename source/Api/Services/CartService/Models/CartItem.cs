using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public string CartId { get; set; }

        public virtual Cart Cart { get; set; }
        public int Sku { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal GrossPrice { get; set; }

        public decimal Tax { get; set; }

        public decimal NetPrice { get; set; }
    }
}
