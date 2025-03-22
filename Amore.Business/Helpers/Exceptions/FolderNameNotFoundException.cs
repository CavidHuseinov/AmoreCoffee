﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class FolderNameNotFoundException : Exception
    {
        public FolderNameNotFoundException(string? message="Şəkil üçün qovluq yaratmaq mümkün olmadi") : base(message)
        {
        }
    }
}
