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
        public SpilSingelton Spil { get;}
        private Dictionary<int, int> _terningsværdi = new Dictionary<int, int>();

        public EvaluateTerninger(SpilSingelton spil)
        {
            this.Spil = spil;
            _terningsværdi.Add(1, 0);
            _terningsværdi.Add(2, 0);
            _terningsværdi.Add(3, 0);
            _terningsværdi.Add(4, 0);
            _terningsværdi.Add(5, 0);
            _terningsværdi.Add(6, 0);
        }

        public void RunAllEvaluate( int index)
        {
            NulStilVærdi();
            GetTerningsVærdi();
            First6(index);
            TjekEns(index);
            TjekHøjOgLav(index);
            if (Spil.SpillereCollection[index].PointFelter[15].CanChange)
            {
                GetChance(index);
            }
        }

        private void GetChance( int index)
        {
            Spil.SpillereCollection[index].PointFelter[15].Point = 0;
            for (int i = 1; i < 7; i++)
            {
                Spil.SpillereCollection[index].PointFelter[15].Point = Spil.SpillereCollection[index].PointFelter[15].Point + (_terningsværdi[i]*i);
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

        private void First6(int index)
        {
            int j = 0;
            for (int i = 1; i <= 6; i++)
            {
                if (Spil.SpillereCollection[index].PointFelter[j].CanChange)
                {
                    Spil.SpillereCollection[index].PointFelter[j].Point = _terningsværdi[i] * i;
                }

                j++;
            }
        }

        private void TjekHøjOgLav(int index)
        {
            if (_terningsværdi[2] == 1)
            {
                if (_terningsværdi[3] == 1)
                {
                    if (_terningsværdi[4] == 1)
                    {
                        if (_terningsværdi[5] == 1)
                        {
                            if (_terningsværdi[1] == 1)
                            {
                                Spil.SpillereCollection[index].PointFelter[13].Point = 15;
                            }
                            else if (_terningsværdi[6] == 1)
                            {
                                Spil.SpillereCollection[index].PointFelter[12].Point = 20;
                            }
                        }
                    }
                }
            }
        }

        public void TjekEns(int index)
        {
            for (int i = 1; i < 7; i++)
            {
                //hvis der et par
                if (_terningsværdi[i] > 1)
                {
                    if (Spil.SpillereCollection[index].PointFelter[8].CanChange)
                    {
                        Spil.SpillereCollection[index].PointFelter[8].Point = i * 2;
                    }

                    //Tjek om 2 par Og FuldtHus
                    if (Spil.SpillereCollection[index].PointFelter[9].CanChange || Spil.SpillereCollection[index].PointFelter[14].CanChange)
                    {
                        for (int j = 1; j < 7; j++)
                        {
                            if (j != i)
                            {
                                if (Spil.SpillereCollection[index].PointFelter[9].CanChange)
                                {
                                    if (_terningsværdi[j] > 1)
                                    {
                                        Spil.SpillereCollection[index].PointFelter[9].Point = (i * 2) + (j * 2);

                                    }
                                }
                                //FuldtHus
                                if (Spil.SpillereCollection[index].PointFelter[14].CanChange)
                                {
                                        if (_terningsværdi[j] == 3)
                                        {
                                            Spil.SpillereCollection[index].PointFelter[14].Point = (i * 2) + (j * 3);
                                        }
                                }
                                
                            }
                        }
                    }
                    
                    //hvis der er 3 ens
                    if (_terningsværdi[i] > 2)
                    {
                        if (Spil.SpillereCollection[index].PointFelter[10].CanChange)
                        {
                            Spil.SpillereCollection[index].PointFelter[10].Point = i * 3;
                        }
                        //fuldthus
                        if (Spil.SpillereCollection[index].PointFelter[14].CanChange)
                        {
                            for (int j = 1; j < 7; j++)
                            {
                                if (j != i)
                                {
                                    if (_terningsværdi[j] == 2)
                                    {
                                        Spil.SpillereCollection[index].PointFelter[14].Point = (j * 2) + (i * 3);
                                    }
                                }
                            }
                        }

                        //4 ens
                        if (_terningsværdi[i] > 3)
                        {
                            if (Spil.SpillereCollection[index].PointFelter[11].CanChange)
                            {
                                Spil.SpillereCollection[index].PointFelter[11].Point = i * 4;
                            }


                         //yatzy
                            if (_terningsværdi[i] > 4)
                            {
                                    if (Spil.SpillereCollection[index].PointFelter[16].CanChange)
                                    {
                                        Spil.SpillereCollection[index].PointFelter[16].Point = 50;
                                    }
                            }
                            
                        }
                    }
                }
            }

        }
    }
}

