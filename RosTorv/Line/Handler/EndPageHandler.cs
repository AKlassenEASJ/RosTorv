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
            EndPageViewModel.VinderPoint = EndPageViewModel.Spil.SpillereCollection[0].PointFelter[17].Point;
            EndPageViewModel.VinderNr = 1;

            if (EndPageViewModel.Spil.SpillereCollection.Count > 1)
            {
                for (int i = 1; i < EndPageViewModel.Spil.SpillereCollection.Count; i++)
                {
                    if (EndPageViewModel.Spil.SpillereCollection[i].PointFelter[17].Point > EndPageViewModel.VinderPoint)
                    {
                        EndPageViewModel.VinderNavn = EndPageViewModel.Spil.SpillereCollection[i].Name;
                        EndPageViewModel.VinderPoint = EndPageViewModel.Spil.SpillereCollection[i].PointFelter[17].Point;
                        EndPageViewModel.VinderNr = i + 1;
                    }
                }
            }

            switch (EndPageViewModel.VinderNr)
            {
                case 2:
                    EndPageViewModel.Spil.SpillereCollection.RemoveAt(1);
                    break;
                case 3:
                    EndPageViewModel.Spil.SpillereCollection.RemoveAt(2);
                    break;
                case 4:
                    EndPageViewModel.Spil.SpillereCollection.RemoveAt(3);
                    break;
                case 5:
                    EndPageViewModel.Spil.SpillereCollection.RemoveAt(4);
                    break;
                default:
                    EndPageViewModel.Spil.SpillereCollection.RemoveAt(0);
                    break;
            }

            
        }


    }
}
