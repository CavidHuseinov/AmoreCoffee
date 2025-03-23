using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Amore.Business.Helpers.DTOs.Slider
{
    public record CreateSliderDto
    {
        public string? ImgUrl { get; set; }

    }
}
