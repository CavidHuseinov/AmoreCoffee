using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;

namespace Amore.Business.Helpers.DTOs.Review
{
    public record GetReviewDto : BaseDto
    {
        public Guid ProductId { get; set; }
        public string UserName { get; set; } 
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

}
