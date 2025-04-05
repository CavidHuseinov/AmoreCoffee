using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities.Common;

namespace Amore.Core.Entities
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductTag>? Products { get; set; }
    }
}
