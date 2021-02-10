using Microsoft.EntityFrameworkCore;
using ProductService.Interfaces;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private DatabaseContext _context;

        public SubCategoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(SubCategory subCategory)
        {
            _context.SubCategories.Add(subCategory);
        }

        public async Task<IEnumerable<SubCategory>> GetAll()
        {
            return await _context.SubCategories.AsNoTracking()
                .ToListAsync();
        }

        public async Task<SubCategory> GetOne(int id)
        {
            return await _context.SubCategories.AsNoTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public void Remove(int id)
        {
            var subCategory = _context.SubCategories.Find(id);
            _context.SubCategories.Remove(subCategory);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(SubCategory subCategory)
        {
            _context.SubCategories.Update(subCategory);
        }
    }
}
