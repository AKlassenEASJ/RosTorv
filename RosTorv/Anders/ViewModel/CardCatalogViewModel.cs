using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RosTorv.Anders.Handlers;
using RosTorv.Anders.Model;
using RosTorv.Common;

namespace RosTorv.Anders.ViewModel
{
    public class CardCatalogViewModel
    {

        #region Instance Fields

        private ObservableCollection<Card> _observableCollectionOfCards = CardCatalog.Instance.CollectionOfCards;

        private ICommand _flipCommand;

        private Card _selectedCard;
        private static int _selectedIndex;
        

        #endregion

        #region Properties

        public ObservableCollection<Card> ObservableCollectionOfCards
        {
            get
            {

                return CardListRandomizier.Shuffle(_observableCollectionOfCards);
                
            }
        }

        public ICommand FlipCommand
        {
            get { return _flipCommand; }
            set {  _flipCommand = value; }
        }

        public Card SelectedCard
        {
            get { return _selectedCard; }
            set { _selectedCard = value; }
        }

        public static int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }


        public CardHandler CardHandler { get; set; }



        #endregion

        #region Constructor

        public CardCatalogViewModel()
        {
            CardHandler = new CardHandler(this);
            _flipCommand = new RelayCommand(CardHandler.TurnOver);
            
            
        }

        #endregion

        #region Methods



        #endregion







    }
}
