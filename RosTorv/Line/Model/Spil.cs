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
            foreach (PointFelt pointFelt in Spiller1.PointFelter)
            {
                if (pointFelt.CanChange)
                {
                    pointFelt.Point = 0;
                }
            }
            Bæger.RollAll();
            EvaluateTerninger.RunAllEvaluate();
            //GetPreviewpoints();

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

        //public void GetPreviewpoints()
        //{
        //    int antalØjne = 1;


        //    for (int i = 0; i <= 6; i++)
        //    {
        //        if (Spiller1.PointFelter[i].CanChange)
        //        {
        //            for (int j = 0; j <= Bæger.Terninger.Count; j++)
        //            {
        //                if (Bæger.Terninger[j].Eyes == antalØjne)
        //                {
        //                    Spiller1.PointFelter[i].Point = Spiller1.PointFelter[i].Point + Bæger.Terninger[j].Eyes;
        //                }
        //            }
        //        }

        //        antalØjne++;
        //    }

        //}

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
