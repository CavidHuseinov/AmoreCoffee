using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;

namespace Amore.Business.Helpers.DTOs.ContactForm
{
    public record NotificationDto:BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public bool IsRead { get; set; }= false;

    }
}
