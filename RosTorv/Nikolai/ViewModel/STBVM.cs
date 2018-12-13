using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.Nikolai.Common;
using RosTorv.Nikolai.Model;

namespace RosTorv.Nikolai.ViewModel
{
    public class STBVM : INotifyPropertyChanged
    {
        private Number _selectedNumber;
        //private int _diceCounter;

        public Spil Game { get; set; }

        public STBVM()
        {
            Game = new Spil();
            RollCommand = new RelayCommand(Game.RollAll);
            RemoveCommand = new RelayCommand(Game.CheckNumbers);
            RulePage = new RelayCommand(Game.RulePage);
            ResetCommand = new RelayCommand(Game.Reset);

        }

        public Number SelectedNumber
        {
            get { return _selectedNumber; }
            set
            {
                _selectedNumber = value;
                OnPropertyChanged();
                //SelectedNumber.ShadowOpacity = 0;
                if (_selectedNumber!= null)
                    Game.SelectedNumbers.Add(_selectedNumber);
            }
        }

        //public int DiceCounter
        //{
        //    get { return; }
        //    set
        //    {
        //        Game.DiceCounter = value;
        //        OnPropertyChanged();
        //    }

        //}
        
        public ICommand RulePage { get; set; }
        public ICommand ResetCommand { get; set; }

        public ICommand RemoveCommand { get; set; }


        public ICommand RollCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
