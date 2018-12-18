using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

namespace RosTorv.Line.Model
{
    public class Spiller : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private string _backGroundColor = "none";

        public string BackGroundColor
        {
            get { return _backGroundColor; }
            set
            {
                _backGroundColor = value; 
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PointFelt> PointFelter { get; set; } = new ObservableCollection<PointFelt>();

        public Spiller(string navn)
        {
            Name = navn;
            PointFelter.Add(new PointFelt());//enere 0
            PointFelter.Add(new PointFelt());//Toere  1  
            PointFelter.Add(new PointFelt());//Trerer 2
            PointFelter.Add(new PointFelt());//Fire 3
            PointFelter.Add(new PointFelt());//Fem 4 
            PointFelter.Add(new PointFelt());//seks 5
            PointFelter.Add(new PointFelt());//sum 6
            PointFelter[6].CanChange = false;
            PointFelter[6].Color = "Black";
            PointFelter.Add(new PointFelt());//bonus 7
            PointFelter[7].CanChange = false;
            PointFelter.Add(new PointFelt());//1 Par 8
            PointFelter.Add(new PointFelt());//2 Par 9 
            PointFelter.Add(new PointFelt());//3 ens 10
            PointFelter.Add(new PointFelt());//4 ens 11
            PointFelter.Add(new PointFelt());//høj 12
            PointFelter.Add(new PointFelt());//lav 13
            PointFelter.Add(new PointFelt());//fuldHus 14
            PointFelter.Add(new PointFelt());//chance 15
            PointFelter.Add(new PointFelt());//Yatzy 16
            PointFelter.Add(new PointFelt());//sum 17
            PointFelter[17].CanChange = false;
            PointFelter[17].Color = "Black";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
