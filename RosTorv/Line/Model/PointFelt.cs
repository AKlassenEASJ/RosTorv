using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

namespace RosTorv.Line.Model
{
    public class PointFelt : INotifyPropertyChanged
    {
        private bool _canChange = true;
        private int _point;
        private string _color = "SlateGray";
        private string _backGroundColor = "None";
        private string _thickness = "Normal";

        public bool CanChange
        {
            get { return _canChange;}
            set
            {
                _canChange = value;
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

        public string Color
        {
            get { return _color;}
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }

        public string BackgroundColor
        {
            get { return _backGroundColor;}
            set
            {
                _backGroundColor = value;
                OnPropertyChanged();
            }
        }

        public string Thickness
        {
            get { return _thickness; }
            set
            {
                _thickness = value;
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
