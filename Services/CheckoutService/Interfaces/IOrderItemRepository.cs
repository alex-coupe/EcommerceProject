using Gateway.DataTransfer.CartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutService.Interfaces
{
    public interface IOrderItemRepository
    {
        void Create(CartTransferObject cartTransferObject, int orderId);
        Task<int> SaveChanges();
    }
}
