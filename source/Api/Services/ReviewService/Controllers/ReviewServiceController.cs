using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewService.Interfaces;
using ReviewService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewServiceController : ControllerBase
    {
        IReviewRepository _reviewRepository;
        public ReviewServiceController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        [Route("v1/GetReviews")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews(int productId)
        {
            var reviews = await _reviewRepository.GetReviews(productId);

            return Ok(reviews);
        }

        [HttpPost]
        [Route("v1/PostReview")]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _reviewRepository.AddReview(review);

            await _reviewRepository.SaveChanges();

            return Created("PostReview",review);
        }
    }
}
