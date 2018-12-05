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
        private Dictionary<int, int> _terningsværdi = new Dictionary<int, int>();

        public EvaluateTerninger(Spil spil)
        {
            this.Spil = spil;
            _terningsværdi.Add(1, 0);
            _terningsværdi.Add(2, 0);
            _terningsværdi.Add(3, 0);
            _terningsværdi.Add(4, 0);
            _terningsværdi.Add(5, 0);
            _terningsværdi.Add(6, 0);
        }

        public void RunAllEvaluate()
        {
            NulStilVærdi();
            GetTerningsVærdi();
            First6();
            TjekEns();
            TjekHøjOgLav();
            if (Spil.Spiller1.PointFelter[14].CanChange)
            {
                GetChange();
            }
        }

        private void GetChange()
        {
            Spil.Spiller1.PointFelter[14].Point = 0;
            for (int i = 1; i < 7; i++)
            {
                Spil.Spiller1.PointFelter[14].Point = Spil.Spiller1.PointFelter[14].Point + _terningsværdi[i];
            }
        }

        private void NulStilVærdi()
        {
            for (int i = 1; i < 7; i++)
            {
                _terningsværdi[i] = 0;
            }
        }

        private void GetTerningsVærdi()
        {
            for (int i = 1; i < 7; i++)
            {
                foreach (Terning terning in Spil.Bæger.Terninger)
                {
                    if (terning.Eyes == i)
                    {
                        _terningsværdi[i]++;
                    }
                }
            }
        }

        private void First6()
        {
            int j = 0;
            for (int i = 1; i <= 6; i++)
            {
                if (Spil.Spiller1.PointFelter[j].CanChange)
                {
                    Spil.Spiller1.PointFelter[j].Point = _terningsværdi[i] * i;
                }

                j++;
            }
        }

        private void TjekHøjOgLav()
        {
            if (!_terningsværdi.ContainsValue(2))
            {
                if (_terningsværdi[1] == 1)
                {
                    if (_terningsværdi[6] == 0)
                    {
                        Spil.Spiller1.PointFelter[12].Point = 15;
                    }
                }
                else
                {
                    Spil.Spiller1.PointFelter[11].Point = 20;
                }
            }
        }

        private void TjekEns()
        {
            for (int i = 1; i < 7; i++)
            {
                //hvis der et par
                if (_terningsværdi[i] > 1)
                {
                    if (Spil.Spiller1.PointFelter[7].CanChange)
                    {
                        Spil.Spiller1.PointFelter[7].Point = i * 2;
                    }

                    //Tjek om 2 par Og FuldtHus
                    if (Spil.Spiller1.PointFelter[8].CanChange || Spil.Spiller1.PointFelter[13].CanChange)
                    {
                        for (int j = 1; j < 7; j++)
                        {
                            if (j != i)
                            {
                                if (Spil.Spiller1.PointFelter[8].CanChange)
                                {
                                    if (_terningsværdi[j] > 1)
                                    {
                                        Spil.Spiller1.PointFelter[8].Point = (i * 2) + (j * 2);

                                    }
                                }

                                if (Spil.Spiller1.PointFelter[13].CanChange)
                                {
                                        if (_terningsværdi[j] == 3)
                                        {
                                            Spil.Spiller1.PointFelter[13].Point = (i * 2) + (j * 3);
                                        }
                                }
                                
                            }
                        }
                    }
                    
                    //hvis der er 3 ens
                    if (_terningsværdi[i] > 2)
                    {
                        if (Spil.Spiller1.PointFelter[9].CanChange)
                        {
                            Spil.Spiller1.PointFelter[9].Point = i * 3;
                        }
                        //fuldthus
                        if (Spil.Spiller1.PointFelter[13].CanChange)
                        {
                            for (int j = 1; j < 7; j++)
                            {
                                if (j != i)
                                {
                                    if (_terningsværdi[j] == 2)
                                    {
                                        Spil.Spiller1.PointFelter[13].Point = (j * 2) + (i * 3);
                                    }
                                }
                            }
                        }

                        //4 ens
                        if (_terningsværdi[i] > 3)
                        {
                            if (Spil.Spiller1.PointFelter[10].CanChange)
                            {
                                Spil.Spiller1.PointFelter[10].Point = i * 4;
                            }


                         //yatzy
                            if (_terningsværdi[i] > 4)
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

