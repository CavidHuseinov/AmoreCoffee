using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Amore.Core.Entities
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public GenderOption Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? ImgUrl { get; set; } = "ProfilePhoto.png";
        public IEnumerable<Review>? Reviews { get; set; }
        public IEnumerable<Checkout>? Checkouts { get; set; }
        public IEnumerable<UserPromocode>? UserPromocodes { get; set; }
    }
}
