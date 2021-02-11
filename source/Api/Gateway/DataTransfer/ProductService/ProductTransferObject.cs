﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataTransfer.ProductService
{
    public class ProductTransferObject
    {
        public string Name { get; set; }

        public int Sku { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public string Slug { get; set; }
        public string AltText { get; set; }

        public string ImagePath { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }

    }
}