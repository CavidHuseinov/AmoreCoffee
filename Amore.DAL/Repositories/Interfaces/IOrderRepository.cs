using Amore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amore.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IWriteRepository<Order>
    {
        Task<IEnumerable<Order>> GetUserOrdersAsync(string userId);
    }
}
