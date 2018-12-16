using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Anders.Handlers
{
    class ScoreCalculator
    {
        #region Instance Fields

        private static int _numberOfMatchesInARow = 0;


        #endregion

        #region Properties

        public static int NumberOfMatchesInARow
        {
            get { return _numberOfMatchesInARow; }
            set { _numberOfMatchesInARow = value; }
        }


        #endregion

        #region Constructor



        #endregion

        #region Methods

        public static int CalculateScoreToAdd()
        {
            int scoreToAdd = 500;

            if (_numberOfMatchesInARow > 0)
            {
                scoreToAdd = scoreToAdd * _numberOfMatchesInARow;
            }

            return scoreToAdd;

        }


        #endregion

    }
}
