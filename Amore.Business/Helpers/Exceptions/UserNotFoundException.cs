using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string? message="Istifadeci tapilmadi") : base(message)
        {
        }
    }
}
