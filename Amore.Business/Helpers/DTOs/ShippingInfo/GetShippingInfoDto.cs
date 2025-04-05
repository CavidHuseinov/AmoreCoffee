using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;

namespace Amore.Business.Helpers.DTOs.ShippingInfo
{
    public record GetShippingInfoDto:BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string StreetAdress { get; set; }
        public string Apartment { get; set; }
    }
}
