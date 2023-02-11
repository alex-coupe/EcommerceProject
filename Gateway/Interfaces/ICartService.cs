using Gateway.DataTransfer.CartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Interfaces
{
    public interface ICartService
    {
        Task<CartTransferObject> Get(string slug);
        Task<CartTransferObject> Post(CartTransferObject entity);
    }
}
