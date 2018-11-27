using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Line.Model
{
    public class BægerSingelton
    {
        public List<Terning> Terninger { get; set; }

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
        }

        public int GetPoint()
        {
            return _terning1.Eyes + _terning2.Eyes + _terning3.Eyes + _terning4.Eyes + _terning5.Eyes;
        }
    }
}
