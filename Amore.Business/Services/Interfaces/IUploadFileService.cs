using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.HeadBanner;
using Amore.Business.Helpers.DTOs.UploadFile;

namespace Amore.Business.Services.Interfaces
{
    public interface IUploadFileService
    {
        Task<GetUploadFileDto> UploadFileAsync(CreateUploadFileDto fileUploadDto);
    }
}
