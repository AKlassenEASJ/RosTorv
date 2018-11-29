using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

namespace RosTorv.Line.Model
{
    public class PointFelt : INotifyPropertyChanged
    {
        private int _midlertidigPoint;
        private int _point;

        public int MidlertidigPoint
        {
            get { return _midlertidigPoint;}
            set
            {
                _midlertidigPoint = value;
                OnPropertyChanged();
            }
        }

        public int Point
        {
            get { return _point;}
            set
            {
                _point = value;
                OnPropertyChanged();
            }
        }

        public PointFelt()
        {
            
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
