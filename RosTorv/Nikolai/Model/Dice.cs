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
    public class Dice:INotifyPropertyChanged
    {
        private int _diceValue;
        private Random _random;

        public int DiceValue
        {
            get { return _diceValue;}
            set
            {
                _diceValue = value;
                OnPropertyChanged();
            }
        }

        public Dice()
        {
            _random = new Random(DateTime.Now.Millisecond);

        }

        public void Roll()
        {


            DiceValue = _random.Next(1, 7);

        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
