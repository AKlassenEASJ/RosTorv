using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;
using RosTorv.Nikolai.Model;

namespace RosTorv.Nikolai.ViewModel
{
    class HighScoreVM : INotifyPropertyChanged
    {
        #region Instance Fields

        private ObservableCollection<Player> _highScoreList = HighScore.Instance.PlayerHighScore;


        #endregion

        #region Properties
        public ObservableCollection<Player> HighScoreList
        {
            get
            {
               return _highScoreList;
                
            }
            set
            {
                _highScoreList = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Constructor

        public HighScoreVM()
        {
            
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
