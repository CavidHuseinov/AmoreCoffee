﻿using Amore.Core.Entities;
using Amore.DAL.Context;
using Amore.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.DAL.Repositories.Implementations
{
    public class HeadBannerRepository : WriteRepository<HeadBanner>, IHeadBannerRepository
    {
        public HeadBannerRepository(AmoreDbContext context) : base(context)
        {
        }
    }
}
