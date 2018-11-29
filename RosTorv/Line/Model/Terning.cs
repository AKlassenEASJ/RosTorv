using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Automation;
using RosTorv.Annotations;

namespace RosTorv.Line.Model
{
    public class Terning : INotifyPropertyChanged
    {
        private int _eyes;
        private string _image;
        private bool _canRoll = true;
        private double _ShadowOpacity = 0;

        private Random _random;

        public int Eyes
        {
            get { return _eyes;}
            set
            {
                _eyes = value; 
                OnPropertyChanged();
            }
        }

        public string Image
        {
            get { return _image; }
            set
            {
                _image = value; 
                OnPropertyChanged();
            }
        }

        public bool CanRoll
        {
            get { return _canRoll; }
            set
            {
                _canRoll = value; 
                OnPropertyChanged();
            }
        }

        public double ShadowOpacity
        {
            get { return _ShadowOpacity;}
            set
            {
                _ShadowOpacity = value;
                OnPropertyChanged();
            }
        }

        public Terning( int tal)
        {
          _random = new Random(DateTime.Now.Millisecond * tal);  
        }

        public void Roll()
        {
            Eyes = _random.Next(1, 6);
            UpdateImage();
        }

        private void UpdateImage()
        {
            switch (Eyes)
            {
                case 1:
                    Image = "/Line/Assets/die_1.png";
                    break;
                case 2:
                    Image = "/Line/Assets/die_2.png";
                    break;
                case 3:
                    Image = "/Line/Assets/die_3.png";
                    break;
                case 4:
                    Image = "/Line/Assets/die_4.png";
                    break;
                case 5:
                    Image = "/Line/Assets/die_5.png";
                    break;
                case 6:
                    Image = "/Line/Assets/die_6.png";
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
