using System.Collections.Generic;
using Amore.Business.Helpers.DTOs.Common;
using Amore.Business.Helpers.DTOs.OrderProduct;
using Amore.Business.Helpers.DTOs.Product;
using Amore.Core.Enums;  // Product DTO'yu ekledik

namespace Amore.Business.Helpers.DTOs.Order
{
    public record GetOrderDto : BaseDto
    {

        public ICollection<GetOrderProductDto>? OrderProducts { get; set; }
    }
}
