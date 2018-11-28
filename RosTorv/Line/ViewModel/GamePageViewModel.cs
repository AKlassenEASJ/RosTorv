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
        private ICommand _roll;
        private ICommand _holdTerning;
        private int _selectedIndex;
        private Terning _selectedTerning;
        public BægerSingelton Bæger { get; set; }
        public TerningButtonHandler TerningButtonHandler { get; set; }



        public ICommand RollCommand
        {
            get { return _roll;}
            set { _roll = value; }
        }

        public ICommand HoldTerningCommand
        {
            get { return _holdTerning; }
            set { _holdTerning = value; }
        }

        public int SelectedIndex
        {
            get { return _selectedIndex;}
            set { _selectedIndex = value;}
        }

        public Terning SelectedTerning
        {
            get { return _selectedTerning;}
            set
            {
                _selectedTerning = value;
                OnPropertyChanged();
                TerningButtonHandler.HoldTerning();
            }
        }

        public GamePageViewModel()
        {
            //BackgroundColor1 = "White";
            //BackgroundColor2 = "White";
            //BackgroundColor3 = "White";
            //BackgroundColor4 = "White";
            //BackgroundColor5 = "White";
            TerningButtonHandler = new TerningButtonHandler(this);
            Bæger = BægerSingelton.InstanBægerSingelton;
            //_holdTerning = new RelayCommand(TerningButtonHandler.HoldTerning);
            //_holdTerning2 = new RelayCommand(TerningButtonHandler.HoldTerning2);
            //_holdTerning3 = new RelayCommand(TerningButtonHandler.HoldTerning3);
            //_holdTerning4 = new RelayCommand(TerningButtonHandler.HoldTerning4);
            //_holdTerning5 = new RelayCommand(TerningButtonHandler.HoldTerning5);
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
