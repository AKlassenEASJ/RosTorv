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

        public static async Task SerializeHighScoreAsync(List<HighScorePlads> spillers)
        {
            string spillereJsonString = JsonConvert.SerializeObject(spillers);
            await SaveHighScoreFileAsync(spillereJsonString, jsonFileName);
        }

        public static async Task<List<HighScorePlads>> DeSerializeHighScoresAsync()
        {
            string spillereJsonString = await LoadHighScoresfilesFromJsonAsync(jsonFileName);
            if (spillereJsonString != null)
                return JsonConvert.DeserializeObject<List<HighScorePlads>>(spillereJsonString);
            return null;
        }

        public static async Task SaveHighScoreFileAsync(string spillerString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, spillerString);
        }

        public static async Task<string> LoadHighScoresfilesFromJsonAsync(String fileName)
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

