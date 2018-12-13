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
        //private ICommand _holdTerning;
        private Terning _selectedTerning;
        private PointFelt _selectedPointFelt;
        private int _selectedTerningIndex;
        public TerningButtonHandler TerningButtonHandler { get; set; }
        public SpilSingelton Spil { get; }
        public PointTekster Pointtekst { get; set; }

        public ICommand RollCommand { get; }

        public int SelectedTerningIndex
        {
            get => _selectedTerningIndex;
            set => _selectedTerningIndex = value;
        }

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

        public PointFelt SelectedPointFelt
        {
            get { return _selectedPointFelt; }
            set
            {
                _selectedPointFelt = value;
                OnPropertyChanged();
                Spil.NyTur(SelectedPointIndex);
            }
        }


        public GamePageViewModel()
        {
            Spil = SpilSingelton.InstansSpil;
            Pointtekst = new PointTekster();
            TerningButtonHandler = new TerningButtonHandler(this);
            RollCommand = new RelayCommand(Spil.RollInTurn);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
