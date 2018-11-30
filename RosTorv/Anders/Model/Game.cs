using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

namespace RosTorv.Anders.Model
{
    public class Game : INotifyPropertyChanged
    {

        #region Instance Fields

        private int _score;
        private int _turns;
        private static Game _instance;


        #endregion

        #region Properties

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        public int Turns
        {
            get { return _turns; }
            set
            {
                _turns = value;
                OnPropertyChanged();
            }
        }

        public static Game Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new Game();
                }

                return _instance;

            }
        }


        #endregion

        #region Constructor

        private Game()
        {

        }

        #endregion

        #region Methods

        public void IncreaseTurns()
        {
            Turns++;
            
        }

        public void AddPointsToScore(int pointsToAdd)
        {
            Score = Score + pointsToAdd;
            OnPropertyChanged();
        }



        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
