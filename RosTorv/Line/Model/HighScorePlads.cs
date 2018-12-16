using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Line.Model
{
    public class HighScorePlads
    {
        public string Name { get; set; }
        public int Plads { get; set; }
        public int Point { get; set; }

        public HighScorePlads(string name, int plads, int point)
        {
            Name = name;
            Plads = plads;
            Point = point;
        }
    }
}
