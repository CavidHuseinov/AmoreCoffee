using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Promocode;
using Amore.Business.Helpers.DTOs.User;

namespace Amore.Business.Services.Interfaces
{
    public interface IPromocodeService
    {
        Task<GetPromocodeDto> CreateAsync(CreatePromocodeDto dto);
        Task<GetPromocodeDto> GetByIdAsync(Guid id);
        Task<bool> ValidatePromocodeAsync(string code);
        Task<GetPromocodeDto?> GetPromocodeAsync(string code);
        Task<ICollection<GetPromocodeDto>> GetAllAsync();
        Task<GetPromocodeDto> UsePromocodeAsync(string userId, string PromocodeCode);
    }
}
