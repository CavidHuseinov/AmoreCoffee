using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;
using Microsoft.AspNetCore.Http;

namespace Amore.Business.Helpers.DTOs.Slider
{
    public record UpdateSliderDto:BaseDto
    {
        public string? ImgUrl { get; set; }
    }
}
