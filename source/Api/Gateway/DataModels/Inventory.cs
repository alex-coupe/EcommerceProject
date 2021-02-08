using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels
{
    public class Inventory
    {
        public string Id { get; set; }

        public int CurrentStock { get; set; }

        public string TimeToRestock { get; set; }
    }
}
