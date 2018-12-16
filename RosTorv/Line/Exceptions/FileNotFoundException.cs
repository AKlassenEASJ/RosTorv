using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Line.Exceptions
{
    class FileNotFoundException : Exception
    {
        public FileNotFoundException(string Message) : base(Message)
        {
            
        }
    }
}
