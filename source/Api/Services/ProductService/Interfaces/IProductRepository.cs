using Gateway.DataTransfer.ProductService;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductTransferObject>> GetAll(string category, string subcategory);

        Task<ProductTransferObject> GetOne(string slug);

        void Create(Product product);

        void Update(Product product);

        void Remove(int id);

        Task<int> SaveChanges();
    }
}
