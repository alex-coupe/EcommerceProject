using Gateway.DataModels.Components;
using Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Caches
{
    public class CategoryCache : IDataCache<IEnumerable<Category>>
    {
        public bool Valid { get; set; } = false;
        public IEnumerable<Category> Cache { get; set; }
    }
}
