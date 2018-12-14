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

        public static async Task SaveHighScoreJsonAsync(List<Spiller> spillers)
        {
            string spillereJsonString = JsonConvert.SerializeObject(spillers);
            await SerializeHighScoresFileAsync(spillereJsonString, jsonFileName);
        }

        public static async Task<List<Spiller>> LoadHighScoresFromJsonAsync()
        {
            string spillereJsonString = await DeSerializeHighScoresFileAsync(jsonFileName);
            if (spillereJsonString != null)
                return JsonConvert.DeserializeObject<List<Spiller>>(spillereJsonString);
            return null;
        }

        public static async Task SerializeHighScoresFileAsync(string spillerString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, spillerString);
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

