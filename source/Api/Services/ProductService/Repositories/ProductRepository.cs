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

        public async Task<IEnumerable<ProductTransferObject>> GetAll(string category, string subcategory)
        {
            return await _context.Products.AsNoTracking()
                .Where(prod => prod.Category == category && prod.SubCategory == subcategory)
                .Include(i => i.ProductImage)
                .Select(x => new ProductTransferObject
                {
                    Name = x.Name,
                    Description = x.Description,
                    AltText = x.ProductImage.AltText,
                    ImagePath = $"{x.ProductImage.FilePath}{x.ProductImage.FileName}",
                    Sku = x.Sku,
                    Slug = x.Slug,
                    UnitPrice = x.UnitPrice,
                    Category = x.Category,
                    SubCategory = x.SubCategory
                })
                .ToListAsync();
        }

        public async Task<ProductTransferObject> GetOne(string slug)
        {
            return await _context.Products.AsNoTracking()
                .Where(x => x.Slug == slug)
                .Include(x => x.ProductImage)
                .Select(x => new ProductTransferObject
                {
                    Name = x.Name,
                    Description = x.Description,
                    AltText = x.ProductImage.AltText,
                    ImagePath = $"{x.ProductImage.FilePath}{x.ProductImage.FileName}",
                    Sku = x.Sku,
                    Slug = x.Slug,
                    UnitPrice = x.UnitPrice,
                    Category = x.Category,
                    SubCategory = x.SubCategory
                })
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
