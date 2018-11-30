using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

namespace RosTorv.Nikolai.Model
{
    public class Numbers : INotifyPropertyChanged
    {
        public ObservableCollection<Number> NumberList { get; set; }

        public Numbers()
        {
            NumberList = new ObservableCollection<Number>();
            Number n1 = new Number(1,false);
            Number n2 = new Number(2, false);
            Number n3 = new Number(3, false);
            Number n4 = new Number(4, false);
            Number n5 = new Number(5, false);
            Number n6 = new Number(6, false);
            Number n7 = new Number(7, false);
            Number n8 = new Number(8, false);
            Number n9 = new Number(9, false);
            NumberList.Add(n1);
            NumberList.Add(n2);
            NumberList.Add(n3);
            NumberList.Add(n4);
            NumberList.Add(n5);
            NumberList.Add(n6);
            NumberList.Add(n7);
            NumberList.Add(n8);
            NumberList.Add(n9);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
