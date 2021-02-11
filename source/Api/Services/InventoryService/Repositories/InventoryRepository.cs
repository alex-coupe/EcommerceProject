using InventoryService.Interfaces;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private DatabaseContext _context;
        public InventoryRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Create(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
        }

        public async Task<Inventory> Get(int Sku)
        {
            return await _context.Inventory.AsNoTracking()
                .Where(x => x.Sku == Sku)
                .FirstOrDefaultAsync();
        }

        public void Remove(int Sku)
        {
            var item = _context.Inventory.Find(Sku);
            _context.Inventory.Remove(item);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Inventory inventory)
        {
            _context.Inventory.Update(inventory);
        }
    }
}
