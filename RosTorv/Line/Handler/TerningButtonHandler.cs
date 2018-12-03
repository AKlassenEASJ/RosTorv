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
        public GamePageViewModel GamePageViewModel { get; set; }

        public TerningButtonHandler(GamePageViewModel GamePageViewModel)
        {
            this.GamePageViewModel = GamePageViewModel;
        }

        public void HoldTerning()
        {
            GamePageViewModel.Spil.Bæger.ChangeCanRoll(GamePageViewModel.SelectedTerningIndex);
        }

        
    }
}
