﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RosTorv.Line.Model
{
    public class EvaluateTerninger
    {
        private int value = 0;
        public Spil Spil { get; set; }
        private Dictionary<int, int> _terninsværdi = new Dictionary<int, int>();
            
        public EvaluateTerninger(Spil spil)
        {
            this.Spil = spil;
            _terninsværdi.Add(1, 0);
            _terninsværdi.Add(2, 0);
            _terninsværdi.Add(3, 0);
            _terninsværdi.Add(4, 0);
            _terninsværdi.Add(5, 0);
            _terninsværdi.Add(6, 0);
        }

        public void RunAllEvaluate()
        {
            NulStilVærdi();
            GetTerningsVærdi();
            First6();
            TjekEns();
        }

        public void NulStilVærdi()
        {
            for (int i = 1; i < 7; i++)
            {
                _terninsværdi[i] = 0;
            }
        }

        public void GetTerningsVærdi()
        {
            for (int i = 1; i < 7; i++)
            {
                foreach (Terning terning in Spil.Bæger.Terninger)
                {
                    if (terning.Eyes == i)
                    {
                        _terninsværdi[i]++;
                    }
                } 
            }
        }

        public void First6()
        {
            int j = 0;
            for (int i = 1; i <=6; i++)
            {
                if (Spil.Spiller1.PointFelter[j].CanChange)
                {
                    Spil.Spiller1.PointFelter[j].Point = _terninsværdi[i] * i;
                }

                j++;
            }
        }

        public void TjekEns()
        {
            for (int i = 1; i <= 6; i++)
            {
                if (_terninsværdi[i] > 1)
                {
                    Spil.Spiller1.PointFelter[7].Point = 0;
                    Spil.Spiller1.PointFelter[7].Point = i * 2;

                    if (_terninsværdi[i]>2)
                    {
                        Spil.Spiller1.PointFelter[8].Point = 0;
                        Spil.Spiller1.PointFelter[8].Point = i * 3;

                        if (_terninsværdi[i] > 3)
                        {
                            Spil.Spiller1.PointFelter[9].Point = 0;
                            Spil.Spiller1.PointFelter[9].Point = i * 4;

                            if (_terninsværdi[i] > 5)
                            {
                                Spil.Spiller1.PointFelter[16].Point = 50;
                            }
                        }
                    }
                }
            }
        }



    }
}
