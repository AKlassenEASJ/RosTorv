using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using RosTorv.Line.Commen;
using RosTorv.Line.Exceptions;
using RosTorv.Line.Model;

namespace RosTorv.Line.Persistencty
{
    class PersistencyFacade
    {
        private static string jsonFileName = "HighScoreAsJson1.bin";

        public static async void SaveStudentsAsJsonAsync(List<Spiller> spillers)
        {
            string studentsJsonString = JsonConvert.SerializeObject(spillers);
            SerializeHighScoresFileAsync(studentsJsonString, jsonFileName);
        }

        public static async Task<List<Spiller>> LoadHighScoresFromJsonAsync()
        {
            string studentsJsonString = await DeSerializeHighScoresFileAsync(jsonFileName);
            if (studentsJsonString != null)
                return (List<Spiller>)JsonConvert.DeserializeObject(studentsJsonString, typeof(List<Spiller>));
            return null;
        }

        public static async void SerializeHighScoresFileAsync(string studentsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, studentsString);
        }

        public static async Task<string> DeSerializeHighScoresFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
        }
            catch (FileNotFoundException e)
            {

                MessageDialogHelper.Show("Der var problemer med at loade HighscoreListen", "File not found!");
                return null;
            }
}
    }
}
