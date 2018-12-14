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
        private static string jsonFileName = "YatzyHighScoreAsJson.Json";

        public static async Task SaveStudentsAsJsonAsync(List<Spiller> spillers)
        {
            string studentsJsonString = JsonConvert.SerializeObject(spillers);
            await SerializeHighScoresFileAsync(studentsJsonString, jsonFileName);
        }

        public static async Task<List<Spiller>> LoadHighScoresFromJsonAsync()
        {
            string studentsJsonString = await DeSerializeHighScoresFileAsync(jsonFileName);
            if (studentsJsonString != null)
                return JsonConvert.DeserializeObject<List<Spiller>>(studentsJsonString);
            return null;
        }

        public static async Task SerializeHighScoresFileAsync(string studentsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, studentsString);
        }

        public static async Task<string> DeSerializeHighScoresFileAsync(String fileName)
        {
           
            StorageFile localFile = await ApplicationData.Current.LocalFolder.TryGetItemAsync(fileName) as StorageFile;
            if (localFile != null)
            {
                return await FileIO.ReadTextAsync(localFile);
            }
            else
            {
                return null;
            }
                
        }
            
    }
}

