using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

namespace RosTorv.Thomas.Model
{
    class Dice : INotifyPropertyChanged
    {
        private int _faceValue;
        private static Random _random;
        private bool _canRoll;

        public int FaceValue
        {
            get { return _faceValue; }
            set
            {
                _faceValue = value;
                OnPropertyChanged();
            }
        }
        public bool CanRoll
        {
            get { return _canRoll; }
            set
            {
                _canRoll = value;
                OnPropertyChanged();
            }

        }

        public Dice()
        {
            _random = new Random(DateTime.Now.Millisecond);
            _canRoll = true;
        }

        public void Roll()
        {
            if (CanRoll)
            { FaceValue = _random.Next(1, 7);}

        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
