using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Anders.Model;
using RosTorv.Anders.ViewModel;

namespace RosTorv.Anders.Handlers
{
    class GameHandler
    {
        #region Instance Fields



        #endregion

        #region Properties

        public StartingPageViewModel StartingPageViewModel { get; set; }

        public CardCatalog CardCatalog { get; set; }

        public Game Game { get; set; }


        #endregion

        #region Constructor

        public GameHandler(StartingPageViewModel startingPageViewModel)
        {
            StartingPageViewModel = startingPageViewModel;
            CardCatalog = CardCatalog.Instance;
            Game = Game.Instance;

        }


        #endregion

        #region Methods

        public void Reset()
        {
            Game = null;
            CardCatalog.ResetCards();
        }

        #endregion
    }
}
