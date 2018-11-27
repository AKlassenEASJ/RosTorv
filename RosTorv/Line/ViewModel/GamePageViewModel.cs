using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RosTorv.Annotations;
using RosTorv.Common;
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
        public BægerSingelton Bæger { get; set; }

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

        public ICommand RollCommand
        {
            get { return _roll;}
            set { _roll = value; }
        }
        public GamePageViewModel()
        {
            Bæger = BægerSingelton.InstanBægerSingelton;
            _terning1 = Bæger.Terning1;
            _terning2 = Bæger.Terning2;
            _terning3 = Bæger.Terning3;
            _terning4 = Bæger.Terning4;
            _terning5 = Bæger.Terning5;
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
