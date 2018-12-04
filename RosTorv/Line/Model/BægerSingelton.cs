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
    public class BægerSingelton :INotifyPropertyChanged
    {
        public ObservableCollection<Terning> Terninger { get; set; }
        //private int _score;
        private static BægerSingelton instansBægerSingelton = new BægerSingelton();

        public static BægerSingelton InstanBægerSingelton
        {
            get { return instansBægerSingelton; }
        }

        //public int Score
        //{
        //    get { return _score;}
        //    set
        //    {
        //        _score = value;
        //        OnPropertyChanged();
        //    }
        //}
        private BægerSingelton()
        {
            Terninger = new ObservableCollection<Terning>();
            Terninger.Add(new Terning(5));
            Terninger.Add(new Terning(10));
            Terninger.Add(new Terning(15));
            Terninger.Add(new Terning(20));
            Terninger.Add(new Terning(5));
        }

        public void RollAll()
        {
            foreach (Terning terning in Terninger)
            {
                if (terning.CanRoll == true)
                {
                    terning.Roll();
                }
            }
            //GetPoint();
        }

        public void ChangeCanRoll(int index)
        {
            if (Terninger[index].CanRoll == true)
            {
                Terninger[index].CanRoll = false;
                Terninger[index].ShadowOpacity = 0.70;
            }
            else if (Terninger[index].CanRoll == false)
            {
                Terninger[index].CanRoll = true;
                Terninger[index].ShadowOpacity = 0;
            }
        }

        //public void GetPoint()
        //{
        //     Score = Terninger[0].Eyes + Terninger[1].Eyes + Terninger[2].Eyes + Terninger[3].Eyes + Terninger[4].Eyes;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
