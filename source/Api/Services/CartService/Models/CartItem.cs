using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CartId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Cart Cart { get; set; }

        [Required]
        public int Sku { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal GrossPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Tax { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal NetPrice { get; set; }
    }
}
