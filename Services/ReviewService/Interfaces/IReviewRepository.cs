using ReviewService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewService.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviews(int productId);

        void AddReview(Review review);

        Task<int> SaveChanges();
    }
}
