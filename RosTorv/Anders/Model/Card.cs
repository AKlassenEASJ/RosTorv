using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

namespace RosTorv.Anders.Model
{
    public class Card : INotifyPropertyChanged
    {



        #region Instance Fields 
        private string _iD;
        private string _frontSide;
        private string _backSide = "/Anders/Assets/cardback_65.png";
        private string _shownSide = "/Anders/Assets/cardback_65.png";
        private bool _isMatched; //TODO: skal implementeres


        #endregion

        #region Properties

        public string ID
        {
            get { return _iD; }
        }

        public string FrontSide
        {
            get { return _frontSide; }
            set { _frontSide = value; }//TODO:Skal fjernes
        }

        public string BackSide
        {
            get { return _backSide; }
            
        }

        public string ShownSide
        {
            get { return _shownSide; }
            set
            {
                _shownSide = value; 
                OnPropertyChanged();
            }
        }

        public bool IsMatched//Behøves nok ikke mere
        {
            get { return _isMatched; }
            set { _isMatched = value; }
        }


        #endregion

        #region Constructor

        public Card(string id, string frontSide)
        {
            _iD = id;
            _frontSide = frontSide;

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
