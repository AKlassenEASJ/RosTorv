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
            return JsonConvert.DeserializeObject<List<string>>(kategorierJson);
        }

        public static IEnumerable<Butik> ReadAndDeserializeButikker()
        {
            string butikkerJson = File.ReadAllText("Sofus/Data/butikker.json");
            return JsonConvert.DeserializeObject<List<Butik>>(butikkerJson);
        }

    }
}