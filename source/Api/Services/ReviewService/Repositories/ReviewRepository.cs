using Microsoft.EntityFrameworkCore;
using ReviewService.Interfaces;
using ReviewService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewService.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private DatabaseContext _context;

        public ReviewRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
        }

        public async Task<IEnumerable<Review>> GetReviews(int productId)
        {
            return await _context.Reviews.AsNoTracking()
               .Where(x => x.ProductId == productId)
               .ToListAsync();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
