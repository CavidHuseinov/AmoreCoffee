    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Amore.Business.Helpers.DTOs.UserPromocode
    {
        public class CreateUserPromocodeDto
        {
            public Guid PromocodeId {  get; set; }
            public string AppUserName {  get; set; }
        }
    }
