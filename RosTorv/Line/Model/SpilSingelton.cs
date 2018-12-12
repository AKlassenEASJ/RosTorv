using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.Line.Exceptions;
using RosTorv.Line.View;
using static RosTorv.Common.NavigationService;

namespace RosTorv.Line.Model
{
    public class SpilSingelton : INotifyPropertyChanged
    {
        private int _slagTilbage = 3;
        public int Tur { get; set; }
        public int SpillersTur { get; set; }
        //public Spiller Spiller1 { get; set; }
        public BægerSingelton Bæger { get; set; }
        public EvaluateTerninger EvaluateTerninger { get; set; }
        
        private static SpilSingelton _instansSpil = new SpilSingelton();

        private List<Spiller> _spillereCollection;

        public List<Spiller> SpillereCollection
        {
            get => _spillereCollection;
            set { _spillereCollection = value; }
        }


        public static SpilSingelton InstansSpil
        {
            get { return _instansSpil; }
        }

        public int SlagTilbage
        {
            get { return _slagTilbage; }
            set
            {
                _slagTilbage = value;
                OnPropertyChanged();
            }
        }

        private SpilSingelton()
        {
            //Spiller1 = new Spiller("Line");
            Bæger = BægerSingelton.InstanBægerSingelton;
            EvaluateTerninger = new EvaluateTerninger(this);
        }

        public void RollInTurn()
        {
            if (SlagTilbage > 0)
            {
                NustilPoint();
                Bæger.RollAll();
                EvaluateTerninger.RunAllEvaluate(SpillersTur);
                SlagTilbage = SlagTilbage - 1;
            }
            
        }

        public void NyTur(int PointIndex)
        {
            if (SpillereCollection[SpillersTur].PointFelter[PointIndex].CanChange)
            {
                Tur--;
                if (SpillereCollection[SpillersTur].PointFelter[PointIndex].Point == 0)
                {
                    SpillereCollection[SpillersTur].PointFelter[PointIndex].BackgroundColor = "Gray";
                }
                else
                {
                    SpillereCollection[SpillersTur].PointFelter[PointIndex].Color = "Black";
                }
                SpillereCollection[SpillersTur].PointFelter[PointIndex].CanChange = false;
                NustilPoint();
                SpillereCollection[SpillersTur].TjekBonusPoint();
                SpillereCollection[SpillersTur].PointFelter[16].Point = SpillereCollection[SpillersTur].PointFelter[16].Point + SpillereCollection[SpillersTur].PointFelter[PointIndex].Point;
                ResetSlag();
                Bæger.NulstilTerninger();
                if (Tur < 1)
                {
                    NavigationService.Navigate(typeof(EndPage));
                }

                if (SpillersTur >= (SpillereCollection.Count - 1))
                {
                    SpillersTur = 0;
                }
                else
                {
                    SpillersTur++;
                }
            }
        }

        private void NustilPoint()
        {
            foreach (PointFelt pointFelt in SpillereCollection[SpillersTur].PointFelter)
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

        public void AddSpiller(Spiller newspiller)
        {
            if (newspiller.Name == null)
            {
                throw new NameMissing("Spiller skal have navn");
            }
            else
            {
                _spillereCollection.Add(newspiller);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
