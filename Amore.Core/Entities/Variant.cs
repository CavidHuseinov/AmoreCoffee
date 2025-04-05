using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities.Common;

namespace Amore.Core.Entities
{
    public class Variant:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductVariant>? ProductVariants { get; set; }  
    }
}
