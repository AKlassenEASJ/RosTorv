using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Services.Store;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using RosTorv.Annotations;
using RosTorv.Thomas.View;

namespace RosTorv.Thomas.Model
{
    class Game : INotifyPropertyChanged
    {
        private AI _friendComputer;
        private Player _player;
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
        private int _playerHandRank;
        private int _computerHandRank;
        private bool _playerWon;
        private int _bet;
        private string _gameMessage;

        public string GameMessage
        {
            get { return _gameMessage; }
            set
            {
                _gameMessage=value;
                OnPropertyChanged();
            }
        }

        public int Bet
        {
            get { return _bet; }
            set
            {
                _bet = value; 
                OnPropertyChanged();
            }
        }

        public bool PlayerWon
        {
            get { return _playerWon; }
            set
            {
                _playerWon = value;
                OnPropertyChanged();
            }
        }
        public Player Player
        {
            get { return _player; }
        }
        private AI FriendComputer
        {
            get { return _friendComputer; }
        }

        public int PlayerHandRank
        {
            get { return _playerHandRank; }
            set
            {
                _playerHandRank=value;
                OnPropertyChanged();
            }
        }
        public int ComputerHandRank
        {
            get { return _computerHandRank; }
            set
            {
                _computerHandRank = value;
                OnPropertyChanged();
            }
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
            _player=new Player(10000);

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
            _gameMessage = "";


        }

