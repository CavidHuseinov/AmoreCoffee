using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Category;

namespace Amore.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto> GetByIdAsync (Guid id);
        Task<GetCategoryDto> CreateAsync (CreateCategoryDto dto);
        Task UpdateAsync (UpdateCategoryDto dto);
        Task RemoveAsync(Guid id);
    }
}
