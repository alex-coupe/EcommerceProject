using Gateway.DataTransfer.ProductService;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryTransferObject>> GetAll();

        Task<CategoryTransferObject> GetOne(string category);

        void Create(CategoryTransferObject category);

        void Update(Category category);

        void Remove(int id);

        Task<int> SaveChanges();
    }
}
