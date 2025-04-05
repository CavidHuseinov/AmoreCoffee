using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.User
{
    public record ForgotPasswordDto
    {
        public string Email { get; set; }
    }
}
