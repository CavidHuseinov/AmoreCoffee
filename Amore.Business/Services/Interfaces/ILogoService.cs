using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Logo;

namespace Amore.Business.Services.Interfaces
{
    public interface ILogoService
    {
        Task<IEnumerable<GetLogoDto>> GetAllAsync();
        Task<GetLogoDto> GetByIdAsync(Guid id);
        Task<GetLogoDto> CreateAsync(CreateLogoDto dto);
        Task UpdateAsync(UpdateLogoDto dto);
        Task RemoveAsync(Guid id);
    }
}
