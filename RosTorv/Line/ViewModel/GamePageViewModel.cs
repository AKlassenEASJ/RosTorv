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
        private PointFelt _selectedPointFelt;
        public TerningButtonHandler TerningButtonHandler { get; set; }
        public Spil Spil { get; set; }
        public PointTekster Pointtekst { get; set; }

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

        public int SelectedTerningIndex { get; set; }

        public int  SelectedPointIndex { get; set; }

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

        //public PointTekst SelectedPointTekst
        //{
        //    get { return _selectedPointFelt;}
        //    set { _selectedPointFelt = value; }
        //}

        public GamePageViewModel()
        {
            Spil = new Spil();
            Pointtekst = new PointTekster();
            TerningButtonHandler = new TerningButtonHandler(this);
            _roll = new RelayCommand(Spil.RollInTurn);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
