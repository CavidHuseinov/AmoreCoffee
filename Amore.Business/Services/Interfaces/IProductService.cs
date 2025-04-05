using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Product;

namespace Amore.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<GetProductDto>> GetAllAsync();
        Task<GetProductDto> GetByIdAsync(Guid Id);
        Task<GetProductDto> CreateAsync(CreateProductDto dto);
        Task UpdateAsync (UpdateProductDto dto);
        Task RemoveAsync (Guid id);
    }
}
