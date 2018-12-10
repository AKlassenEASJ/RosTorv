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

        public void Button1()
        {
            StartPageViewModel.NameButton1 = "Visible";
            StartPageViewModel.NameButton2 = "Collapsed";
            StartPageViewModel.NameButton3 = "Collapsed";
            StartPageViewModel.NameButton4 = "Collapsed";
            StartPageViewModel.NameButton5 = "Collapsed";

            StartPageViewModel.AntalSpillere = 1;
        }

        public void Button2()
        {
            StartPageViewModel.NameButton1 = "Visible";
            StartPageViewModel.NameButton2 = "Visible";
            StartPageViewModel.NameButton3 = "Collapsed";
            StartPageViewModel.NameButton4 = "Collapsed";
            StartPageViewModel.NameButton5 = "Collapsed";

            StartPageViewModel.AntalSpillere = 2;
        }

        public void Button3()
        {
            StartPageViewModel.NameButton1 = "Visible";
            StartPageViewModel.NameButton2 = "Visible";
            StartPageViewModel.NameButton3 = "Visible";
            StartPageViewModel.NameButton4 = "Collapsed";
            StartPageViewModel.NameButton5 = "Collapsed";

            StartPageViewModel.AntalSpillere = 3;
        }

        public void Button4()
        {
            StartPageViewModel.NameButton1 = "Visible";
            StartPageViewModel.NameButton2 = "Visible";
            StartPageViewModel.NameButton3 = "Visible";
            StartPageViewModel.NameButton4 = "Visible";
            StartPageViewModel.NameButton5 = "Collapsed";

            StartPageViewModel.AntalSpillere = 4;
        }

        public void Button5()
        {
            StartPageViewModel.NameButton1 = "Visible";
            StartPageViewModel.NameButton2 = "Visible";
            StartPageViewModel.NameButton3 = "Visible";
            StartPageViewModel.NameButton4 = "Visible";
            StartPageViewModel.NameButton5 = "Visible";

            StartPageViewModel.AntalSpillere = 5;
        }
    }
}
