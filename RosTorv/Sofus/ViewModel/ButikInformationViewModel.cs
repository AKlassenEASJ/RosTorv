﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;
using RosTorv.Sofus.Model;

namespace RosTorv.Sofus.ViewModel
{
    public class ButikInformationViewModel: INotifyPropertyChanged
    {
        private Butik _currentButik;

        public IEnumerable<Butik> Butikker { get; set; }
        public Butik CurrentButik
        {
            get { return _currentButik; }
            set
            {
                _currentButik = value;
                OnPropertyChanged();
            }
        }


        public ButikInformationViewModel()
        {
            Butikker = Persistency.ReadAndDeserializeButikker();
            CurrentButik = Butikker.First();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
