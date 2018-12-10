using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Anders.Model
{
    class HighScore
    {

        #region Instance Fields

        private static HighScore _instance;

        private ObservableCollection<Player> _highScoreList;


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
            
        }

        public ObservableCollection<Player> HighScoreList
        {
            get { return _highScoreList; }
            set { _highScoreList = value; }
        }


        #endregion

        #region Constructor

        private HighScore()
        {
            _highScoreList = new ObservableCollection<Player>();
            //HighScoreList.Add(new Player("Folketinget", 1000000, 0));
            HighScoreList.Add(new Player("Kommunen", 20000, 1));
            HighScoreList.Add(new Player("Bente", 3000, 20));


        }

        #endregion

        #region Methods



        #endregion

    }
}
