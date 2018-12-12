using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Anders.Model
{
    public class Player
    {


        #region Instance Fields

        private string _name;
        private int _playerScore;
        private int _turns;


        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }

        public int PlayerScore
        {
            get { return _playerScore; }
            set { _playerScore = value; }

        }

        public int Turns
        {
            get { return _turns; }
            set { _turns = value; }
        }

        

        #endregion

        #region Constructor

        public Player(string name, int score, int turns)
        {
            _name = name;
            _playerScore = score;
            _turns = turns;

        }

        public Player(int score, int turns)
        {
            _turns = turns;
            _playerScore = score;

        }



        #endregion

        #region Methods



        #endregion



    }
}
