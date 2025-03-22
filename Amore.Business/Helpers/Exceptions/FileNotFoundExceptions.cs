using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class FileNotFoundExceptions : Exception
    {
        public FileNotFoundExceptions():base("Fayl tapmaq olmur")
        {
        }

        public FileNotFoundExceptions(string? message) : base(message)
        {
        }
    }
}
