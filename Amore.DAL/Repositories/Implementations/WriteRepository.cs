using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities.Common;
using Amore.DAL.Context;
using Amore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Amore.DAL.Repositories.Implementations
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity, new()
    {
       private readonly AmoreDbContext _context;

        public WriteRepository(AmoreDbContext context)
        {
            _context = context;
        }
        private DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => Table.Remove(entity));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => Table.Update(entity));
            await _context.SaveChangesAsync();
        }
    }
}
