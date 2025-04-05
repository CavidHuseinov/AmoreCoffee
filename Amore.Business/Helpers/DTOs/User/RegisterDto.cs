using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Enums;

namespace Amore.Business.Helpers.DTOs.User
{
    public record RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderOption Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? ImgUrl { get; set; } = "ProfilePhoto.png";
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
