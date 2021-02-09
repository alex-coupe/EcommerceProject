﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels.Components
{
    public class Category
    {
        public int Id { get; set; }
        public string BaseCategory { get; set; }

        public IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
