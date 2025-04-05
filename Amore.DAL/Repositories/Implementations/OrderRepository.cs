using Amore.Core.Entities;
using Amore.DAL.Context;
using Amore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amore.DAL.Repositories.Implementations
{
    public class OrderRepository : WriteRepository<Order>, IOrderRepository
    {
        private readonly AmoreDbContext _context;

        public OrderRepository(AmoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(string userId)
        {
            return await _context.Orders
                .Where(o => o.AppUserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
