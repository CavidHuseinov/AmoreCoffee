using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;
using Amore.Business.Helpers.DTOs.Product;

namespace Amore.Business.Helpers.DTOs.Tag
{
    public record GetTagDto:BaseDto
    {
        public string Name { get; set; }
    }
}
