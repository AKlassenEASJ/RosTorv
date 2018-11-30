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
        private Game _theGame = Game.Instance;


        #endregion

        #region Properties

        public CardCatalogViewModel CardCatalogViewModel { get; set; }

        public int NumberOfFlips
        {
            get { return _numberOfFlips; }
            set { _numberOfFlips = value; }
        }

        public CardHandler CardHandler { get; set; }

        public Game Game { get; set; }


        #endregion

        #region Constructor

        public MatchHandler(CardCatalogViewModel cardCatalog, CardHandler cardHandler)
        {
            CardCatalogViewModel = cardCatalog;
            CardHandler = cardHandler;

        }


        #endregion

        #region Methods



        public void CheckMatch()
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
                        Match(cardholder, card);
                    }
                    else if (templListOfCards.Count == 2 && templListOfCards[0].ID != templListOfCards[1].ID)
                    {
                        NoMatch(cardholder, card);
                    }

                }


            }

        }


        public void Match(Card card1, Card card2)
        {
            card1.ShownSide = null;
            card2.ShownSide = null;
            Game.Instance.IncreaseTurns();
            Game.Instance.AddPointsToScore(500);




        }

        public void NoMatch(Card card1, Card card2)
        {
            Game.Instance.IncreaseTurns();
            card1.ShownSide = card1.BackSide;
            card2.ShownSide = card2.BackSide;
            //CardCatalogViewModel.SelectedIndex = -1;
            //CardCatalogViewModel.SelectedCard = null;
        }







        #endregion








    }
}
