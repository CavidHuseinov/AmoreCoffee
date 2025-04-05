using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities.Common;

namespace Amore.Core.Entities
{
    public class UserPromocode:BaseEntity
    {
        public Guid PromocodeId { get; set; }
        public Promocode? Promocode { get; set; }

        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
