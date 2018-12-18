using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Background;
using RosTorv.Annotations;
using RosTorv.Thomas.Exceptions;

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

        public void PlaceBet(int BetAmount)
        {
            if (BetAmount!=1000 && BetAmount != 2000 && BetAmount != 3000 && BetAmount != 4000 && BetAmount != 5000)
            {
                IllegalBetException e = new IllegalBetException("You can bet only 1000, 2000, 3000, 4000 or 5000 points.");
                throw e;
            }

            if (BetAmount > Score)
            {
                IllegalBetException e = new IllegalBetException("You have insufficient points to place that bet.");
                throw e;
            }

            Score = Score - BetAmount;
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
