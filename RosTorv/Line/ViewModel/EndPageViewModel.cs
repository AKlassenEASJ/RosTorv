using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Line.Handler;
using RosTorv.Line.Model;

namespace RosTorv.Line.ViewModel
{
    class EndPageViewModel
    {
        public SpilSingelton Spil { get; }
        public EndPageHandler EndPageHandler { get; set; }


        public EndPageViewModel()
        {
            Spil = SpilSingelton.InstansSpil;
            EndPageHandler = new EndPageHandler(this);
        }

    }
}
