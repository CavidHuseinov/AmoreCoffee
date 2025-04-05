using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Promocode;

namespace Amore.Business.Helpers.DTOs.UserPromocode
{
    public class GetUserPromocodeDto
    {
        public Guid Id {  get; set; }
        public Guid PromocodeId { get; set; }
        public GetPromocodeDto? Promocode { get; set; }
    }
}
