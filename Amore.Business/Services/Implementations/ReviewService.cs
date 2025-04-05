using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Review;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Amore.Business.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    namespace Amore.Business.Services.Implementations
    {
        public class ReviewService : IReviewService
        {
            private readonly IReviewRepository _reviewRepository;
            private readonly IReadRepository<Review> _readRepository;

            public ReviewService(IReviewRepository reviewRepository, IReadRepository<Review> readRepository)
            {
                _reviewRepository = reviewRepository;
                _readRepository = readRepository;
            }

            public async Task CreateReviewAsync(CreateReviewDto reviewDto)
            {
                if (reviewDto.Rating < 1 || reviewDto.Rating > 5)
                    throw new ArgumentException("1 ilə 5 arasında dəyərləndirin zəhmət olmasa");

                if (string.IsNullOrWhiteSpace(reviewDto.Comment))
                    throw new ArgumentException("Rəy hissəsi boş ola bilməz.");

                if (reviewDto.Comment.Length > 500)
                    throw new ArgumentException("Rəy hissəsi ən çox 500 simvol ola bilər.");

                if (reviewDto.ProductId == Guid.Empty)
                    throw new ArgumentException("Məhsulun İD'si boş ola bilməz");

                if (string.IsNullOrWhiteSpace(reviewDto.UserName))
                    throw new ArgumentException("İstifadəçi adı boş ola bilməz.");

                var review = new Review
                {
                    Id = Guid.NewGuid(),
                    ProductId = reviewDto.ProductId,
                    AppUserName = reviewDto.UserName, 
                    Rating = reviewDto.Rating,
                    Comment = reviewDto.Comment,
                    CreatedAt = DateTime.UtcNow
                };

                await _reviewRepository.CreateAsync(review);
            }

            public async Task<IEnumerable<GetReviewDto>> GetReviewsByProductAsync(Guid productId)
            {
                var reviews = await _readRepository.GetAllAsync(
                    r => r.ProductId == productId,
                    include: q => q.Include(r => r.AppUser)
                );

                return reviews.Select(r => new GetReviewDto
                {
                    ProductId = r.ProductId,
                    UserName = r.AppUserName, 
                    Rating = r.Rating,
                    Comment = r.Comment,
                    Id = r.Id,
                });
            }

            public async Task<double> GetAverageRatingAsync(Guid productId)
            {
                return await _reviewRepository.AverageRating(productId);
            }

            public async Task DeleteReviewAsync(Guid reviewId, string userName)
            {
                await _reviewRepository.DeleteReviewAsync(reviewId, userName);
            }
        }
    }

}
