using Amore.Core.Entities;
using Amore.DAL.Context;
using Amore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

public class ReviewRepository : IReviewRepository
{
    private readonly AmoreDbContext _context;

    public ReviewRepository(AmoreDbContext context)
    {
        _context = context;
    }

    public async Task<double> AverageRating(Guid productId)
    {
        return await _context.Reviews
            .Where(r => r.ProductId == productId)
            .AverageAsync(r => (double?)r.Rating) ?? 0;
    }

    public async Task CreateAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReviewAsync(Guid reviewId, string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("İstifadəçi adı boş ola bilməz!");

        var review = await _context.Reviews
            .FirstOrDefaultAsync(r => r.Id == reviewId && r.AppUserName == userName);

        if (review == null)
            throw new KeyNotFoundException("Rəy tapılmadı və ya silmə icazəniz yoxdur!");

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Review>> GetAllAsync(
        Expression<Func<Review, bool>>? predicate = null,
        Func<IQueryable<Review>, IIncludableQueryable<Review, object>>? include = null,
        Func<IQueryable<Review>, IOrderedQueryable<Review>>? orderBy = null,
        bool enableTracking = false) 
    {
        IQueryable<Review> query = _context.Reviews;

        if (!enableTracking)
            query = query.AsNoTracking(); 

        if (predicate != null)
            query = query.Where(predicate);

        if (include != null)
            query = include(query);

        if (orderBy != null)
            query = orderBy(query);

        return await query.ToListAsync();
    }
}
