using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Anders.Handlers;
using RosTorv.Anders.Persistency;

namespace RosTorv.Anders.Model
{
    [Serializable]
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
            get
            {
                
                return _highScoreList;
            }
            set { _highScoreList = value; }
        }

        

        #endregion

        #region Constructor

        private HighScore()
        {


            


        }

        #endregion

        #region Methods

        public async void GetHighScoreList()
        {
            var highscorelist = await PersistenceFacade.LoadPersonsFromJsonAsync();
            
            if (_highScoreList == null)
            {
                _highScoreList = new ObservableCollection<Player>();
                
            }
            _highScoreList.Clear();

            if (highscorelist != null)
            {
                foreach (Player player in highscorelist)
                {
                    _highScoreList.Add(player);
                }
            }
        }



        #endregion

    }
}
