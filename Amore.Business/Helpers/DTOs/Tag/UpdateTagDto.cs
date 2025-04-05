using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;

namespace Amore.Business.Helpers.DTOs.Tag
{
    public record UpdateTagDto:BaseDto
    {
        public string Name { get; set; }
        public ICollection<Guid>? TagIds { get; set; }
    }
}
