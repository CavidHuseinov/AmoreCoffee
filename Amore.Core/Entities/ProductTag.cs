﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Core.Entities
{
    public class ProductTag
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public Guid TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
