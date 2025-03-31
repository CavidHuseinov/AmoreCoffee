using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.SocialMedia;

namespace Amore.Business.Services.Interfaces
{
    public interface ISocialMediaService
    {
        Task<IEnumerable<GetSocialMediaDto>> GetAllAsync();
        Task<GetSocialMediaDto> GetByIdAsync(Guid Id);
        Task<GetSocialMediaDto> CreateAsync(CreateSocialMediaDto dto);
        Task UpdateAsync(UpdateSocialMediaDto dto);
        Task RemoveAsync(Guid id);
    }
}
