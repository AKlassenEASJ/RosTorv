using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Anders.Model
{
    public class Card
    {



        #region Instance Fields 
        private string _iD;
        private string _imagesource;


        #endregion

        #region Properties

        public string ID
        {
            get { return _iD; }
        }

        public string Imagesource
        {
            get { return _imagesource; }
            set { _imagesource = value; }
        }

        #endregion

        #region Constructor

        public Card(string id, string imagesource)
        {
            _iD = id;
            _imagesource = imagesource;

        }


        #endregion

        #region Methods

        

        #endregion




    }
}
