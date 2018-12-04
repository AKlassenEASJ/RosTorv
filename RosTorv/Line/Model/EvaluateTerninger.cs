using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RosTorv.Line.Model
{
    public class EvaluateTerninger
    {
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
            for (int i = 6; i > 0; i--)
            {
                //hvis der et par
                if (_terninsværdi[i] > 1)
                {
                    if (Spil.Spiller1.PointFelter[7].CanChange)
                    {
                        Spil.Spiller1.PointFelter[7].Point = i * 2;
                    }
                    //hvis der er 3 ens
                    if (_terninsværdi[i]>2)
                    {
                        if (Spil.Spiller1.PointFelter[9].CanChange)
                        {
                            Spil.Spiller1.PointFelter[9].Point = i * 3;
                        }
                        //tjek for 2 par og FuldtHus
                        if (Spil.Spiller1.PointFelter[8].CanChange || Spil.Spiller1.PointFelter[14].CanChange)
                        {
                            for (int j = i - 1; j < 0; j--)
                            {
                                if (_terninsværdi[j] > 1)
                                {
                                    if (Spil.Spiller1.PointFelter[8].CanChange)
                                    {
                                        Spil.Spiller1.PointFelter[8].Point = (i*2) + (j*2);
                                    }

                                    if (_terninsværdi[j] > 2)
                                    {
                                        if (Spil.Spiller1.PointFelter[13].CanChange)
                                        {
                                            Spil.Spiller1.PointFelter[13].Point = (i * 2) + (j * 3);
                                        }
                                    }
                                }
                            }
                        }
                        //4 ens
                        if (_terninsværdi[i] > 3)
                        {
                            if (Spil.Spiller1.PointFelter[10].CanChange)
                            {
                                Spil.Spiller1.PointFelter[10].Point = i * 4;
                            }
                            //fuldthus
                            for (int j = i - 1; j < 0; j--)
                            {
                                if (_terninsværdi[j] > 2)
                                {
                                    if (Spil.Spiller1.PointFelter[13].CanChange)
                                    {
                                        Spil.Spiller1.PointFelter[13].Point = (j * 2) + (i * 3);
                                    }
                                }
                            }
                            //yatzy
                            if (_terninsværdi[i] > 4)
                            {
                                if (Spil.Spiller1.PointFelter[15].CanChange)
                                {
                                    Spil.Spiller1.PointFelter[15].Point = 50;
                                }
                            }
                        }
                    }
                }
                
            }
        }



    }
}
