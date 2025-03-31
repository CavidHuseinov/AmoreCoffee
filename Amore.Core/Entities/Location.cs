using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities.Common;

namespace Amore.Core.Entities
{
    public class Location:BaseEntity
    {
        public string Title { get; set; }
        public string LocationName {  get; set; }
        public string Number { get; set; }
        public string EmailAdress { get; set; }


    }
}
