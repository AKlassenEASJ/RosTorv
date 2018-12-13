using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;
using RosTorv.Anders.Model;

namespace RosTorv.Anders.Persistency
{
    class PersistenceFacade
    {
        private static string jsonFileName = "PlayersAsJson1.dat";
        private static string xmlFileName = "PlayersAsXml1.dat";

        public static async void SavePlayersAsJsonAsync(ObservableCollection<Player> players)
        {
            string playersJsonString = JsonConvert.SerializeObject(players);
            SerializePlayersFileAsync(playersJsonString, jsonFileName);
        }

        public static async Task<List<Player>> LoadPersonsFromJsonAsync()
        {
            string playersJsonString = await DeSerializePlayersFileAsync(jsonFileName);
            if (playersJsonString != null)
                return (List<Player>)JsonConvert.DeserializeObject(playersJsonString, typeof(List<Player>));
            return null;
        }

        public static async void SavePlayersAsXmlAsync(ObservableCollection<Player> players)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(players.GetType());
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, players);
            SerializePlayersFileAsync(textWriter.ToString(), xmlFileName);
        }

        public static async Task<ObservableCollection<Player>> LoadPlayersFromXmlAsync()
        {
            string playersXmlString = await DeSerializePlayersFileAsync(xmlFileName);
            if (playersXmlString != null)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Player>));
                return (ObservableCollection<Player>)xmlSerializer.Deserialize(new StringReader(playersXmlString));
            }
            return null;
        }


        public static async void SerializePlayersFileAsync(string PlayersString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, PlayersString);
        }

        public static async Task<string> DeSerializePlayersFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {

                MessageDialogHelper.Show("Loading for the first time? Try Adding and Save some Persons before you are trying to Load Persons!", "File not found!");
                return null;
            }
        }

        private class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }



    }
}
