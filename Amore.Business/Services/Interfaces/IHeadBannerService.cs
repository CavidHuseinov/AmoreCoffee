using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.HeadBanner;
using Amore.Core.Entities;

namespace Amore.Business.Services.Interfaces
{
    public interface IHeadBannerService
    {
        Task <IEnumerable<GetHeadBannerDto>> GetAllAsync();
        Task<GetHeadBannerDto> GetById(Guid id);
        Task<GetHeadBannerDto> Create(CreateHeadBannerDto dto);
        Task Update (UpdateHeadBannerDto dto);
        Task Remove (Guid id);
    }
}
