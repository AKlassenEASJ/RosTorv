using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

namespace RosTorv.Line.Model
{
    public class Spil : INotifyPropertyChanged
    {
        private int _slagTilbage = 3;
        public Spiller Spiller1 { get; set; }
        public BægerSingelton Bæger { get; set; }

        public int SlagTilbage
        {
            get { return _slagTilbage; }
            set
            {
                _slagTilbage = value;
                OnPropertyChanged();
            }
        }
        public Spil()
        {
            Spiller1 = new Spiller("Line");
            Bæger = BægerSingelton.InstanBægerSingelton;
        }

        public void RollInTurn()
        {
            Bæger.RollAll();

            if (SlagTilbage == 1)
            {
                foreach (Terning terning in Bæger.Terninger)
                {
                    terning.CanRoll = true;
                    terning.ShadowOpacity = 0;
                }
                resetSlag();
            }
            else
            {
                SlagTilbage = SlagTilbage - 1;
            }
        }

        public void resetSlag()
        {
            SlagTilbage = 3;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
