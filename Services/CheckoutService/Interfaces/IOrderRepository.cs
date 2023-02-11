using CheckoutService.Models;
using Gateway.DataTransfer.CheckoutService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutService.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        Task<int> SaveChanges();
    }
}
