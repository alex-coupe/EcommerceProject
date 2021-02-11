using CheckoutService.Interfaces;
using CheckoutService.Models;
using Gateway.DataTransfer.CheckoutService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DatabaseContext _context;
        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(Order order)
        {
            _context.Orders.Add(order);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
