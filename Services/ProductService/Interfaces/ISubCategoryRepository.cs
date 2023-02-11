using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Interfaces
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetAll();

        Task<SubCategory> GetOne(int id);

        void Create(SubCategory subCategory);

        void Update(SubCategory subCategory);

        void Remove(int id);

        Task<int> SaveChanges();
    }
}
