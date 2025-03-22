using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Amore.Business.Helpers.DTOs.UploadFile
{
    public record CreateUploadFileDto
    {
        public IFormFile File { get; set; }
        public string FolderName { get; set; }


    }
}
