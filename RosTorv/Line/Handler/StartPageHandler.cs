using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Common;
using RosTorv.Line.Model;
using RosTorv.Line.View;
using RosTorv.Line.ViewModel;

namespace RosTorv.Line.Handler
{
    class StartPageHandler
    {

        public StartPageViewModel StartPageViewModel { get; set; }

        public StartPageHandler(StartPageViewModel startPageViewModel)
        {
            this.StartPageViewModel = startPageViewModel;
        }

        public void StartGame()
        {
            StartPageViewModel.Spil.Spiller1 = new Spiller(StartPageViewModel.Name1);
            NavigationService.Navigate(typeof(GamePage));
        }
    }
}
