using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amore.DAL.Repositories.Interfaces
{
    public interface IReviewRepository
    {
         Task CreateAsync(Review review);
         Task<double> AverageRating(Guid productId);
         Task DeleteReviewAsync(Guid reviewId, string userId);
         
    }
}
