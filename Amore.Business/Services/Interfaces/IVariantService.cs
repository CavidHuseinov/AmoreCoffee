using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Variant;

namespace Amore.Business.Services.Interfaces
{
    public interface IVariantService
    {
        Task<IEnumerable<GetVariantDto>> GetAllAsync();
        Task<GetVariantDto> GetByIdAsync (Guid Id);
        Task<GetVariantDto> CreateAsync(CreateVariantDto dto);
        Task UpdateAsync (UpdateVariantDto dto);
        Task RemoveAsync(Guid Id);
    }
}
