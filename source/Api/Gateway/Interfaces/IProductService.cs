using Gateway.DataTransfer.ProductService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Interfaces
{
    public interface IProductService
    {
        Task Delete(string slug);
        Task<CompositeProduct> Get(string slug);

        Task<IEnumerable<ProductTransferObject>> GetAll(string[] parameters);

        Task<ProductTransferObject> Post(CompositeProduct entity);
        Task<ProductTransferObject> PostForm(IFormFile file, ProductTransferObject product);
        Task<ProductTransferObject> Put(ProductTransferObject entity);

    }
}
