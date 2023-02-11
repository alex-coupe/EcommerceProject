using CartService.Interfaces;
using CartService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private DatabaseContext _context;

        public CartItemRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Create(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
        }

        public void Update(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
        }

        public EntityState GetEntityState(CartItem item)
        {
            return _context.Entry(item).State;
        }
    }
}
