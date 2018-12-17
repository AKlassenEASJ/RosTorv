﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Anders.Exceptions
{
    public class NameIsBlankException : Exception
    {

        public NameIsBlankException(string message) : base(message)
        {
            
        }

    }
}