        public void EndGame()
        {
            PlayerHandRank=DetermineRolls(PlayerDie1.FaceValue, PlayerDie2.FaceValue, PlayerDie3.FaceValue, PlayerDie4.FaceValue,
                PlayerDie5.FaceValue);
            ComputerHandRank=DetermineRolls(ComputerDie1.FaceValue, ComputerDie2.FaceValue, ComputerDie3.FaceValue,
                ComputerDie4.FaceValue, ComputerDie5.FaceValue);
            if (PlayerHandRank < ComputerHandRank)
            {
                PlayerWon = true;
            }
            else if (PlayerHandRank == ComputerHandRank)
            {
                if ((PlayerDie1.FaceValue + PlayerDie2.FaceValue + PlayerDie3.FaceValue + PlayerDie4.FaceValue +
                     PlayerDie5.FaceValue) > (ComputerDie1.FaceValue + ComputerDie2.FaceValue + ComputerDie3.FaceValue +
                                              ComputerDie4.FaceValue + ComputerDie5.FaceValue))
                {
                    PlayerWon = true;
                }
                else
                {
                    PlayerWon = false;
                }
            }
            else
            {
                PlayerWon = false;
            }

            CanClickRoll = false;
            CanStartGame = true;
            if (PlayerWon)
            {
                Player.Score = Player.Score + Bet * 2;
                GameMessage = $" You Rolled {StateHandRank(PlayerHandRank)}. The Computer Rolled {StateHandRank(ComputerHandRank)}. You Won! You gain 2x your bet of {Bet} points!";
            }
            else
            {
                GameMessage = $" You Rolled {StateHandRank(PlayerHandRank)}. The Computer Rolled {StateHandRank(ComputerHandRank)}. You Lost! You r bet of {Bet} points is forfeit!";
            }
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

        int DetermineRolls(int Die1, int Die2, int Die3, int Die4, int Die5)
        {   //Assume Chancen
            int HandRank=8;
            //Check for Et Par
            if ((Die1 == Die2) || (Die1 == Die3) || (Die1 == Die4) || (Die1 == Die5) || (Die2 == Die3) || (Die2 == Die4) 
                || (Die2 == Die5) || (Die3 == Die4) || (Die3 == Die5) || (Die4 == Die5))
            {
                HandRank = 7;
            }
            //Check for To Par
            if (Die1 == Die2 && Die3 == Die4 ||
                Die1 == Die2 && Die3 == Die5 ||
                Die1 == Die2 && Die4 == Die5 ||
                Die1 == Die3 && Die2 == Die4 ||
                Die1 == Die3 && Die2 == Die5 ||
                Die1 == Die3 && Die4 == Die5 ||
                Die1 == Die4 && Die2 == Die3 ||
                Die1 == Die4 && Die2 == Die5 ||
                Die1 == Die4 && Die3 == Die5 ||
                Die1 == Die5 && Die2 == Die3 ||
                Die1 == Die5 && Die2 == Die4 ||
                Die1 == Die5 && Die3 == Die4 ||
                Die2 == Die5 && Die3 == Die4 ||
                Die2 == Die3 && Die4 == Die5 ||
                Die2 == Die4 && Die3 == Die5)
            {
                HandRank = 6;
            }
            //Check For Tre Ens
            if ((Die1 == Die2 && Die2 == Die3) ||
                (Die1 == Die2 && Die2 == Die4) ||
                (Die1 == Die2 && Die2 == Die5) ||
                (Die1 == Die3 && Die3 == Die4) ||
                (Die2 == Die3 && Die3 == Die4) ||
                (Die2 == Die3 && Die3 == Die5) ||
                (Die1 == Die4 && Die4 == Die5) ||
                (Die2 == Die4 && Die4 == Die5) ||
                (Die3 == Die4 && Die4 == Die5) ||
                (Die1 == Die3 && Die3 == Die5))
            {
                HandRank = 5;
            }
            //Check for Fuldt Hus
            if ((Die1 == Die2 && Die2 == Die3 && Die4==Die5)||
                (Die1 == Die2 && Die2 == Die4 && Die3 == Die5) ||
                (Die1 == Die2 && Die2 == Die5 && Die3 == Die4) ||
                (Die1 == Die3 && Die3 == Die4 && Die2 == Die5) ||
                (Die2 == Die3 && Die3 == Die4 && Die1 == Die5) ||
                (Die2 == Die3 && Die3 == Die5 && Die1 == Die4) ||
                (Die1 == Die4 && Die4 == Die5 && Die2 == Die3) ||
                (Die2 == Die4 && Die4 == Die5 && Die1 == Die3) ||
                (Die3 == Die4 && Die4 == Die5 && Die1 == Die2) ||
                (Die1 == Die3 && Die3 == Die5 && Die2 == Die4))
            {
                HandRank = 4;
            }
            //Check for Fire Ens
            if (Die1 == Die2 && Die2 == Die3 && Die3 == Die4 ||
                Die1 == Die3 && Die3 == Die4 && Die4 == Die5 ||
                Die1 == Die2 && Die2 == Die4 && Die4 == Die5 ||
                Die1 == Die2 && Die2 == Die3 && Die3 == Die5 ||
                Die2 == Die3 && Die3 == Die4 && Die4 == Die5)
            {
                HandRank = 3;
            }
            //Check for Lille Straight
            List<int> SmallStraightNumbers=new List<int>();
            SmallStraightNumbers.Add(Die1);
            SmallStraightNumbers.Add(Die2);
            SmallStraightNumbers.Add(Die3);
            SmallStraightNumbers.Add(Die4);
            SmallStraightNumbers.Add(Die5);

            int OrderStraightNumber1 = FriendComputer.FindSmallestNumber(SmallStraightNumbers);
            SmallStraightNumbers.Remove(FriendComputer.FindSmallestNumber(SmallStraightNumbers));
            int OrderStraightNumber2 = FriendComputer.FindSmallestNumber(SmallStraightNumbers);
            SmallStraightNumbers.Remove(FriendComputer.FindSmallestNumber(SmallStraightNumbers));
            int OrderStraightNumber3 = FriendComputer.FindSmallestNumber(SmallStraightNumbers);
            SmallStraightNumbers.Remove(FriendComputer.FindSmallestNumber(SmallStraightNumbers));
            int OrderStraightNumber4 = FriendComputer.FindSmallestNumber(SmallStraightNumbers);
            SmallStraightNumbers.Remove(FriendComputer.FindSmallestNumber(SmallStraightNumbers));
            int OrderStraightNumber5 = FriendComputer.FindSmallestNumber(SmallStraightNumbers);
            if (OrderStraightNumber1 == 1 && OrderStraightNumber2 == 2 && OrderStraightNumber3 == 3 && OrderStraightNumber4 == 4 && OrderStraightNumber5 == 5)
            {
                HandRank = 2;
            }


            //Check for Stor Straight

            List<int> BigStraightNumbers = new List<int>();
            BigStraightNumbers.Add(Die1);
            BigStraightNumbers.Add(Die2);
            BigStraightNumbers.Add(Die3);
            BigStraightNumbers.Add(Die4);
            BigStraightNumbers.Add(Die5);
            OrderStraightNumber1=FriendComputer.FindSmallestNumber(BigStraightNumbers);
            BigStraightNumbers.Remove(FriendComputer.FindSmallestNumber(BigStraightNumbers));
            OrderStraightNumber2=FriendComputer.FindSmallestNumber(BigStraightNumbers);
            BigStraightNumbers.Remove(FriendComputer.FindSmallestNumber(BigStraightNumbers));
            OrderStraightNumber3 = FriendComputer.FindSmallestNumber(BigStraightNumbers);
            BigStraightNumbers.Remove(FriendComputer.FindSmallestNumber(BigStraightNumbers));
            OrderStraightNumber4 = FriendComputer.FindSmallestNumber(BigStraightNumbers);
            BigStraightNumbers.Remove(FriendComputer.FindSmallestNumber(BigStraightNumbers));
            OrderStraightNumber5 = FriendComputer.FindSmallestNumber(BigStraightNumbers);
            BigStraightNumbers.Remove(FriendComputer.FindSmallestNumber(BigStraightNumbers));
            if (OrderStraightNumber1 ==2 && OrderStraightNumber2 == 3 && OrderStraightNumber3 == 4 && OrderStraightNumber4 == 5 && OrderStraightNumber5 == 6)
            {
                HandRank = 1;
            }
            //Check for Yatzi.
            if (Die1 == Die2 && Die2 == Die3 && Die3 == Die4 && Die4 == Die5)
            {
                HandRank = 0;
            }
            return HandRank;
        }

        private string StateHandRank(int Handrank)
        {
            switch (Handrank)
            {
                case 0:
                    return "Yatzi";
                case 1:
                    return "Big Straight";
                case 2:
                    return "Small Straight";
                case 3:
                    return "Four of a Kind";
                case 4:
                    return "Full House";
                case 5:
                    return "Three of a Kind";
                case 6:
                    return "Two Pairs";
                case 7:
                    return "One Pair";
                case 8:
                    return "Chance";
            }

            return "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
