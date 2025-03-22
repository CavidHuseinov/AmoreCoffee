using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class FileCannotBeUpdate : Exception
    {
        public FileCannotBeUpdate():base("Faylı yeniləmək olmur")
        {
        }

        public FileCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
