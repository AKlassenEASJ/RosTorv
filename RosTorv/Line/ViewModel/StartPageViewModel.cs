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

namespace RosTorv.Line.ViewModel
{
    class StartPageViewModel : INotifyPropertyChanged
    {
        private string _name1;
        private string _name2;
        private string _name3;
        private string _name4;
        private string _name5;

        public StartPageHandler StartPageHandler { get; set; }

        public ICommand Command1Spiller { get; set; }
        public ICommand Command2Spiller { get; set; }
        public ICommand command3Spiller { get; set; }
        public ICommand command4Spiller { get; set; }
        public ICommand command5Spiller { get; set; }
        public ICommand StartGameCommand { get; set; }

        public SpilSingelton Spil { get; set; }

        public string Name1
        {
            get { return _name1;}
            set
            {
                _name1 = value;
                OnPropertyChanged();
            }
        }

        public string Name2
        {
            get { return _name2; }
            set
            {
                _name2 = value;
                OnPropertyChanged();
            }
        }

        public string Name3
        {
            get { return _name3; }
            set
            {
                _name3 = value;
                OnPropertyChanged();
            }
        }

        public string Name4
        {
            get { return _name4; }
            set
            {
                _name4 = value;
                OnPropertyChanged();
            }
        }

        public string Name5
        {
            get { return _name5; }
            set
            {
                _name5 = value;
                OnPropertyChanged();
            }
        }

        public StartPageViewModel()
        {
            StartPageHandler = new StartPageHandler(this);
            Spil = SpilSingelton.InstansSpil;
            StartGameCommand= new RelayCommand(StartPageHandler.StartGame);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
