using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Anders.Model;
using RosTorv.Anders.ViewModel;

namespace RosTorv.Anders.Handlers
{
    public class MatchHandler
    {

        #region Instance Fields

        private int _numberOfFlips;


        #endregion

        #region Properties

        public CardCatalogViewModel CardCatalogViewModel { get; set; }

        public int NumberOfFlips
        {
            get { return _numberOfFlips; }
            set { _numberOfFlips = value; }
        }

        public CardHandler CardHandler { get; set; }


        #endregion

        #region Constructor

        public MatchHandler(CardCatalogViewModel cardCatalog, CardHandler cardHandler)
        {
            CardCatalogViewModel = cardCatalog;
            CardHandler = cardHandler;

        }


        #endregion

        #region Methods

        public void Match()
        {
            List<Card> templListOfCards = new List<Card>();
            Card cardholder = null;
            foreach (Card card in CardCatalogViewModel.ObservableCollectionOfCards)
            {
                if (card.ShownSide == card.FrontSide)
                {
                    if (cardholder == null)
                    {
                        cardholder = card;
                    }
                    templListOfCards.Add(card);
                    if (templListOfCards.Count == 2 && templListOfCards[0].ID == templListOfCards[1].ID)
                    {
                        cardholder.ShownSide = null;
                        card.ShownSide = null;
                    }
                    
                }
                

            }

            
            
        }


        #endregion








    }
}
