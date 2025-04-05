using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;
using Amore.Business.Helpers.DTOs.UserPromocode;

namespace Amore.Business.Helpers.DTOs.User
{
    public record UserDto:BaseDto
    {
        public string UserName { get; set; }
        public string? ImgUrl { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public ICollection<GetUserPromocodeDto>? UserPromocodes {  get; set; }
    }
}
