using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;
using Amore.Core.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace Amore.DAL.Repositories.Interfaces
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>>? GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                bool enableTracking = true);

        Task<IEnumerable<TEntity>> GetByPagingAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                    bool enableTracking = true,
                                                    int pageIndex = 1,
                                                    int pageSize = 10);

    }
}
