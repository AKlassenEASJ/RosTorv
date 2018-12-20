using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Windows.Storage;

namespace RosTorv.Common
{
    public class SharedScore
    {
        private static Dictionary<string, int> _scores;

        static SharedScore()
        {
            _scores = LoadScore();
        }

        /// <summary>
        /// Return score for a player.
        /// </summary>
        /// <param name="name">Players specified name</param>
        /// <returns>Score for specified name</returns>
        public static int GetScore(string name)
        {
            if (_scores.TryGetValue(name, out int score))
                return score;
            else
                return 0;
        }

        /// <summary>
        /// Adds an amount of scorepoints to players overall score.
        /// </summary>
        /// <param name="name">Players specified name</param>
        /// <param name="scoreAmount">The amount of score to be added</param>
        public static void AddScore(string name, int scoreAmount)
        {
            if (PlayerExist(name))
                _scores[name] += scoreAmount;
            else
                _scores.Add(name, scoreAmount);

            if (_scores[name] < 0)
                _scores[name] = 0;

            SaveScore();
        }

        /// <summary>
        /// Removes an amount of scorepoints from player overall score.
        /// </summary>
        /// <param name="name">Players specified name</param>
        /// <param name="scoreAmount">The amount of score to be added</param>
        public static void RemoveScore(string name, int scoreAmount)
        {
            if (PlayerExist(name))
                _scores[name] -= scoreAmount;

            SaveScore();
        }

        /// <summary>
        /// Checks if players name already stored.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool PlayerExist(string name)
        {
            return _scores.ContainsKey(name);
        }

        /// <summary>
        /// Saves all player scores to a file.
        /// </summary>
        private async static Task SaveScore()
        {
            string scoreJson = JsonConvert.SerializeObject(_scores);
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("scores.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, scoreJson);
        }

        private static Dictionary<string, int> LoadScore()
        {
            string scoreJson = LoadFile().Result;

            return scoreJson == null 
                ? new Dictionary<string, int>() 
                : JsonConvert.DeserializeObject<Dictionary<string, int>>(scoreJson);
        }

        private static async Task<string> LoadFile()
        {
            string scoreJson = null;

            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("scores.json");
                scoreJson = await FileIO.ReadTextAsync(file);
            }
            catch (System.IO.FileNotFoundException e) { }

            return scoreJson;
        }
    }
}
