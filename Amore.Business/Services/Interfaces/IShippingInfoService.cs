using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.ShippingInfo;

namespace Amore.Business.Services.Interfaces
{
    public interface IShippingInfoService
    {
        Task<IEnumerable<GetShippingInfoDto>> GetAllAsync ();
        Task<GetShippingInfoDto> GetByIdAsync (Guid id);
        Task<GetShippingInfoDto> CreateAsync(CreateShippingInfoDto dto);
    }
}
