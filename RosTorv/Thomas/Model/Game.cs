using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using RosTorv.Annotations;

namespace RosTorv.Thomas.Model
{
    class Game : INotifyPropertyChanged
    {
        private AI _friendComputer;
        private Dice _playerDie1;
        private Dice _playerDie2;
        private Dice _playerDie3;
        private Dice _playerDie4;
        private Dice _playerDie5;

        private Dice _computerDie1;
        private Dice _computerDie2;
        private Dice _computerDie3;
        private Dice _computerDie4;
        private Dice _computerDie5;

        private bool _canStartGame;
        private bool _canClickRoll;
        private bool _canPassTurn;
        private int _rollsLeft;

        private AI FriendComputer
        {
            get { return _friendComputer; }
        }
        public Dice PlayerDie1
        {
            get { return _playerDie1; }
            set { _playerDie1=value; }
        }
        public Dice PlayerDie2
        {
            get { return _playerDie2; }
            set { _playerDie2 = value; }
        }
        public Dice PlayerDie3
        {
            get { return _playerDie3; }
            set { _playerDie3 = value; }
        }
        public Dice PlayerDie4
        {
            get { return _playerDie4; }
            set { _playerDie4 = value; }
        }
        public Dice PlayerDie5
        {
            get { return _playerDie5; }
            set { _playerDie5 = value; }
        }
        public Dice ComputerDie1
        {
            get { return _computerDie1; }
            set { _computerDie1 = value; }
        }
        public Dice ComputerDie2
        {
            get { return _computerDie2; }
            set { _computerDie2 = value; }
        }
        public Dice ComputerDie3
        {
            get { return _computerDie3; }
            set { _computerDie3 = value; }
        }
        public Dice ComputerDie4
        {
            get { return _computerDie4; }
            set { _computerDie4 = value; }
        }
        public Dice ComputerDie5
        {
            get { return _computerDie5; }
            set { _computerDie5 = value; }
        }

        public bool CanStartGame
        {
            get { return _canStartGame; }
            set { _canStartGame = value;
                OnPropertyChanged();    }
        }
        public bool CanClickRoll
        {
            get { return _canClickRoll; }
            set
            {
                _canClickRoll = value;
                OnPropertyChanged();
            }
        }
        public bool CanPassTurn
        {
            get { return _canPassTurn; }
            set
            {
                _canPassTurn = value;
                OnPropertyChanged();
            }
        }
        public int RollsLeft
        {
            get { return _rollsLeft; }
            set
            {
                _rollsLeft = value;
                OnPropertyChanged();
            }
        }

        public Game()
        {
            _playerDie1 = new Dice();
            _playerDie2 = new Dice();
            _playerDie3 = new Dice();
            _playerDie4 = new Dice();
            _playerDie5 = new Dice();

            _friendComputer=new AI();

            _computerDie1 = new Dice();
            _computerDie2 = new Dice();
            _computerDie3 = new Dice();
            _computerDie4 = new Dice();
            _computerDie5 = new Dice();

            _canStartGame = true;
            _canClickRoll = false;
            _canPassTurn = false;
            _rollsLeft = 0;

        }

        public void EndGame()
        {
            CanClickRoll = false;
            CanStartGame = true;
        }

        

        public void RollCheckedPlayer()
        {
            PlayerDie1.Roll();
            PlayerDie2.Roll();
            PlayerDie3.Roll();
            PlayerDie4.Roll();
            PlayerDie5.Roll();
            RollsLeft = RollsLeft - 1;
        }

        public void RollCheckedPc()
        {
            if(RollsLeft!=2)
            { WhichCanRoll(FriendComputer.DecideWhatToRoll(ComputerDie1.FaceValue, ComputerDie2.FaceValue, ComputerDie3.FaceValue, ComputerDie4.FaceValue, ComputerDie5.FaceValue));}
            ComputerDie1.Roll();
            ComputerDie2.Roll();
            ComputerDie3.Roll();
            ComputerDie4.Roll();
            ComputerDie5.Roll();
        }
        private void WhichCanRoll(int Case)
        {
            switch (Case)
            {
                case 0:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = true;
                    return;
                case 1:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = false;
                    return;
                case 2:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = true;
                    return;
                case 3:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = true;
                    return;
                case 4:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = true;
                    return;
                case 5:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = true;
                    return;
                case 6:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = true;
                    return;
                case 7:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = false;
                    return;
                case 8:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = true;
                    return;
                case 9:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = false;
                    return;
                case 10:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = false;
                    return;
                case 11:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = true;
                    return;
                case 12:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = true;
                    return;
                case 13:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = false;
                    return;
                case 14:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = true;
                    return;
                case 15:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = true;
                    return;
                case 16:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = false;
                    return;
                case 17:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = false;
                    return;
                case 18:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = false;
                    return;
                case 19:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = false;
                    return;
                case 20:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = false;
                    return;
                case 21:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = true;
                    return;
                case 22:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = true;
                    ComputerDie5.CanRoll = false;
                    return;
                case 23:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = true;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = false;
                    return;
                case 24:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = true;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = false;
                    return;
                case 25:
                    ComputerDie1.CanRoll = true;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = false;
                    return;
                case 26:
                    ComputerDie1.CanRoll = false;
                    ComputerDie2.CanRoll = false;
                    ComputerDie3.CanRoll = false;
                    ComputerDie4.CanRoll = false;
                    ComputerDie5.CanRoll = false;
                    return;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
