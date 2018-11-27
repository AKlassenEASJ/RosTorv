using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.Devices;
using Windows.UI.Xaml.Media;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.Line.Handler;
using RosTorv.Line.Model;

namespace RosTorv.Line.ViewModel
{
    public class GamePageViewModel : INotifyPropertyChanged
    {
        private Terning _terning1;
        private Terning _terning2;
        private Terning _terning3;
        private Terning _terning4;
        private Terning _terning5;
        private ICommand _roll;
        private ICommand _holdTerning1;
        private ICommand _holdTerning2;
        private ICommand _holdTerning3;
        private ICommand _holdTerning4;
        private ICommand _holdTerning5;
        public BægerSingelton Bæger { get; set; }
        public TerningButtonHandler TerningButtonHandler { get; set; }
        private string _backgroundColor1;
        private string _backgroundColor2;
        private string _backgroundColor3;
        private string _backgroundColor4;
        private string _backgroundColor5;
        //private int _slagTilbage;
        //public int SlagTilbage
        //{
        //    get { return _slagTilbage; }
        //    set
        //    {
        //        _slagTilbage = value;
        //        OnPropertyChanged();
        //    }
        //}
        

        
        public Terning ViewTerning1
        {
            get { return _terning1; }
            set
            {
                _terning1 = value;
                OnPropertyChanged();
            }
        }
        public Terning ViewTerning2
        {
            get { return _terning2; }
            set
            {
                _terning2 = value;
                OnPropertyChanged();
            }
        }
        public Terning ViewTerning3
        {
            get { return _terning3; }
            set
            {
                _terning3 = value;
                OnPropertyChanged();
            }
        }
        public Terning ViewTerning4
        {
            get { return _terning4; }
            set
            {
                _terning4 = value;
                OnPropertyChanged();
            }
        }
        public Terning ViewTerning5
        {
            get { return _terning5; }
            set
            {
                _terning5 = value;
                OnPropertyChanged();
            }
        }

        public string BackgroundColor1
        {
            get { return _backgroundColor1;}
            set
            {
                _backgroundColor1 = value;
                OnPropertyChanged();
            }
        }
        public string BackgroundColor2
        {
            get { return _backgroundColor2; }
            set
            {
                _backgroundColor2 = value;
                OnPropertyChanged();
            }
        }
        public string BackgroundColor3
        {
            get { return _backgroundColor3; }
            set
            {
                _backgroundColor3 = value;
                OnPropertyChanged();
            }
        }
        public string BackgroundColor4
        {
            get { return _backgroundColor4; }
            set
            {
                _backgroundColor4 = value;
                OnPropertyChanged();
            }
        }
        public string BackgroundColor5
        {
            get { return _backgroundColor5; }
            set
            {
                _backgroundColor5 = value;
                OnPropertyChanged();
            }
        }

        public ICommand RollCommand
        {
            get { return _roll;}
            set { _roll = value; }
        }

        public ICommand HoldTerning1Command
        {
            get { return _holdTerning1; }
            set { _holdTerning1 = value; }
        }
        public ICommand HoldTerning2Command
        {
            get { return _holdTerning2; }
            set { _holdTerning2 = value; }
        }
        public ICommand HoldTerning3Command
        {
            get { return _holdTerning3; }
            set { _holdTerning3 = value; }
        }
        public ICommand HoldTerning4Command
        {
            get { return _holdTerning4; }
            set { _holdTerning4 = value; }
        }
        public ICommand HoldTerning5Command
        {
            get { return _holdTerning5; }
            set { _holdTerning5 = value; }
        }

        public GamePageViewModel()
        {
            BackgroundColor1 = "White";
            BackgroundColor2 = "White";
            BackgroundColor3 = "White";
            BackgroundColor4 = "White";
            BackgroundColor5 = "White";
            TerningButtonHandler = new TerningButtonHandler(this);
            Bæger = BægerSingelton.InstanBægerSingelton;
            _terning1 = Bæger.Terning1;
            _terning2 = Bæger.Terning2;
            _terning3 = Bæger.Terning3;
            _terning4 = Bæger.Terning4;
            _terning5 = Bæger.Terning5;
            _holdTerning1 = new RelayCommand(TerningButtonHandler.HoldTerning1);
            _holdTerning2 = new RelayCommand(TerningButtonHandler.HoldTerning2);
            _holdTerning3 = new RelayCommand(TerningButtonHandler.HoldTerning3);
            _holdTerning4 = new RelayCommand(TerningButtonHandler.HoldTerning4);
            _holdTerning5 = new RelayCommand(TerningButtonHandler.HoldTerning5);
            _roll = new RelayCommand(Bæger.RollAll);
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
