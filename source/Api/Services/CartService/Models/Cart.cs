using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CartService.Models
{
    public class Cart
    {
        public string Id { get; set; }

        [JsonIgnore]
        public IEnumerable<CartItem> CartItems { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Net { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Tax { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Gross { get; set; }

        [Required]
        public int ItemCount { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
