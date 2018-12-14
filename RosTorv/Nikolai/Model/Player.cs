using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Nikolai.Model
{
    class Player
    {
        #region Instance Fields

        private string _name;
        private int _points;


        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }


        #endregion

        #region Constructor

        public Player(string name, int points)
        {
            _name = name;
            _points = points;
        }


        #endregion
 
        #region Methods



        #endregion
    }
}
