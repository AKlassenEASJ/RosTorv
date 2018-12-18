using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Line.Model;
using RosTorv.Line.ViewModel;

namespace RosTorv.Line.Handler
{
    public class TerningButtonHandler
    {
        /// <summary>
        /// handler til gamepagen, kan holde terninger
        /// </summary>
        public GamePageViewModel GamePageViewModel { get; set; }

        public TerningButtonHandler(GamePageViewModel gamePageViewModel)
        {
            this.GamePageViewModel = gamePageViewModel;
        }

        public void HoldTerning()
        {
            if (GamePageViewModel.SelectedTerning != null)
            {
                GamePageViewModel.Spil.Bæger.ChangeCanRoll(GamePageViewModel.SelectedTerning);
                GamePageViewModel.SelectedTerning = null;
            }

        }

        
    }
}
