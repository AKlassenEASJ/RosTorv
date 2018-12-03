using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Anders.Model
{
    class Player
    {


        #region Instance Fields

        private string _name;
        private int _playerScore;


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

        #endregion

        #region Constructor

        public Player()
        {

        }



        #endregion

        #region Methods



        #endregion



    }
}
