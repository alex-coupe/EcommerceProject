using Gateway.DataModels;
using Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Caches
{
    public class CartCache : IDataCache<Cart>
    {
        public bool Valid { get; set; } = false;
        public Cart Cache { get; set; }
    }
}
