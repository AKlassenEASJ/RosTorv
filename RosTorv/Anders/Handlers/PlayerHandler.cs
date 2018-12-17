using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Anders.Exceptions;
using RosTorv.Anders.Model;
using RosTorv.Anders.Persistency;
using RosTorv.Anders.View;
using RosTorv.Anders.ViewModel;
using RosTorv.Common;

namespace RosTorv.Anders.Handlers
{
    class PlayerHandler
    {

        #region Instance Fields



        #endregion

        #region Properties

        public PlayerViewModel PlayerViewModel { get; set; }

        public HighScore HighScore { get; set; }

        


        #endregion

        #region Constructor

        public PlayerHandler(PlayerViewModel playerViewModel)
        {
            PlayerViewModel = playerViewModel;
            HighScore = HighScore.Instance;
            HighScore.GetHighScoreList();
            
        }

        


        #endregion

        #region Methods

        public void CreateNewPlayer()
        {
            try
            {
                Player tempPlayer = new Player(PlayerViewModel.NewPlayer.Name, PlayerViewModel.TheGame.Score,
                    PlayerViewModel.TheGame.Turns);

                int lengthOfHighscoreList = 10;

                int removeIndicator = lengthOfHighscoreList + 1;

                int lastInList = HighScore.HighScoreList.Count - 1;




                for (int index = 0; index < lengthOfHighscoreList; index++)
                {
                    if (HighScore.HighScoreList.Count == 0)
                    {
                        HighScore.HighScoreList.Add(tempPlayer);
                        break;
                    }
                    else if (HighScore.HighScoreList.Count < lengthOfHighscoreList &&
                             tempPlayer.PlayerScore <= HighScore.HighScoreList[lastInList].PlayerScore)
                    {
                        HighScore.HighScoreList.Add(tempPlayer);
                        break;

                    }
                    else if (tempPlayer.PlayerScore > HighScore.HighScoreList[index].PlayerScore &&
                             (index < lengthOfHighscoreList - 1 ||
                              HighScore.HighScoreList.Count == lengthOfHighscoreList))
                    {
                        HighScore.HighScoreList.Insert(index, tempPlayer);
                        break;
                    }
                }

                if (HighScore.HighScoreList.Count == removeIndicator)
                {
                    RemoveFromHighScore(lengthOfHighscoreList + 1, tempPlayer);
                }

                NavigationService.Navigate(typeof(HighScoreListPage));

            }
            catch (NameIsBlankException blankException)
            {
                MessageDialogHelper.Show(blankException.Message, "Error");

            }
            catch (NameIsInappropriateException inappropriateException)
            {
                MessageDialogHelper.Show(inappropriateException.Message, "Name is not allowed");
            }

            

            PersistenceFacade.SavePlayersAsJsonAsync(HighScore.HighScoreList);






        }

        private void RemoveFromHighScore(int count, Player player)
        {
            

                for (int index = 0; index < count; index++)
                {
                    if (player.PlayerScore > HighScore.HighScoreList[index].PlayerScore)
                    {

                        HighScore.HighScoreList.RemoveAt(count - 1);
                        break;
                        
                    }


                }
            

        }


        #endregion

    }
}
