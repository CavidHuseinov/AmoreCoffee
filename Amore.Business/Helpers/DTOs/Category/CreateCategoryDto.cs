using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.Category
{
    public record CreateCategoryDto
    {
        public string ImgUrl { get; set; }
        public string Name { get; set; }
    }
}
