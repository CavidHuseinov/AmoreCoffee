using Amore.Business.Helpers.DTOs.Review;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetReviews(Guid productId)
        {
            var reviews = await _reviewService.GetReviewsByProductAsync(productId);
            return Ok(reviews);
        }

        [HttpGet("{productId}/average")]
        public async Task<IActionResult> GetAverageRating(Guid productId)
        {
            var rating = await _reviewService.GetAverageRatingAsync(productId);
            return Ok(new { AverageRating = rating });
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto reviewDto)
        {
            try
            {
                await _reviewService.CreateReviewAsync(reviewDto);
                return Ok(new { Message = "Rəy uğurla yaradıldı" });
            }
            catch(ReviewCannotBeCreated ex)
            {
                throw new ReviewCannotBeCreated(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{reviewId}/{userName}")]
        public async Task<IActionResult> DeleteReview(Guid reviewId, string userName)
        {
            try
            {
                await _reviewService.DeleteReviewAsync(reviewId, userName);
                return Ok(new { Message = "Rəy uğurla silindi" });
            }
            catch(ReviewCannotBeRemove ex)
            {
                throw new ReviewCannotBeRemove(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }



}
