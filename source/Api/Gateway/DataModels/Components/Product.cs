using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels.Components
{
    public class Product
    {
        public string Name { get; set; }

        public string Sku { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Slug { get; set; }
        public Image ProductImage { get; set; }
        public Category Category { get; set; } 
    }
}
