using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class Product
    {
        [Required]
        [MinLength(50)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Sku { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(50)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal UnitPrice { get; set; }
        
        [Key]
        public string Slug { get; set; }

        [Required]
        public Image ProductImage { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}
