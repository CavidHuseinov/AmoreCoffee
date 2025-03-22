using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;
using Microsoft.AspNetCore.Http;

namespace Amore.Business.Helpers.DTOs.Logo
{
    public record UpdateLogoDto:BaseDto
    {
        public string? ImgUrl { get; set; }

    }
}
