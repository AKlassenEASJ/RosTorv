using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Anders.Handlers;
using RosTorv.Anders.Model;
using RosTorv.Annotations;

namespace RosTorv.Anders.ViewModel
{
    class HighScoreListViewModel
    {


        #region Instance Fields

        private ObservableCollection<Player> _highScores = HighScore.Instance.HighScoreList;

        #endregion

        #region Properties

        public ObservableCollection<Player> HighScores
        {
            get { return _highScores; }
            set { _highScores = value; }
        }

       

        #endregion

        #region Constructor

        public HighScoreListViewModel()
        {
            
            
        }


        #endregion

        #region Methods

        


        #endregion


    }
}
