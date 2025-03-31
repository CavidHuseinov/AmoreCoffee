using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Location;

namespace Amore.Business.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<GetLocationDto>> GetAllAsync();
        Task<GetLocationDto> GetByIdAsync(Guid id);
        Task<GetLocationDto> CreateAsync(CreateLocationDto dto);
        Task UpdateAsync(UpdateLocationDto dto);
        Task RemoveAsync(Guid id);
    }
}
