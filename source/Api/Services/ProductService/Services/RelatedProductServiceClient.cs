using Gateway.DataTransfer.RelatedProductService;
using Gateway.Interfaces;
using ProductService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class RelatedProductServiceClient : IRelatedProductServiceClient
    {
        private IHttpService _httpService;
        private string baseUri = "http://relatedproduct_service:5006/";

        public RelatedProductServiceClient(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<IEnumerable<RelatedProductTransferObject>> GetRelatedProducts(int productId)
        {
            return await _httpService.Get<IEnumerable<RelatedProductTransferObject>>($"{baseUri}api/relatedproductservice/v1/GetRelatedProducts?productId={productId}");
        }
    }
}
