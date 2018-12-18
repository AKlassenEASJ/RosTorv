using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCode.Common;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using RosTorv.Common;
using RosTorv.Nikolai.Model;
using RosTorv.Nikolai.View;
using RosTorv.Nikolai.ViewModel;

namespace RosTorv.Nikolai.Handlers
{
    class PlayerHandler
    {
        public void Confirm()
        {
            Player p1 = new Player (PlayerVm.NewPlayer.Name,Points.Instance.point);
            //for (int i = 0; i < 10; i++)
            //{
            //    if (HighScore.Instance.PlayerHighScore.Count == 0)
            //    {
            //        HighScore.Instance.PlayerHighScore.Add(p1);
            //        HighScore.Instance.PlayerHighScore.Sort
            //    }
            //}
            HighScore.Instance.PlayerHighScore.Add(p1);
            List<Player> sList = HighScore.Instance.PlayerHighScore.ToList();
            sList.Sort();
            HighScore.Instance.PlayerHighScore.Clear();
            foreach (var player in sList)
            {
                HighScore.Instance.PlayerHighScore.Add(player);
            }

            NavigationService.Navigate(typeof(HighScorePage));

        }
        public STBVM Stbvm { get; set; }

        public PlayerHandler(PlayerVM playerVm)
        {
            Stbvm = new STBVM();
            PlayerVm = playerVm;
        }

        public PlayerVM PlayerVm { get; set; }
    }
}
