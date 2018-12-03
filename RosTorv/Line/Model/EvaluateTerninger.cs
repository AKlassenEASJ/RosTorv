using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Line.Model
{
    public class EvaluateTerninger
    {
        private int value = 0;
        public Spil Spil { get; set; }
        private Dictionary<int, int> _terninsværdi = new Dictionary<int, int>();
            
        public EvaluateTerninger(Spil spil)
        {
            this.Spil = spil;
            _terninsværdi.Add(1, 0);
            _terninsværdi.Add(2, 0);
            _terninsværdi.Add(3, 0);
            _terninsværdi.Add(4, 0);
            _terninsværdi.Add(5, 0);
            _terninsværdi.Add(6, 0);
        }

        public void NulStilVærdi()
        {
            for (int i = 1; i < 7; i++)
            {
                _terninsværdi[i] = 0;
            }
        }

        public void GetTerningsVærdi()
        {
            for (int i = 1; i < 7; i++)
            {
                foreach (Terning terning in Spil.Bæger.Terninger)
                {
                    if (terning.Eyes == i)
                    {
                        _terninsværdi[i]++;
                    }
                } 
            }
        }





    }
}
