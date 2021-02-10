using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Interfaces
{
    public interface IProductServiceClient
    {
        public Task<decimal> GetItemBasePrice(int Sku);
    }
}
