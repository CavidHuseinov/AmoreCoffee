using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Slider;

namespace Amore.Business.Services.Interfaces
{
    public interface ISliderService
    {
        Task<IEnumerable<GetSliderDto>> GetAllAsync();
        Task<GetSliderDto> GetByIdAsync(Guid id);
        Task<GetSliderDto> CreateAsync(CreateSliderDto dto);
        Task UpdateAsync(UpdateSliderDto dto);
        Task RemoveAsync(Guid id);
    }
}
