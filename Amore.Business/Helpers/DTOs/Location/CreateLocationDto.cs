using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.Location
{
    public record CreateLocationDto
    {
        public string Title { get; set; }
        public string LocationName { get; set; }
        public string Number { get; set; }
        public string EmailAdress { get; set; }
    }
}
