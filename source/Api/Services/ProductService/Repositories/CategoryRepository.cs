using Microsoft.EntityFrameworkCore;
using ProductService.Interfaces;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DatabaseContext _context;
        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Create(Category category)
        {
            _context.Categories.Add(category);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.AsNoTracking()
                .Include(x => x.SubCategories)
                .ToListAsync();
        }

        public async Task<Category> GetOne(string category)
        {
            return await _context.Categories.AsNoTracking()
                .Where(x => x.BaseCategory == category)
                .Include(x => x.SubCategories)
                .SingleOrDefaultAsync();
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Category category)
        {
            _context.Update(category);
        }
    }
}
