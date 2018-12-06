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
using RosTorv.Nikolai.Common;

namespace RosTorv.Nikolai.Model
{
    public class Spil : INotifyPropertyChanged
    {
        private Dice _dice1;
        private Dice _dice2;
        private int _diceCounter = 20;

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
                value = _diceCounter;
                OnPropertyChanged();
            }
        }



        public Numbers NumberCatalog { get; set; }

        public Spil()
        {
            _dice1 = new Dice();
            _dice2 = new Dice();         
            RemovedNumbers = new ObservableCollection<Number>();
            NumberCatalog = new Numbers();
            RollAll();
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
                }
            }
        }

        public void RollAll()
        {
            
            if (DiceCounter == 0)
            {
                MessageDialogHelper.Show("Congratz mah Bruddah!", "Uganda");
            }
            DiceCounter--;

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

        public ObservableCollection<Number> RemovedNumbers { get; set; }

        public ObservableCollection<Number> SelectedNumbers { get; set; }

        






        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
