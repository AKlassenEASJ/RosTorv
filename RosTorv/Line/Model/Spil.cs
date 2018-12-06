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
        public EvaluateTerninger EvaluateTerninger { get; set; }

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
            EvaluateTerninger = new EvaluateTerninger(this);
        }

        public void RollInTurn()
        {
            if (SlagTilbage > 0)
            {
                NustilPoint();
                Bæger.RollAll();
                EvaluateTerninger.RunAllEvaluate();
                SlagTilbage = SlagTilbage - 1;
            }
            
        }

        public void NyTur(int index)
        {
            if (Spiller1.PointFelter[index].Point == 0)
            {
                Spiller1.PointFelter[index].BackgroundColor = "Gray";
            }
            else
            {
                Spiller1.PointFelter[index].Color = "Black";
            }
            Spiller1.PointFelter[index].CanChange = false;
            NustilPoint();
            ResetSlag();
            Bæger.NulstilTerninger();
        }

        private void NustilPoint()
        {
            foreach (PointFelt pointFelt in Spiller1.PointFelter)
            {
                if (pointFelt.CanChange)
                {
                    pointFelt.Point = 0;
                }
            }
        }

        public void ResetSlag()
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
