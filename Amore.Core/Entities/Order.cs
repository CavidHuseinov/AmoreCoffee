using System.Collections.Generic;
using Amore.Core.Entities.Common;
using Amore.Core.Enums;

namespace Amore.Core.Entities
{
    public class Order : BaseEntity
    {


        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
