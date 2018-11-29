using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Nikolai.Model;

namespace RosTorv.Nikolai.ViewModel
{
    public class STBVM
    {
        public Spil Game { get; set; }


        public STBVM()
        {
            Game = new Spil();
        }

    }
}
