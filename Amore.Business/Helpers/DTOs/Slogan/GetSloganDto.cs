﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;

namespace Amore.Business.Helpers.DTOs.Slogan
{
    public record GetSloganDto:BaseDto
    {
        public string Description { get; set; }
    }
}
