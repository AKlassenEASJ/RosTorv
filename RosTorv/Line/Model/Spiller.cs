using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Line.Model
{
    public class Spiller
    {
        public string Name { get; set; }

        public ObservableCollection<PointFelt> PointFelter { get; set; } = new ObservableCollection<PointFelt>();

        public int TotalPoint { get; set; }

        public Spiller(string navn)
        {
            Name = navn;
            PointFelter.Add(new PointFelt());//enere 0
            PointFelter.Add(new PointFelt());//Toere  1  
            PointFelter.Add(new PointFelt());//Trerer 2
            PointFelter.Add(new PointFelt());//Fire 3
            PointFelter.Add(new PointFelt());//Fem 4 
            PointFelter.Add(new PointFelt());//seks 5
            PointFelter.Add(new PointFelt());//bonus 6
            PointFelter.Add(new PointFelt());//1 Par 7
            PointFelter.Add(new PointFelt());//2 Par 8 
            PointFelter.Add(new PointFelt());//3 ens 9
            PointFelter.Add(new PointFelt());//4 ens 10
            PointFelter.Add(new PointFelt());//høj 11
            PointFelter.Add(new PointFelt());//lav12
            PointFelter.Add(new PointFelt());//fuldHus 13
            PointFelter.Add(new PointFelt());//chance 14
            PointFelter.Add(new PointFelt());//Yatzy 15
            PointFelter.Add(new PointFelt());//sum 16
        }

        public void TjekBonusPoint()
        {
            int forløbigPoint = PointFelter[0].Point + PointFelter[1].Point + PointFelter[2].Point +
                                PointFelter[3].Point + PointFelter[4].Point + PointFelter[5].Point;
            if (forløbigPoint >= 63)
            {
                PointFelter[6].Point = 50;
                PointFelter[6].CanChange = false;
            }
        }

        public void FåSum()
        {
            for (int i = 0; i < 16; i++)
            {
                PointFelter[16].Point = PointFelter[16].Point + PointFelter[i].Point;
            }
        }
        public void GetTotalPoints()
        {
            foreach (PointFelt point in PointFelter)
            {
                TotalPoint = point.Point;
            }
        }

    }
}
