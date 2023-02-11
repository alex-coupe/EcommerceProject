using Microsoft.EntityFrameworkCore;
using RelatedProductService.Interfaces;
using RelatedProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelatedProductService.Repositories
{
    public class RelatedProductRepository : IRelatedProductRepository
    {
        private DatabaseContext _context;
        public RelatedProductRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddRelatedProduct(RelatedProduct relatedProduct)
        {
            _context.RelatedProducts.Add(relatedProduct);
        }

        public async Task<IEnumerable<RelatedProduct>> GetRelatedProducts(int productId)
        {
            return await _context.RelatedProducts.AsNoTracking()
                .Where(x => x.ProductId == productId)
                .ToListAsync();
                
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
