using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Anders.ViewModel;
using RosTorv.Common;

namespace RosTorv.Anders.Handlers
{
    public class CardHandler
    {



        public CardCatalogViewModel CardCatalogViewModel { get; set; }

        public MatchHandler MatchHandler { get; set; }


        public CardHandler(CardCatalogViewModel cardCatalog)
        {
            CardCatalogViewModel = cardCatalog;
            MatchHandler = new MatchHandler(CardCatalogViewModel,this);


        }

        
        



        public void TurnOver()
        {
            if (CardCatalogViewModel.SelectedCard.ShownSide == CardCatalogViewModel.SelectedCard.BackSide)
            {
                CardCatalogViewModel.SelectedCard.ShownSide = CardCatalogViewModel.SelectedCard.FrontSide;
                MatchHandler.CheckMatch();
            }
            //else if (CardCatalogViewModel.SelectedCard.ShownSide == CardCatalogViewModel.SelectedCard.FrontSide)
            //{
            //    CardCatalogViewModel.SelectedCard.ShownSide = CardCatalogViewModel.SelectedCard.BackSide;
            //}

        }

    }
}
