using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataTransfer.InventoryService
{
    public class InventoryTransferObject
    {
        public int Sku { get; set; }

        public int TotalStock { get; set; }

        public int ReservedStock { get; set; }

        public int AvailableStock { get; set; }

        public string TimeToRestock { get; set; }

        public string TransactionType { get; set; }

        public int TransactionCount { get; set; }
    }
}
