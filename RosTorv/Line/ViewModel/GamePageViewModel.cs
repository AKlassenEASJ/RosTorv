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
        private Terning _selectedTerning;
        public BægerSingelton Bæger { get; set; }
        public TerningButtonHandler TerningButtonHandler { get; set; }

        //private int _score;

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

        public int SelectedIndex { get; set; }

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

        //public int Score
        //{
        //    get { return _score;}
        //    set
        //    {
        //        _score = value; 
        //        OnPropertyChanged();
        //    }
        //}

        public GamePageViewModel()
        {
            TerningButtonHandler = new TerningButtonHandler(this);
            Bæger = BægerSingelton.InstanBægerSingelton;
            _roll = new RelayCommand(Bæger.RollAll);
            //_score = Bæger.Score;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
