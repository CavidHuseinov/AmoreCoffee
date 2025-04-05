using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.UploadFile
{
    public record GetUploadFileDto
    {
        public string? ImgUrl { get; set; }
    }
}
