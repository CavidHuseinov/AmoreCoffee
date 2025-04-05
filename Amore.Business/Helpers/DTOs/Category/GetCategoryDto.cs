using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;
using Amore.Business.Helpers.DTOs.Product;

namespace Amore.Business.Helpers.DTOs.Category
{
    public record GetCategoryDto:BaseDto
    {
        public string ImgUrl {  get; set; }
        public string Name { get; set; }
        public ICollection<GetProductDto>? Products {  get; set; }
    }
}
