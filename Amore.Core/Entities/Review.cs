using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities.Common;

namespace Amore.Core.Entities
{
    public class Review : BaseEntity
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public string AppUserName { get; set; } 
        public AppUser? AppUser { get; set; }
    }

}
