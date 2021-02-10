using Microsoft.EntityFrameworkCore;
using ProductService.Interfaces;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private DatabaseContext _context;
        public ImageRepository(DatabaseContext context)
        {
            _context = context;        
        }

        public void Create(Image image)
        {
            _context.Images.Add(image);
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            return await _context.Images.AsNoTracking()
                .ToListAsync();
        }

        public async Task<Image> GetOne(int Id)
        {
            return await _context.Images.AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public void Remove(int id)
        {
            var image = _context.Images.Find(id);
            _context.Images.Remove(image);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Image image)
        {
            _context.Images.Update(image);
        }
    }
}
