using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;
using RosTorv.Line.Exceptions;
using RosTorv.Line.Handler;
using RosTorv.Line.Persistencty;

namespace RosTorv.Line.Model
{
    public class Highscore
    {
        public List<HighScorePlads> HighScoreList { get; set; }

        public Highscore()
        {
            HighScoreList = new List<HighScorePlads>();
            HighScoreList.Add(new HighScorePlads("HighScore", 1, 0));

        }

        public void TjekHighScore( Spiller spiller)
        {
            if (HighScoreList.Count == 10)
            {
                if (HighScoreList[9].Point < spiller.PointFelter[17].Point)
                {
                    HighScoreList.RemoveAt(9);
                }
            }
            for (int i = 0; i < HighScoreList.Count; i++)
            {
                if (spiller.PointFelter[17].Point > HighScoreList[i].Point)
                {
                    HighScoreList.Insert(i, new HighScorePlads(spiller.Name, i, spiller.PointFelter[17].Point));

                    for (int j = 0; j < HighScoreList.Count; j++)
                    {
                        HighScoreList[j].Plads = j + 1;
                    }
                    break;
                }
            }
            
        }

        public async Task SaveHighScore()
        {
            await PersistencyFacade.SerializeHighScoreAsync(HighScoreList);
        }

        public async Task LoadHighScoreAsync()
        {
            var loadedHighScores = await PersistencyFacade.DeSerializeHighScoresAsync();
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
