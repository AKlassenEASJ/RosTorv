﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Anders.Exceptions
{
    public class NameIsInappropriateException : Exception
    {
        public NameIsInappropriateException(string message) : base(message)
        {
            
        }
    }
}
