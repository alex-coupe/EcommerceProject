using CartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> Get(string cartId);

        void Create(Cart cart);

        void Update(Cart cart);

        void Remove(string cartId);

        Task<int> SaveChanges();
    }
}
