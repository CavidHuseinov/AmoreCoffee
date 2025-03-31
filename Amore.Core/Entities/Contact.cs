using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities.Common;

namespace Amore.Core.Entities
{
    public class Contact:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment {  get; set; }
    }
}
