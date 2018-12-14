using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Background;
using RosTorv.Annotations;

namespace RosTorv.Thomas.Model
{
    class Player:INotifyPropertyChanged
    {
        private int _score;

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged();

            }
        }

        public int Bet(int BetAmount)
        {
            Score = Score - BetAmount;
            return BetAmount;
        }

        public Player(int StartScore)
        {
            Score = StartScore;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
