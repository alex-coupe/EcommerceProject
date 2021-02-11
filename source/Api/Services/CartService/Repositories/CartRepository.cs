using CartService.Interfaces;
using CartService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Repositories
{
    public class CartRepository : ICartRepository
    {
        private DatabaseContext _context;
        public CartRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Create(Cart cart)
        {
            _context.Carts.Add(cart);
        }

        public async Task<Cart> Get(string cartId)
        {
            return await  _context.Carts.AsNoTracking()
                .Where(x => x.Id == cartId)
                .Include(x => x.CartItems)
             .FirstOrDefaultAsync();
        }

        public void Remove(string cartId)
        {
            var cart = _context.Carts.Find(cartId);
            _context.Carts.Remove(cart);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Cart cart)
        {
            _context.Carts.Update(cart);
        }
    }
}
