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
        private string _name;
        private ObservableCollection<PointFelt> _pointFelter = new ObservableCollection<PointFelt>();
        private int _totalPoint;
        public string Name
        {
            get { return _name;}
            set { _name = value; }
        }

        public ObservableCollection<PointFelt> PointFelter
        {
            get { return _pointFelter;}
            set { _pointFelter = value; }
        }

        public int TotalPoint
        {
            get { return _totalPoint;}
            set { _totalPoint = value; }
        }

        public Spiller(string Navn)
        {
            _name = Navn;
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
            PointFelter.Add(new PointFelt());
        }

        public void TjekBonusPoint()
        {
            int forløbigPoint = PointFelter[0].Point + PointFelter[1].Point + PointFelter[2].Point +
                                PointFelter[3].Point + PointFelter[4].Point + PointFelter[5].Point;
            if (forløbigPoint >= 63)
            {
                PointFelter[7].Point = 50;
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
