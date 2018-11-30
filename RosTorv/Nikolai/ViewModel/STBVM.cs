﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.Nikolai.Model;

namespace RosTorv.Nikolai.ViewModel
{
    public class STBVM : INotifyPropertyChanged
    {
        public Spil Game { get; set; }


        public STBVM()
        {
            Game = new Spil();
            RollCommand = new RelayCommand(Game.RollAll);
        }

        private Number selectedNumber;

        public Number SelectedNumber
        {
            get { return selectedNumber; }
            set
            {
                selectedNumber = value;
                OnPropertyChanged();
            }
        }



        public ICommand RollCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
