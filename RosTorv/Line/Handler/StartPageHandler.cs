using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Common;
using RosTorv.Line.Commen;
using RosTorv.Line.Exceptions;
using RosTorv.Line.Model;
using RosTorv.Line.Persistencty;
using RosTorv.Line.View;
using RosTorv.Line.ViewModel;

namespace RosTorv.Line.Handler
{
    public class StartPageHandler
    {
        private int _antalTure = 15;
        public StartPageViewModel StartPageViewModel { get; set; }

        public StartPageHandler(StartPageViewModel startPageViewModel)
        {
            this.StartPageViewModel = startPageViewModel;
        }

        public async void StartGame()
        {
            try
            {
                StartPageViewModel.Spil.SpillereCollection.Clear();

                StartPageViewModel.Spil.AddSpiller(new Spiller(StartPageViewModel.Name1));
                StartPageViewModel.Spil.Tur = _antalTure;
                if (StartPageViewModel.AntalSpillere > 1)
                {
                    StartPageViewModel.Spil.AddSpiller(new Spiller(StartPageViewModel.Name2));
                    StartPageViewModel.Spil.Tur = _antalTure *2;

                    if (StartPageViewModel.AntalSpillere > 2)
                    {
                        StartPageViewModel.Spil.AddSpiller(new Spiller(StartPageViewModel.Name3));
                        StartPageViewModel.Spil.Tur = _antalTure*3;

                        if (StartPageViewModel.AntalSpillere > 3)
                        {
                            StartPageViewModel.Spil.AddSpiller(new Spiller(StartPageViewModel.Name4));
                            StartPageViewModel.Spil.Tur = _antalTure * 4;

                            if (StartPageViewModel.AntalSpillere > 4)
                            {
                                StartPageViewModel.Spil.AddSpiller(new Spiller(StartPageViewModel.Name5));
                                StartPageViewModel.Spil.Tur = _antalTure * 5;
                            }
                        }
                    }
                }
                StartPageViewModel.Spil.SpillersTur = 0;
                StartPageViewModel.Spil.SpillereCollection[0].BackGroundColor = "LimeGreen";
                StartPageViewModel.Spil.ResetSlag();
                await SaveName1();
                NavigationService.Navigate(typeof(GamePage));
            }
            catch (NameMissing e)
            {
                MessageDialogHelper.Show(e.Message, "Alle spillere skal have navn");
            }
        }

        public void Button1()
        {
            StartPageViewModel.NameButton2 = "Collapsed";
            StartPageViewModel.NameButton3 = "Collapsed";
            StartPageViewModel.NameButton4 = "Collapsed";
            StartPageViewModel.NameButton5 = "Collapsed";

            StartPageViewModel.AntalSpillere = 1;
        }

        public void Button2()
        {
            StartPageViewModel.NameButton2 = "Visible";
            StartPageViewModel.NameButton3 = "Collapsed";
            StartPageViewModel.NameButton4 = "Collapsed";
            StartPageViewModel.NameButton5 = "Collapsed";

            StartPageViewModel.AntalSpillere = 2;
        }

        public void Button3()
        {
            StartPageViewModel.NameButton2 = "Visible";
            StartPageViewModel.NameButton3 = "Visible";
            StartPageViewModel.NameButton4 = "Collapsed";
            StartPageViewModel.NameButton5 = "Collapsed";

            StartPageViewModel.AntalSpillere = 3;
        }

        public void Button4()
        {
            StartPageViewModel.NameButton2 = "Visible";
            StartPageViewModel.NameButton3 = "Visible";
            StartPageViewModel.NameButton4 = "Visible";
            StartPageViewModel.NameButton5 = "Collapsed";

            StartPageViewModel.AntalSpillere = 4;
        }

        public void Button5()
        {
            StartPageViewModel.NameButton2 = "Visible";
            StartPageViewModel.NameButton3 = "Visible";
            StartPageViewModel.NameButton4 = "Visible";
            StartPageViewModel.NameButton5 = "Visible";

            StartPageViewModel.AntalSpillere = 5;
        }

        public async Task SaveName1()
        {
            await PersistencyFacadeName.SerializeNameAsync(StartPageViewModel.Name1);

        }

        public async Task LoadName1Async()
        {
            string loadedName = await PersistencyFacadeName.DeSerializeNameAsync();
            if (loadedName != null)
            {
                StartPageViewModel.Name1 = loadedName;
            }

        }
    }
}
