using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RosTorv.Anders.Handlers;
using RosTorv.Common;

namespace RosTorv.Anders.ViewModel
{
    class StartingPageViewModel
    {
        #region Instance Fields

        private ICommand _resetCommand;


        #endregion

        #region Properties

        public ICommand ResetCommand
        {
            get { return _resetCommand; }
            set { _resetCommand = value; }
        }

        public GameHandler GameHandler { get; set; }

        #endregion

        #region Constructor

        public StartingPageViewModel()
        {
            GameHandler = new GameHandler(this);
            _resetCommand = new RelayCommand(GameHandler.Reset);
        }


        #endregion

        #region Methods



        #endregion




    }
}
