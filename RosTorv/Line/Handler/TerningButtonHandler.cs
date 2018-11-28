using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            GamePageViewModel.Bæger.ChangeCanRoll(GamePageViewModel.SelectedIndex);
        }
        //public void HoldTerning1()
        //{
        //    GamePageViewModel.ViewTerning1.ChangeCanRoll();
        //    ChangeColor(GamePageViewModel.BackgroundColor1);
        //    GamePageViewModel.BackgroundColor1 = _newColor;
        //}
        //public void HoldTerning2()
        //{
        //    GamePageViewModel.ViewTerning2.ChangeCanRoll();
        //    ChangeColor(GamePageViewModel.BackgroundColor2);
        //    GamePageViewModel.BackgroundColor2 = _newColor;
        //}
        //public void HoldTerning3()
        //{
        //    GamePageViewModel.ViewTerning3.ChangeCanRoll();
        //    ChangeColor(GamePageViewModel.BackgroundColor3);
        //    GamePageViewModel.BackgroundColor3 = _newColor;
        //}
        //public void HoldTerning4()
        //{
        //    GamePageViewModel.ViewTerning4.ChangeCanRoll();
        //    ChangeColor(GamePageViewModel.BackgroundColor4);
        //    GamePageViewModel.BackgroundColor4 = _newColor;
        //}
        //public void HoldTerning5()
        //{
        //    GamePageViewModel.ViewTerning5.ChangeCanRoll();
        //    ChangeColor(GamePageViewModel.BackgroundColor5);
        //    GamePageViewModel.BackgroundColor5 = _newColor;
        //}

        
    }
}
