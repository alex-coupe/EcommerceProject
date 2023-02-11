using RelatedProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelatedProductService.Interfaces
{
    public interface IRelatedProductRepository
    {
        Task<IEnumerable<RelatedProduct>> GetRelatedProducts(int productId);

        void AddRelatedProduct(RelatedProduct relatedProduct);

        Task<int> SaveChanges();
    }
}
