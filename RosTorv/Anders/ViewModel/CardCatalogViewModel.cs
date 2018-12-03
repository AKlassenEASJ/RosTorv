using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RosTorv.Anders.Handlers;
using RosTorv.Anders.Model;
using RosTorv.Annotations;
using RosTorv.Common;

namespace RosTorv.Anders.ViewModel
{
    public class CardCatalogViewModel : INotifyPropertyChanged
    {

        #region Instance Fields

        private ObservableCollection<Card> _observableCollectionOfCards = CardCatalog.Instance.CollectionOfCards;
        private Game _theGame = Game.Instance;

        private ICommand _flipCommand;

        private Card _selectedCard;
        private int _selectedIndex = -1;


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
            set
            {
                _selectedCard = value;
                OnPropertyChanged();
            }
        }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged();
            }
        }

        public Game TheGame
        {
            get { return _theGame; }
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


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
