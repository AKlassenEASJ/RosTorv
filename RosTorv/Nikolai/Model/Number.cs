﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

namespace RosTorv.Nikolai.Model
{
    public class Number : INotifyPropertyChanged
    {
        private int numberValue;
        private double _ShadowOpacity = 5;


        public double ShadowOpacity
        {
            get { return _ShadowOpacity; }
            set
            {
                _ShadowOpacity = value;
                OnPropertyChanged();
            }
        }

        public int NumberValue
        {
            get { return numberValue; }
            set
            {
                numberValue = value; 
                OnPropertyChanged();
            }
            
        }

        private bool taken;

        public bool Taken
        {
            get { return taken; }
            set
            {
                taken = value;
                OnPropertyChanged();
            }
        }

        public Number(int number, bool taken)
        {
            numberValue = number;
            this.Taken = taken;
        }

        public override bool Equals(object obj)
        {
            return numberValue == ((Number)obj).NumberValue;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
