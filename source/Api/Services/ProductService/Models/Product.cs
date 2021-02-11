using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class Product
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public IEnumerable<ProductVariant> Sizes { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(20)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal UnitPrice { get; set; }
        
        [Required]
        public string Slug { get; set; }

        public int ProductImageId { get; set; }

        [JsonIgnore]
        public Image ProductImage { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public string SubCategory { get; set; }
    }
}
