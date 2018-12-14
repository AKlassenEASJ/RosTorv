using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Line.Model;
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
        
        public void TjekVinder()
        {
            EndPageViewModel.VinderNavn = EndPageViewModel.Spil.SpillereCollection[0].Name;
            EndPageViewModel.VinderPoint = EndPageViewModel.Spil.SpillereCollection[0].TotalPoint;
            EndPageViewModel.Vindernr = 1;

            if (EndPageViewModel.Spil.SpillereCollection.Count > 1)
            {
                for (int i = 0; i < EndPageViewModel.Spil.SpillereCollection.Count; i++)
                {
                    if (EndPageViewModel.Spil.SpillereCollection[i].TotalPoint > EndPageViewModel.VinderPoint)
                    {
                        EndPageViewModel.VinderNavn = EndPageViewModel.Spil.SpillereCollection[i].Name;
                        EndPageViewModel.VinderPoint = EndPageViewModel.Spil.SpillereCollection[i].TotalPoint;
                        EndPageViewModel.Vindernr = i + 1;
                        EndPageViewModel.Spil.SpillereCollection.RemoveAt(i);
                    }
                }
            }

            if (EndPageViewModel.Vindernr == 1)
            {
                EndPageViewModel.Spil.SpillereCollection.RemoveAt(0);
            }
            
        }


    }
}
