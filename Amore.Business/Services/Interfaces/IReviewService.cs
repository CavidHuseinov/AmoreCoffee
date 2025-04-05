using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Review;
using Amore.Core.Entities;

namespace Amore.Business.Services.Interfaces
{
    public interface IReviewService
    {
        Task CreateReviewAsync(CreateReviewDto reviewDto);
        Task<IEnumerable<GetReviewDto>> GetReviewsByProductAsync(Guid productId);
        Task<double> GetAverageRatingAsync(Guid productId);
        Task DeleteReviewAsync(Guid reviewId, string userId);
    }
}
