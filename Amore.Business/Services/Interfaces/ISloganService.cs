using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Slogan;

namespace Amore.Business.Services.Interfaces
{
    public interface ISloganService
    {
        Task<GetSloganDto> GetByIdAsync(Guid id);
        Task<IEnumerable<GetSloganDto>> GetAllAsync();
        Task<GetSloganDto> CreateAsync(CreateSloganDto dto);
        Task UpdateAsync(UpdateSloganDto dto);
        Task RemoveAsync(Guid id);
    }
}
