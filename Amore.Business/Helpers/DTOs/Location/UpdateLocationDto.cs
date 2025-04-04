﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;

namespace Amore.Business.Helpers.DTOs.Location
{
    public record UpdateLocationDto:BaseDto
    {
        public string Title { get; set; }
        public string LocationName { get; set; }
        public string Number { get; set; }
        public string EmailAdress { get; set; }

    }
}
