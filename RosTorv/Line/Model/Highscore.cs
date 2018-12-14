using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;
using RosTorv.Line.Handler;
using RosTorv.Line.Persistencty;

namespace RosTorv.Line.Model
{
    public class Highscore
    {
        public List<Spiller> HighScoreList { get; set; }

        public Highscore()
        {
            HighScoreList = new List<Spiller>();
            HighScoreList.Add(new Spiller("HighScore"));
            HighScoreList[0].HighScorePlads = 1;
            HighScoreList.Add(new Spiller("HighScore2"));
            HighScoreList[1].HighScorePlads = 2;
        }

        public void TjekHighScore( Spiller spiller)
        {
            if (HighScoreList.Count == 10)
            {
                if (HighScoreList[9].TotalPoint < spiller.TotalPoint)
                {
                    HighScoreList.RemoveAt(9);
                }
            }
            for (int i = 0; i < HighScoreList.Count; i++)
            {
                if (spiller.TotalPoint > HighScoreList[i].TotalPoint)
                {
                    HighScoreList.Insert(i, spiller);

                    for (int j = 0; j < HighScoreList.Count; j++)
                    {
                        HighScoreList[j].HighScorePlads = j + 1;
                    }
                    break;
                }
            }
            
        }

        public async Task SaveHighScore()
        {
            await PersistencyFacade.SaveHighScoreJsonAsync(HighScoreList);
        }

        public async Task LoadHighScoreAsync()
        {
            var loadedHighScores = await PersistencyFacade.LoadHighScoresFromJsonAsync();
            if (loadedHighScores != null)
            {
                HighScoreList.Clear();

                foreach (var spiller in loadedHighScores)
                {
                    HighScoreList.Add(spiller);
                }
            }
 
        }
    }
}
