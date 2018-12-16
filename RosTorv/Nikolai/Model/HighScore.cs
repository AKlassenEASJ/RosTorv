using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Nikolai.Model
{
    class HighScore 
    {
        #region Instance Fields

        private static HighScore _instance;
        private ObservableCollection<Player> _playerHighScore;



        #endregion

        #region Properties

        public static HighScore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HighScore();
                }
                return _instance;
            }
            set { _instance = value; }
        }

         

        public ObservableCollection<Player> PlayerHighScore
        {
            get { return _playerHighScore; }
            set { _playerHighScore = value; }
        }        

        #endregion

        #region Constructor

        private HighScore()
        {
            
        }


        #endregion

        #region Methods



        #endregion
    }
}
