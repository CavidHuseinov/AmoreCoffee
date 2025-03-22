using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.HeadBanner;
using Amore.Business.Helpers.DTOs.UploadFile;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Helpers.Extensions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Implementations;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace Amore.Business.Services.Implementations
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IWebHostEnvironment _env;

        public UploadFileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<GetUploadFileDto> UploadFileAsync(CreateUploadFileDto fileUploadDto)
        {
            if (fileUploadDto.File == null || fileUploadDto.File.Length == 0)
            {
                throw new FileUploadNotFoundException();
            }

            if (string.IsNullOrWhiteSpace(fileUploadDto.FolderName))
            {
                throw new FolderNameNotFoundException();
            }
            string imgUrl = fileUploadDto.File.Upload(_env.WebRootPath, fileUploadDto.FolderName);

            return new GetUploadFileDto
            {
                ImgUrl = imgUrl
            };

        }

    }

}
