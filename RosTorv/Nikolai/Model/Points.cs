using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Nikolai.Model
{
    class Points
    {
        private static Points instance;
        private int _point;

        public static Points Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new Points();
                }
                return instance;
            }
            set { instance = value; }
        }

        public int point
        {
            get { return _point; }
            set
            {
                _point = value;
            }
        }

        public Spil Spil { get; set; }



        private Points()
        {
            
        }
        
    }
}
