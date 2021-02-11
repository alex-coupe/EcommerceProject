using Gateway.DataTransfer.ReviewService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Interfaces
{
    public interface IReviewServiceClient
    {
        Task<IEnumerable<ReviewTransferObject>> GetReviews(int productId);
    }
}
