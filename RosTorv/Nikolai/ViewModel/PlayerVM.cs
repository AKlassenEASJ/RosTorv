using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Nikolai.Model;

namespace RosTorv.Nikolai.ViewModel
{
    class PlayerVM
    {
        private Player _newPlayer;

        public Player NewPlayer
        {
            get { return _newPlayer; }
            set { _newPlayer = value; }
        }

    }
}
