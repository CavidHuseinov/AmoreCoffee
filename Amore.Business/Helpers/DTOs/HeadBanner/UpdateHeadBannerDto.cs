using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;
using Amore.Core.Entities.Common;

namespace Amore.Business.Helpers.DTOs.HeadBanner
{
    public record UpdateHeadBannerDto:BaseDto
    {
        public string Description { get; set; }

    }
}
