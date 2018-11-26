using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Line.Model
{
    class Bæger
    {
        private List<Terning> _terninger = new List<Terning>();
        private Terning _terning1 = new Terning(1);
        private Terning _terning2 = new Terning(2);
        private Terning _terning3 = new Terning(3);
        private Terning _terning4 = new Terning(4);
        private Terning _terning5 = new Terning(5);

        public List<Terning> Terninger
        {
            get { return _terninger;}
            set { _terninger = value;}
        }

        public Terning Terning1
        {
            get { return _terning1;}
            set { _terning1 = value; }
        }

        public Terning Terning2
        {
            get { return _terning2;}
            set { _terning2 = value; }
        }

        public Terning Terning3
        {
            get { return _terning3;}
            set { _terning3 = value; }
        }

        public Terning Terning4
        {
            get { return _terning4;}
            set { _terning4 = value; }
        }

        public Terning Terning5
        {
            get { return _terning5;}
            set { _terning5 = value; }
        }

        public Bæger()
        {
           _terninger.Add(_terning1);
           _terninger.Add(_terning2);
           _terninger.Add(_terning3);
           _terninger.Add(_terning4);
           _terninger.Add(_terning5);   
        }

        public void RollAll()
        {
            _terning1.Roll();
            _terning2.Roll();
            _terning3.Roll();
            _terning4.Roll();
            _terning5.Roll();
        }

        public int GetPoint()
        { 
            return _terning1.Eyes + _terning2.Eyes + _terning3.Eyes + _terning4.Eyes + _terning5.Eyes;
        }
    }
}
