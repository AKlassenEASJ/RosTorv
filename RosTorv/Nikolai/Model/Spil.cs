using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

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

        public Numbers NumberCatalog { get; set; }

        public Spil()
        {
            _dice1 = new Dice();
            _dice2 = new Dice();
            RollAll();
            NumberCatalog = new Numbers();
        }

        public void RollAll()
        {
            Dice1.Roll();
            Dice2.Roll();
            NumberCatalog = new Numbers();
        }


        //if (Numbers 7,8,9 = null);
            //{
            //    Dice.RemoveAt(Dice2);
            //}

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
