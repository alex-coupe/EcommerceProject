using Gateway.DataTransfer.RelatedProductService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Interfaces
{
    public interface IRelatedProductServiceClient
    {
        Task<IEnumerable<RelatedProductTransferObject>> GetRelatedProducts(int productId);
    }
}
