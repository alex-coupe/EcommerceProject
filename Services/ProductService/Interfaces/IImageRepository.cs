using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Interfaces
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetAll();

        Task<Image> GetOne(int Id);

        void Create(Image image);

        void Update(Image image);

        void Remove(int id);

        Task<int> SaveChanges();
    }
}
