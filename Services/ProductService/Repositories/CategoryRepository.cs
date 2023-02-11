using Gateway.DataTransfer.ProductService;
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
        public void Create(CategoryTransferObject category)
        {
            var cat = new Category
            {
                Name = category.MainCategory,
                SubCategories = category.SubCategories.Select(sc => new SubCategory
                {
                    Name = sc
                }).ToList()
            };
            _context.Categories.Add(cat);
        }

        public async Task<IEnumerable<CategoryTransferObject>> GetAll()
        {
            return await _context.Categories.AsNoTracking()
                 .Include(x => x.SubCategories)
                 .Select(cat => new CategoryTransferObject
                 {
                     MainCategory = cat.Name,
                     SubCategories = cat.SubCategories.Select(x => x.Name).ToList()
                 }).ToListAsync();
        }
              

        public async Task<CategoryTransferObject> GetOne(string category)
        {
            return await _context.Categories.AsNoTracking()
                .Where(x => x.Name == category)
                .Include(x => x.SubCategories)
                .Select(cat => new CategoryTransferObject
                {
                    MainCategory = cat.Name,
                    SubCategories = cat.SubCategories.Select(x => x.Name).ToList()
                })
                .SingleOrDefaultAsync();
        }

        public void Remove(int id)
        {
            var category = _context.Categories.Find(id);
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
