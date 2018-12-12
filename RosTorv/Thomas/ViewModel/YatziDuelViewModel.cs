using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using RosTorv.Thomas.Model;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.Thomas.View;

namespace RosTorv.Thomas.ViewModel
{
    class YatziDuelViewModel: INotifyPropertyChanged
    {
        private string _plDice1ImgSource;
        private string _plDice2ImgSource;
        private string _plDice3ImgSource;
        private string _plDice4ImgSource;
        private string _plDice5ImgSource;

        private string _pcDice1ImgSource;
        private string _pcDice2ImgSource;
        private string _pcDice3ImgSource;
        private string _pcDice4ImgSource;
        private string _pcDice5ImgSource;
        private bool _plCanChooseDice;

        public bool PlCanChooseDice
        {
            get { return _plCanChooseDice; }
            set
            {
                _plCanChooseDice = value;
                OnPropertyChanged();
            }
        }

        public string PlDice1ImgSource
        {
            get { return _plDice1ImgSource; }
            set
            {
                _plDice1ImgSource = value;
                OnPropertyChanged();
            }
        }
        public string PlDice2ImgSource
        {
            get { return _plDice2ImgSource; }
            set
            {
                _plDice2ImgSource = value;
                OnPropertyChanged();
            }
        }
        public string PlDice3ImgSource
        {
            get { return _plDice3ImgSource; }
            set
            {
                _plDice3ImgSource = value;
                OnPropertyChanged();
            }
        }
        public string PlDice4ImgSource
        {
            get { return _plDice4ImgSource; }
            set
            {
                _plDice4ImgSource = value;
                OnPropertyChanged();
            }
        }
        public string PlDice5ImgSource
        {
            get { return _plDice5ImgSource; }
            set
            {
                _plDice5ImgSource = value;
                OnPropertyChanged();
            }
        }
        public string PcDice1ImgSource
        {
            get { return _pcDice1ImgSource; }
            set
            {
                _pcDice1ImgSource = value;
                OnPropertyChanged();
            }
        }
        public string PcDice2ImgSource
        {
            get { return _pcDice2ImgSource; }
            set
            {
                _pcDice2ImgSource = value;
                OnPropertyChanged();
            }
        }
        public string PcDice3ImgSource
        {
            get { return _pcDice3ImgSource; }
            set
            {
                _pcDice3ImgSource = value;
                OnPropertyChanged();
            }
        }
        public string PcDice4ImgSource
        {
            get { return _pcDice4ImgSource; }
            set
            {
                _pcDice4ImgSource = value;
                OnPropertyChanged();
            }
        }
        public string PcDice5ImgSource
        {
            get { return _pcDice5ImgSource; }
            set
            {
                _pcDice5ImgSource = value;
                OnPropertyChanged();
            }
        }
        public Game Game { get; set; }

        public string[] Faces = new string[6];

        public ICommand PlayerRollCommand { get; set; }
        public ICommand PcRollCommand { get; set; }
        public ICommand StartGameCommand { get; set; }
        public YatziDuelViewModel()
        {
            Faces[0] = "/Thomas/Assets/die_1.png";
            Faces[1] = "/Thomas/Assets/die_2.png";
            Faces[2] = "/Thomas/Assets/die_3.png";
            Faces[3] = "/Thomas/Assets/die_4.png";
            Faces[4] = "/Thomas/Assets/die_5.png";
            Faces[5] = "/Thomas/Assets/die_6.png";
            Game = new Game();
            PlayerRollCommand = new RelayCommand(RollPlayer);
            PcRollCommand = new RelayCommand(RollPc);
            StartGameCommand = new RelayCommand(StartGame);

            PlDice1ImgSource = Faces[0];
            PlDice2ImgSource = Faces[0];
            PlDice3ImgSource = Faces[0];
            PlDice4ImgSource = Faces[0];
            PlDice5ImgSource = Faces[0];
            PcDice1ImgSource = Faces[0];
            PcDice2ImgSource = Faces[0];
            PcDice3ImgSource = Faces[0];
            PcDice4ImgSource = Faces[0];
            PcDice5ImgSource = Faces[0];
            PlCanChooseDice = false;


        }

        public void RollPlayer()
        {
            
            Game.RollCheckedPlayer();
            UpdatePlImages();
            Game.CanClickRoll = false;
            Game.CanPassTurn = true;
            

        }
        public void RollPc()
        {
            Game.RollCheckedPc();
            UpdatePcImages();
            PlCanChooseDice = true;
            Game.CanPassTurn = false;
            if (Game.RollsLeft!=3)
            {Game.CanClickRoll = true; }
            if (Game.RollsLeft==0)
            { Game.EndGame();}
        }

        public void StartGame()
        {
            Game.PlayerDie1.CanRoll = true;
            Game.PlayerDie2.CanRoll = true;
            Game.PlayerDie3.CanRoll = true;
            Game.PlayerDie4.CanRoll = true;
            Game.PlayerDie5.CanRoll = true;
            Game.ComputerDie1.CanRoll = true;
            Game.ComputerDie2.CanRoll = true;
            Game.ComputerDie3.CanRoll = true;
            Game.ComputerDie4.CanRoll = true;
            Game.ComputerDie5.CanRoll = true;
            PlCanChooseDice = false;
            Game.CanClickRoll = true;
            Game.CanStartGame = false;
            Game.CanPassTurn = false;
            Game.RollsLeft = 3;
        }

        public void UpdatePlImages()
        {
            PlDice1ImgSource = Faces[Game.PlayerDie1.FaceValue - 1];
            PlDice2ImgSource = Faces[Game.PlayerDie2.FaceValue - 1];
            PlDice3ImgSource = Faces[Game.PlayerDie3.FaceValue - 1];
            PlDice4ImgSource = Faces[Game.PlayerDie4.FaceValue - 1];
            PlDice5ImgSource = Faces[Game.PlayerDie5.FaceValue - 1];
        }
        public void UpdatePcImages()
        {
            PcDice1ImgSource = Faces[Game.ComputerDie1.FaceValue - 1];
            PcDice2ImgSource = Faces[Game.ComputerDie2.FaceValue - 1];
            PcDice3ImgSource = Faces[Game.ComputerDie3.FaceValue - 1];
            PcDice4ImgSource = Faces[Game.ComputerDie4.FaceValue - 1];
            PcDice5ImgSource = Faces[Game.ComputerDie5.FaceValue - 1];
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
