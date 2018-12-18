using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.Line.Handler;
using RosTorv.Line.Model;
using RosTorv.Line.Persistencty;
using RosTorv.Line.View;

namespace RosTorv.Line.ViewModel
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        private string _name1;
        public ICommand Command1Spiller { get; set; }
        public ICommand Command2Spiller { get; set; }
        public ICommand Command3Spiller { get; set; }
        public ICommand Command4Spiller { get; set; }
        public ICommand Command5Spiller { get; set; }
        public ICommand StartGameCommand { get; set; }
        public ICommand EndCommand { get; set; }

        public SpilSingelton Spil { get;}
        public StartPageHandler StartPageHandler { get; set; }
        public int AntalSpillere { get; set; }

        public string Name1
        {
            get => _name1;
            set
            {
                _name1 = value;
                OnPropertyChanged();
            } }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Name5 { get; set; }

        private string _nameButton1;
        private string _nameButton2;
        private string _nameButton3;
        private string _nameButton4;
        private string _nameButton5;

        public string NameButton1
        {
            get { return _nameButton1; }
            set
            {
                _nameButton1 = value;
                OnPropertyChanged();
            }
        }

        public string NameButton2
        {
            get { return _nameButton2; }
            set
            {
                _nameButton2 = value;
                OnPropertyChanged();
            }
        }
        public string NameButton3
        {
            get { return _nameButton3; }
            set
            {
                _nameButton3 = value;
                OnPropertyChanged();
            }
        }
        public string NameButton4
        {
            get
            {
                return _nameButton4;
            }
            set
            {
                _nameButton4 = value;
                OnPropertyChanged();
            }
        }
        public string NameButton5 { get
        {
            return _nameButton5;
        }
            set
            {
                _nameButton5 = value;
                OnPropertyChanged();
            }
        }

        public StartPageViewModel()
        {
            AntalSpillere = 1;
            StartPageHandler = new StartPageHandler(this);
            Spil = SpilSingelton.InstansSpil;
            StartGameCommand = new RelayCommand(StartPageHandler.StartGame);
            Command1Spiller = new RelayCommand(StartPageHandler.Button1);
            Command2Spiller = new RelayCommand(StartPageHandler.Button2);
            Command3Spiller = new RelayCommand(StartPageHandler.Button3);
            Command4Spiller = new RelayCommand(StartPageHandler.Button4);
            Command5Spiller = new RelayCommand(StartPageHandler.Button5);
            
            NameButton1 = "Visible";
            NameButton2 = "Collapsed";
            NameButton3 = "Collapsed";
            NameButton4 = "Collapsed";
            NameButton5 = "Collapsed";

            LoadName1();

        }

        public async void LoadName1()
        {
            await StartPageHandler.LoadName1Async();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
