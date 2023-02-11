using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Interfaces
{
    public interface IInventoryRepository
    {
        Task<Inventory> Get(int Sku);
        Task<IEnumerable<Inventory>> GetAll(int id);

        void Create(Inventory inventory);

        void Update(Inventory inventory);

        void Remove(int Sku);

        Task<int> SaveChanges();
    }
}
