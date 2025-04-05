using Amore.Business.Helpers.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amore.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<GetOrderDto>> GetAllAsync();
        Task<GetOrderDto> GetByIdAsync(Guid id);
        Task<GetOrderDto> CreateAsync(CreateOrderDto dto);
        Task<IEnumerable<GetOrderDto>> GetUserOrdersAsync(string userId);
    }
}
