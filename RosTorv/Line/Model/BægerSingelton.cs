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
        private int _slagTilbage = 3;

        private static BægerSingelton instansBægerSingelton = new BægerSingelton();

        public static BægerSingelton InstanBægerSingelton
        {
            get { return instansBægerSingelton; }
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

        private BægerSingelton()
        {
            Terninger = new ObservableCollection<Terning>();
            Terninger.Add(new Terning(1));
            Terninger.Add(new Terning(2));
            Terninger.Add(new Terning(3));
            Terninger.Add(new Terning(4));
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

            if (SlagTilbage == 1)
            {
                foreach (Terning terning in Terninger)
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

        public void resetSlag()
        {
            SlagTilbage = 3;
        }

        public int GetPoint()
        {
            return Terninger[0].Eyes + Terninger[1].Eyes + Terninger[2].Eyes + Terninger[3].Eyes + Terninger[4].Eyes;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
