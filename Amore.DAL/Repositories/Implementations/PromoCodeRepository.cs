using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;
using Amore.DAL.Context;
using Amore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace Amore.DAL.Repositories.Implementations
{
    public class PromocodeRepository : WriteRepository<Promocode>, IPromocodeRepository
    {

        public PromocodeRepository(AmoreDbContext context) : base(context)
        {
        }


    }
}
