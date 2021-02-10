using Microsoft.EntityFrameworkCore;
using ProductService.Interfaces;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public void Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAll(string category, string subcategory)
        {
            return await _context.Products.AsNoTracking()
                .Where(prod => prod.Categories.Where(cat => cat.Name == category).Any() 
                && prod.SubCategories.Where(sub => sub.Name == subcategory).Any())
                .ToListAsync();
        }

        public async Task<Product> GetOne(string slug)
        {
            return await _context.Products.AsNoTracking()
                .Where(x => x.Slug == slug)
                .Include(x => x.ProductImage)
                .FirstOrDefaultAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }
    }
}
