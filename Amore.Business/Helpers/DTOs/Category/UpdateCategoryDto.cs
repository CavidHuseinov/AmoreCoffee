using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;

namespace Amore.Business.Helpers.DTOs.Category
{
    public record UpdateCategoryDto:BaseDto
    {
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public ICollection<Guid>? ProductId { get; set; }
    }
}
