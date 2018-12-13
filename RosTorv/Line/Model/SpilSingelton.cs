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
    /// <summary>
    /// Spillet er hvor det hele er koblet op på
    /// </summary>
    public class SpilSingelton : INotifyPropertyChanged
    {
        private int _slagTilbage = 3;
        public int Tur { get; set; }
        public int SpillersTur { get; set; }
        //public Spiller Spiller1 { get; set; }
        public BægerSingelton Bæger { get; set; }
        public EvaluateTerninger EvaluateTerninger { get; set; }
        public Highscore Highscore { get; set; }
        
        private static SpilSingelton _instansSpil = new SpilSingelton();

        private List<Spiller> _spillereCollection;

        public List<Spiller> SpillereCollection
        {
            get { return _spillereCollection; }
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
            SpillereCollection = new List<Spiller>();
            Bæger = BægerSingelton.InstanBægerSingelton;
            EvaluateTerninger = new EvaluateTerninger(this);
            Highscore = new Highscore();
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

        public void NyTur(int pointIndex)
        {
            if (SpillereCollection[SpillersTur].PointFelter[pointIndex].CanChange)
            {
                Tur--;
                if (SpillereCollection[SpillersTur].PointFelter[pointIndex].Point == 0)
                {
                    SpillereCollection[SpillersTur].PointFelter[pointIndex].BackgroundColor = "Gray";
                }
                else
                {
                    SpillereCollection[SpillersTur].PointFelter[pointIndex].Color = "Black";
                }
                SpillereCollection[SpillersTur].PointFelter[pointIndex].CanChange = false;
                NustilPoint();
                TjekBonusPoint(SpillersTur);
                SpillereCollection[SpillersTur].PointFelter[16].Point = SpillereCollection[SpillersTur].PointFelter[16].Point + SpillereCollection[SpillersTur].PointFelter[pointIndex].Point;
                ResetSlag();
                Bæger.NulstilTerninger();
                if (Tur < 1)
                {
                    foreach (Spiller spiller in SpillereCollection)
                    {
                        Highscore.TjekHighScore(spiller);
                    }
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

        public void TjekBonusPoint(int spiller)
        {
            int forløbigPoint = SpillereCollection[spiller].PointFelter[0].Point + SpillereCollection[spiller].PointFelter[1].Point + SpillereCollection[spiller].PointFelter[2].Point +
                                SpillereCollection[spiller].PointFelter[3].Point + SpillereCollection[spiller].PointFelter[4].Point + SpillereCollection[spiller].PointFelter[5].Point;
            if (forløbigPoint >= 63)
            {
                SpillereCollection[spiller].PointFelter[6].Point = 50;
                SpillereCollection[spiller].PointFelter[6].Color = "Black";
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
