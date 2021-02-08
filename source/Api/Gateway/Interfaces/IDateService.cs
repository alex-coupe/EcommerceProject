using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Interfaces
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll(string parameter);
        Task<T> Get(string slug);

        Task<T> Post(T entity);

        Task<T> Put(T entity);

        Task Delete(string slug);
    }
}
