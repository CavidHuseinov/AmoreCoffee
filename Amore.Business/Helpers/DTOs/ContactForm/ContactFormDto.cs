using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.ContactForm
{
    public record ContactFormDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
