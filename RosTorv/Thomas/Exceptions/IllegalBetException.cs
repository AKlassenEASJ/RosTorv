using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Thomas.Exceptions
{
    class IllegalBetException:Exception

    {
        public IllegalBetException(string message)
            : base(message)
        {
        }
    }
}
