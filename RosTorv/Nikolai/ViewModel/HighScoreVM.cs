using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Nikolai.Model;

namespace RosTorv.Nikolai.ViewModel
{
    class HighScoreVM
    {
        #region Instance Fields

        private ObservableCollection<Player> _highScoreList = HighScore.Instance.PlayerHighScore;


        #endregion

        #region Properties
        public ObservableCollection<Player> HighScoreList
        {
            get
            {
               return _highScoreList;
                
            }
            set { _highScoreList = value; }
        }


        #endregion

        #region Constructor

        public HighScoreVM()
        {
            
        }


        #endregion

        #region Methods



        #endregion
    }
}
