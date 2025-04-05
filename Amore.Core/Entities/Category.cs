using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities.Common;

namespace Amore.Core.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string? ImgUrl { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
