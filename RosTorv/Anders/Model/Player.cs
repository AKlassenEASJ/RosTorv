using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Anders.Exceptions;

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
            if (_name == "" || _name == null)
            {
                throw new Exceptions.NameIsBlankException("Name has not been specified");
            }
            else if (_name.Contains("fuck") || _name.Contains("Fuck") || _name.Contains("Kill") || _name.Contains("kill") || _name.Contains("k1ll") || _name.Contains("K1ll"))
            {
                throw new NameIsInappropriateException("Name can't contain the f word or the word kill");
            }
            _playerScore = score;
            _turns = turns;

        }

        public Player(int score, int turns)
        {
            _turns = turns;
            _playerScore = score;

        }

        public Player()
        {
            
        }



        #endregion

        #region Methods



        #endregion



    }
}
