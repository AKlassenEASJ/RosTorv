using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Nikolai.Model
{
    public class Spil : INotifyPropertyChanged
    {
        private Dice _dice1;
        private Dice _dice2;

        public Dice Dice1
        {
            get { return _dice1; }
            set
            {
                value = _dice1;
            }
        }

        public Dice Dice2
        {
            get { return _dice2; }
            set
            {
                value = _dice2;
            }
        }

        public Spil()
        {
            _dice1 = new Dice();
            _dice2 = new Dice();
        }
        public void RollAll()
        {
            Dice1.Roll();
            Dice2.Roll();


            //if (Numbers 7,8,9 = null);
            //{
            //    Dice.RemoveAt(Dice2);
            //}
        }
    }
}
