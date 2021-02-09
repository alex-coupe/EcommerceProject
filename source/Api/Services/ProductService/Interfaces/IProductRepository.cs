using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll(string category);

        Task<Product> GetOne(string slug);

        void Create(Product product);

        void Update(Product product);

        void Remove(Product product);

        Task<int> SaveChanges();
    }
}
