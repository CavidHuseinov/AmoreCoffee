﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;
using Amore.DAL.Context;
using Amore.DAL.Repositories.Interfaces;

namespace Amore.DAL.Repositories.Implementations
{
    public class ProductRepository : WriteRepository<Product>, IProductRepository
    {
        public ProductRepository(AmoreDbContext context) : base(context)
        {

        }
    }
}
