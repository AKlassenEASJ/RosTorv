using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RosTorv.Sofus.Model;
using System.Linq;

namespace RosTorv.Sofus
{
    public static class Persistency
    {
        public static IEnumerable<string> ReadAndDeserializeKategorier()
        {
            string kategorierJson = File.ReadAllText("Sofus/Data/kategorier.json");
            return JsonConvert.DeserializeObject<IEnumerable<string>>(kategorierJson);
        }

        public static IEnumerable<Butik> ReadAndDeserializeButikker()
        {
            string butikkerJson = File.ReadAllText("Sofus/Data/butikker.json");
            return JsonConvert.DeserializeObject<IEnumerable<Butik>>(butikkerJson);
        }

        public static IEnumerable<string> ReadAndDeserializeButikNavne()
        {
            string navneJson = File.ReadAllText("Sofus/Data/butikNavne.json");
            return JsonConvert.DeserializeObject<IEnumerable<string>>(navneJson);
        }
    }
}