using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Sku { get; set; }

        public int TotalStock { get; set; }

        public int ReservedStock { get; set; }

        public string DeliveryTime { get; set; }
    }
}
