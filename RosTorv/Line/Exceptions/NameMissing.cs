using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Line.Exceptions
{
    class NameMissing : Exception
    {
        public NameMissing(string message): base(message)
        {
            
        }
    }
}
