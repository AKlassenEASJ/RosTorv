using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Anders.Handlers;
using RosTorv.Anders.Model;

namespace RosTorv.Anders.ViewModel
{
    public class CardCatalogViewModel
    {

        #region Instance Fields

        private ObservableCollection<Card> _observableCollectionOfCards = CardCatalog.Instance.CollectionOfCards;

        //private string Imagesource = 

        #endregion

        #region Properties

        public ObservableCollection<Card> ObservableCollectionOfCards
        {
            get
            {
                CardListRandomizier.Shuffle(_observableCollectionOfCards);
                return _observableCollectionOfCards;
            }
        }

        

        #endregion

        #region Constructor

        public CardCatalogViewModel()
        {
            
        }

        #endregion

        #region Methods



        #endregion







    }
}
