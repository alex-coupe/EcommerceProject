using CheckoutService.Interfaces;
using CheckoutService.Models;
using Gateway.DataTransfer.CartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutService.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private DatabaseContext _context;
        public OrderItemRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Create(CartTransferObject cartTransferObject, int orderId)
        {
            foreach (var item in cartTransferObject.CartItems)
            {
                _context.OrderItems.Add(new OrderItem
                {
                    GrossPrice = item.GrossPrice,
                    Name = item.Name,
                    NetPrice = item.NetPrice,
                    OrderId = orderId,
                    Quantity = item.Quantity,
                    Sku = item.Sku,
                    Tax = item.Tax,
                    UnitPrice = item.UnitPrice
                });
            }
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
