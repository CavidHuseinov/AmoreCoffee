using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Product;

namespace Amore.Business.Helpers.DTOs.OrderProduct
{
    public record GetOrderProductDto
    {
        public Guid Id {  get; set; }
        public Guid ProductId { get; set; }

        public GetProductDto Product { get; set; }
    }
}
