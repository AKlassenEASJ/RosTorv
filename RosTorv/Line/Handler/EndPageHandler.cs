using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Line.ViewModel;

namespace RosTorv.Line.Handler
{
    class EndPageHandler
    {
        public EndPageViewModel EndPageViewModel { get; set; }

        public EndPageHandler(EndPageViewModel endPageViewModel)
        {
            this.EndPageViewModel = endPageViewModel;
        }


    }
}
