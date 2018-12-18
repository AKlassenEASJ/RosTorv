using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.Nikolai.View;

namespace RosTorv.Nikolai.Model
{
    class Player : IComparable<Player>
    {
        #region Instance Fields

        private string _name;
        private int _points;


        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }


        #endregion

        #region Constructor

        public Player(string name, int points)
        {
            _name = name;
            _points = points;
        }


        #endregion

        #region Methods

        
        #endregion


        public int CompareTo(Player other)
        {
            //if (ReferenceEquals(this, other)) return 0;
            //if (ReferenceEquals(null, other)) return 1;
            //return _points.CompareTo(other._points);
            if (Points == other.Points)
                return 0;
            if (Points < other.Points)
                return -1;
            else
            {
                return 1;
            }
        }
    }
}
