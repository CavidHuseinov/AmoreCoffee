using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.OrderProduct
{
    public record CreateOrderProductDto
    {
        public Guid TagId {  get; set; }
        public Guid ProductId { get; set; }
    }
}
