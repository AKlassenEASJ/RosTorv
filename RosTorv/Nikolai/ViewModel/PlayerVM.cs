using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.Nikolai.Handlers;
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

        private PlayerHandler _handler;

        public PlayerHandler Handler
        {
            get { return _handler; }
            set { _handler = value; }
        }

        public STBVM Stbvm { get; set; }
        public Points Points { get; set; }


        public PlayerVM()
        {
            Handler = new PlayerHandler(this);
            ConfirmCommand = new RelayCommand(Handler.Confirm);
            Stbvm = new STBVM();
            Points = Points.Instance;
            NewPlayer = new Player("", Points.point);
        }
        public ICommand ConfirmCommand { get; set; }


    }
}
