using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Sofus.Model
{
    public class Butik
    {
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public string Website { get; set; }
        public List<string> Kategorier { get; set; }

        public Butik()
        {
            
        }
    }
}
