using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.Nikolai.Common;
using RosTorv.Nikolai.View;

namespace RosTorv.Nikolai.Model
{
    public class Spil : INotifyPropertyChanged
    {
        private Dice _dice1;
        private Dice _dice2;
        private int _diceCounter;


        public Dice Dice1
        {
            get { return _dice1; }
            set
            {
                value = _dice1;
            }
        }

        public Dice Dice2
        {
            get { return _dice2; }
            set
            {
                value = _dice2;
            }
        }
        public int DiceCounter
        {
            get { return _diceCounter; }
            set
            {
                _diceCounter = value;
                OnPropertyChanged();
            }
        }

        




        private Numbers numberCatalog;

        public Numbers NumberCatalog
        {
            get { return numberCatalog; }
            set
            {
                numberCatalog = value;
                OnPropertyChanged();
            }
        }


        public Spil()
        {
            _dice1 = new Dice();
            _dice2 = new Dice();         
            RemovedNumbers = new ObservableCollection<Number>();
            NumberCatalog = new Numbers();
           //ResetNumbers();
            _diceCounter = 21;
            RollAll();
            

        }


        public void CheckPoints()
        {
            int ThrowesUsed = 21 - DiceCounter;
            int PointsRemoved = 50;
            Points.Instance.point = 1050;
            Points.Instance.point = Points.Instance.point - ThrowesUsed * PointsRemoved;

        }


        public void CheckNumbers()
        {
            int Resultat = 0;
            foreach (Number n in SelectedNumbers)
            {
                Resultat = Resultat + n.NumberValue;
            }

            if (Resultat == (Dice1.DiceValue + Dice2.DiceValue))
            {
                foreach (Number i in SelectedNumbers)
                {
                    RemovedNumbers.Add(i);
                    NumberCatalog.NumberList.Remove(i);
                    //NumberList.Remove(i);
                }
                SelectedNumbers.Clear();
                
            }

            if (RemovedNumbers.Contains(new Number(1, true)) && RemovedNumbers.Contains(new Number(2, true)) &&
                RemovedNumbers.Contains(new Number(3, true)) && RemovedNumbers.Contains(new Number(4, true)) &&
                RemovedNumbers.Contains(new Number(5, true)) && RemovedNumbers.Contains(new Number(6, true)) &&
                RemovedNumbers.Contains(new Number(7, true)) && RemovedNumbers.Contains(new Number(8, true)) &&
                RemovedNumbers.Contains(new Number(9, true)))
            {
                CheckPoints();
                NavigationService.Navigate(typeof(NamePage));
            }
        }

        public void RulePage()
        {
            MessageDialogHelper.Show("At the start of the game all levers or tiles are open (cleared, up), showing the numerals 1 to 9. During the game, each player plays in turn. A player begins his or her turn by throwing or rolling the die or dice into the box. If the sum of the remaining tile(s) is 6 or lower, the player may roll only one die.", "Rules");
        }

        public void Confirm()
        {
            NavigationService.Navigate(typeof(HighScorePage));    
        }




        public void Reset()
        {
            NumberCatalog.NumberList.Clear();
            //NumberList.Clear();
            RemovedNumbers.Clear();
            SelectedNumbers.Clear();
            RemovedNumbers = new ObservableCollection<Number>();
            NumberCatalog = new Numbers();
            //ResetNumbers();
            SelectedNumbers = new ObservableCollection<Number>();
            _diceCounter = 21;
            RollAll();
        }

        
        public void RollAll()
        {

            DiceCounter = _diceCounter -1;

            if (DiceCounter == -1)
            {
                CheckPoints();
                NavigationService.Navigate(typeof(NamePage));
            }



            if (RemovedNumbers.Contains(new Number(7, true)) && RemovedNumbers.Contains(new Number(8, true)) && RemovedNumbers.Contains(new Number(9, true)))
            {
                Dice2.ImageSource = null;
                Dice2.DiceValue = 0;
            }
            else
            {
                Dice2.Roll();
            }

            Dice1.Roll();
            SelectedNumbers = new ObservableCollection<Number>();          
        }



        private ObservableCollection<Number> removedNumbers;

        public ObservableCollection<Number> RemovedNumbers
        {
            get { return removedNumbers; }
            set
            {
                removedNumbers = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Number> SelectedNumbers { get; set; }

        






        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
