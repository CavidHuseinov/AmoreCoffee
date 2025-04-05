using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Tag;

namespace Amore.Business.Services.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<GetTagDto>> GetAllAsync();
        Task<GetTagDto> GetByIdAsync(Guid id);
        Task<GetTagDto> CreateAsync(CreateTagDto dto);
        Task UpdateAsync (UpdateTagDto dto);
        Task RemoveAsync (Guid id);

    }
}
