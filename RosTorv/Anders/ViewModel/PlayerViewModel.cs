using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RosTorv.Anders.Handlers;
using RosTorv.Anders.Model;
using RosTorv.Common;

namespace RosTorv.Anders.ViewModel
{
    class PlayerViewModel
    {



        #region Instance Fields

        private Game _theGame = Game.Instance;

        private ICommand _newPlayerCommand;

        private Player _newPlayer = new Player(Game.Instance.Score, Game.Instance.Turns);

        #endregion

        #region Properties

        public Player NewPlayer
        {
            get { return _newPlayer; }
            set { _newPlayer = value; }

        }

        public Game TheGame
        {
            get { return _theGame; }
            set { _theGame = value; }
        }

        public ICommand NewPlayerCommand
        {
            get { return _newPlayerCommand; }
            set { _newPlayerCommand = value; }
        }

        public PlayerHandler PlayerHandler { get; set; }



        #endregion

        #region Constructor

        public PlayerViewModel()
        {
            PlayerHandler = new PlayerHandler(this);
            _newPlayerCommand = new RelayCommand(PlayerHandler.CreateNewPlayer);

        }


        #endregion

        #region Methods



        #endregion


    }
}
