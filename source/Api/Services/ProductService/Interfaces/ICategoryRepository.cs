using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();

        Task<Category> GetOne(string category);

        void Create(Category category);

        void Update(Category category);

        void Remove(Category category);

        Task<int> SaveChanges();
    }
}
