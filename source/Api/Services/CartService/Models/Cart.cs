using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public decimal Net { get; set; }

        [Required]
        public decimal Tax { get; set; }

        [Required]
        public decimal Gross { get; set; }

        [Required]
        public int ItemCount { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
