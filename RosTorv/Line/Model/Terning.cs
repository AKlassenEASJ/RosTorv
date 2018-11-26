using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Line.Model
{
    class Terning
    {
        private int _eyes;
        private string _image;
        private bool _canRoll = true;
        private Random _random;

        public int Eyes
        {
            get { return _eyes;}
            set { value = _eyes; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public bool CanRoll
        {
            get { return _canRoll; }
            set { _canRoll = value; }
        }

        public Terning()
        {
          _random = new Random(DateTime.Now.Millisecond);  
        }

        public void Roll()
        {
            _eyes = _random.Next(1, 6);
            UpdateImage();
        }

        public void UpdateImage()
        {
            if (_eyes == 1)
            {
                _image = "Line/Assets/die_1.png";
            }
            else if (_eyes == 2)
            {
                _image = "Line/Assets/die_2.png";
            }
            else if (_eyes == 3)
            {
                _image = "Line/Assets/die_3.png";
            }
            else if (_eyes == 4)
            {
                _image = "Line/Assets/die_4.png";
            }
            else if (_eyes == 5)
            {
                _image = "Line/Assets/die_5.png";
            }
            else if (_eyes == 6)
            {
                _image = "Line/Assets/die_6.png";
            }
        }
    }
}
