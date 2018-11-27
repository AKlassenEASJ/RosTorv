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
    public class BægerSingelton :INotifyPropertyChanged
    {
        public List<Terning> Terninger { get; set; }
        private int _slagTilbage = 3;

        private static BægerSingelton instansBægerSingelton = new BægerSingelton();

        public static BægerSingelton InstanBægerSingelton
        {
            get { return instansBægerSingelton; }
        }

        private Terning _terning1 = new Terning(1);
        private Terning _terning2 = new Terning(2);
        private Terning _terning3 = new Terning(3);
        private Terning _terning4 = new Terning(4);
        private Terning _terning5 = new Terning(5);

        public Terning Terning1
        {
            get { return _terning1; }
            set { _terning1 = value; }
        }

        public Terning Terning2
        {
            get { return _terning2; }
            set { _terning2 = value; }
        }

        public Terning Terning3
        {
            get { return _terning3; }
            set { _terning3 = value; }
        }

        public Terning Terning4
        {
            get { return _terning4; }
            set { _terning4 = value; }
        }

        public Terning Terning5
        {
            get { return _terning5; }
            set { _terning5 = value; }
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
            Terninger = new List<Terning>();
            Terninger.Add(Terning1);
            Terninger.Add(Terning2);
            Terninger.Add(Terning3);
            Terninger.Add(Terning4);
            Terninger.Add(Terning5);
        }

        public void RollAll()
        {
            foreach (Terning Terning in Terninger)
            {
                if (Terning.CanRoll == true)
                {
                    Terning.Roll();
                }
            }

            if (SlagTilbage == 1)
            {
                foreach (Terning terning in Terninger)
                {
                    terning.CanRoll = true;
                }

                resetSlag();
            }
            else
            {
                SlagTilbage = SlagTilbage - 1;
            }
            
        }

        



        public void resetSlag()
        {
            SlagTilbage = 3;
        }

        public int GetPoint()
        {
            return _terning1.Eyes + _terning2.Eyes + _terning3.Eyes + _terning4.Eyes + _terning5.Eyes;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
