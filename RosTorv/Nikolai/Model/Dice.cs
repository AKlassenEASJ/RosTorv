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
                UpdateImage();
            }
        }

        private void UpdateImage()
        {
            if (_diceValue == 1)
            {
                ImageSource = "/Nikolai/Assets/die_1.png";
            }
            if (_diceValue == 2)
            {
                ImageSource = "/Nikolai/Assets/die_2.png";
            }
            if (_diceValue == 3)
            {
                ImageSource = "/Nikolai/Assets/die_3.png";
            }
            if (_diceValue == 4)
            {
                ImageSource = "/Nikolai/Assets/die_4.png";
            }
            if (_diceValue == 5)
            {
                ImageSource = "/Nikolai/Assets/die_5.png";
            }
            if (_diceValue == 6)
            {
                ImageSource = "/Nikolai/Assets/die_6.png";
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
        private string imageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
