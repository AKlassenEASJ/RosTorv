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
        public int HighScorePlads { get; set; }


        public ObservableCollection<PointFelt> PointFelter { get; set; } = new ObservableCollection<PointFelt>();

        public int TotalPoint
        {
            get { return PointFelter[16].Point;} }

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
            PointFelter[6].CanChange = false;
            PointFelter.Add(new PointFelt());//1 Par 7
            PointFelter.Add(new PointFelt());//2 Par 8 
            PointFelter.Add(new PointFelt());//3 ens 9
            PointFelter.Add(new PointFelt());//4 ens 10
            PointFelter.Add(new PointFelt());//høj 11
            PointFelter.Add(new PointFelt());//lav 12
            PointFelter.Add(new PointFelt());//fuldHus 13
            PointFelter.Add(new PointFelt());//chance 14
            PointFelter.Add(new PointFelt());//Yatzy 15
            PointFelter.Add(new PointFelt());//sum 16
            PointFelter[16].CanChange = false;
            PointFelter[16].Color = "Black";
        }

    }
}
