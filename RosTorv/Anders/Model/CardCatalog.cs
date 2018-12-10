using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Anders.Model
{
    class CardCatalog
    {



        #region Instance Fields

        private static CardCatalog _instance;

        private ObservableCollection<Card> _collectionOfCards;

        private Card[] _arrayOfCards;


        #endregion


        #region Properties

        public static CardCatalog Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new CardCatalog();
                }

                return _instance;

            }
        }

        public ObservableCollection<Card> CollectionOfCards
        {
            get { return _collectionOfCards; }
            

        }



        #endregion
        

        #region Constructor

        private CardCatalog()
        {
            _arrayOfCards = new Card[8];
            FillArray();
            _collectionOfCards = new ObservableCollection<Card>();
            foreach (Card theCard in _arrayOfCards)
            {
                _collectionOfCards.Add(theCard);
                _collectionOfCards.Add(new Card(theCard.ID, theCard.FrontSide));
            }

            
            //"Assets\\ann.jpg"
        }


        #endregion

        #region Methods

        private void FillArray()
        {
            _arrayOfCards[0] = new Card("ADSE", "/Anders/Assets/FlowerCat.JPG");
            _arrayOfCards[1] = new Card("BEDS", "/Anders/Assets/an-asian-funny-cat-meme.jpg");
            _arrayOfCards[2] = new Card("CDES", "/Anders/Assets/FatCat.jpg");
            _arrayOfCards[3] = new Card("GFHR", "/Anders/Assets/GrumpyCat.png");
            _arrayOfCards[4] = new Card("JKSD", "/Anders/Assets/Heavy-Breathing-Cat.jpg");
            _arrayOfCards[5] = new Card("HISF", "/Anders/Assets/LaserCat.jpg");
            _arrayOfCards[6] = new Card("BHSD", "/Anders/Assets/SnailCat.jpg");
            _arrayOfCards[7] = new Card("SDFO", "/Anders/Assets/BlamingTheDogCat.jpg");
            //_collectionOfCards.Add(new Card("adse", "/Anders/Assets/FlowerCat.JPG"));
            //_collectionOfCards.Add(new Card("BEDS", "/Anders/Assets/Heavy-Breathing-Cat.jpg"));
            //_collectionOfCards.Add(new Card("CDSE", "/Anders/Assets/GrumpyCat.png"));
        }

        public void ResetCards()
        {
            _collectionOfCards.Clear();
            foreach (Card theCard in _arrayOfCards)
            {
                _collectionOfCards.Add(theCard);
                _collectionOfCards.Add(new Card(theCard.ID, theCard.FrontSide));
            }

        }


        #endregion












    }
}
