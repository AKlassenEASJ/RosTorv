using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using RosTorv.Line.ViewModel;

namespace RosTorv.Line.Persistencty
{
    /// <summary>
    /// Formålet et at kunne gemmet navn på spiller
    /// </summary>
    class PersistencyFacadeName
    {
        private static string jsonFileName = "YatzyNameAsJson.Json";

        public static async Task SerializeNameAsync(string name)
        {
            string spillereJsonString = JsonConvert.SerializeObject(name);
            await SaveNameFileAsync(spillereJsonString, jsonFileName);
        }

        public static async Task<string> DeSerializeNameAsync()
        {
            string nameJsonString = await LoadNamefilesFromJsonAsync(jsonFileName);
            if (nameJsonString != null)
                return JsonConvert.DeserializeObject<string>(nameJsonString);
            return null;
        }

        public static async Task SaveNameFileAsync(string spillerString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, spillerString);
        }

        public static async Task<string> LoadNamefilesFromJsonAsync(String fileName)
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
