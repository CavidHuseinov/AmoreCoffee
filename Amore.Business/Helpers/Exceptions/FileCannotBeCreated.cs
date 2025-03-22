using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class FileCannotBeCreated : Exception
    {
        public FileCannotBeCreated():base("Şəkil əlavə etmək olmur")
        {
        }

        public FileCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
