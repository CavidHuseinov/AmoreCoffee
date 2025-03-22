using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class FileCannotBeRemove : Exception
    {
        public FileCannotBeRemove():base("Faylı silmək olmur")
        {
        }

        public FileCannotBeRemove(string? message) : base(message)
        {
        }
    }
}
