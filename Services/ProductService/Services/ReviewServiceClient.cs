using Gateway.DataTransfer.ReviewService;
using Gateway.Interfaces;
using ProductService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class ReviewServiceClient : IReviewServiceClient
    {
        private IHttpService _httpService;
        private string baseUri = "http://review_service:5007/";

        public ReviewServiceClient(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<ReviewTransferObject>> GetReviews(int productId)
        {
            return await _httpService.Get<IEnumerable<ReviewTransferObject>>($"{baseUri}api/reviewservice/v1/GetReviews?productId={productId}");
        }
    }
}
