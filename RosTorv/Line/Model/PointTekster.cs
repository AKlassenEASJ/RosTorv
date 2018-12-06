using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Line.Model
{
   public class PointTekster
    {
        public PointTekst PointTekst { get; set; }
        public List<PointTekst> PointTeksterlist { get; set; }
        public PointTekster()
        {
            PointTeksterlist = new List<PointTekst>();
            PointTeksterlist.Add(new PointTekst("Enere"));
            PointTeksterlist.Add(new PointTekst("Toere"));
            PointTeksterlist.Add(new PointTekst("Treere"));
            PointTeksterlist.Add(new PointTekst("Firere"));
            PointTeksterlist.Add(new PointTekst("Femmere"));
            PointTeksterlist.Add(new PointTekst("Seksere"));
            PointTeksterlist.Add(new PointTekst("Bonus"));
            PointTeksterlist.Add(new PointTekst("1 Par"));
            PointTeksterlist.Add(new PointTekst("2 Par"));
            PointTeksterlist.Add(new PointTekst("3 ens"));
            PointTeksterlist.Add(new PointTekst("4 ens"));
            PointTeksterlist.Add(new PointTekst("Høj"));
            PointTeksterlist.Add(new PointTekst("Lav"));
            PointTeksterlist.Add(new PointTekst("Fuldt Hus"));
            PointTeksterlist.Add(new PointTekst("Chance"));
            PointTeksterlist.Add(new PointTekst("Yatzy"));
            PointTeksterlist.Add(new PointTekst("Sum"));
        }
    }

    public class PointTekst
    {
        public string Tekst { get; set; }

        public PointTekst( string tekst)
        {
            Tekst = tekst;

        }
    }
}
