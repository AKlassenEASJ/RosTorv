using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Annotations;

namespace RosTorv.Line.Model
{
    public class BægerSingelton :INotifyPropertyChanged
    {
        /// <summary>
        /// Bægeret er til at initialisere terningerne, holde funktioner der vedrører alle terningerne.
        /// funktioner: RollAll(), ChangeCanRoll(), NulstillTerninger()
        /// </summary>
        public ObservableCollection<Terning> Terninger { get; set; }

        private static BægerSingelton instansBægerSingelton = new BægerSingelton();

        public static BægerSingelton InstanBægerSingelton
        {
            get { return instansBægerSingelton; }
        }

        private BægerSingelton()
        {
            Terninger = new ObservableCollection<Terning>();
            Terninger.Add(new Terning(5));
            Terninger.Add(new Terning(10));
            Terninger.Add(new Terning(15));
            Terninger.Add(new Terning(20));
            Terninger.Add(new Terning(5));
        }

        public void RollAll()
        {
            foreach (Terning terning in Terninger)
            {
                if (terning.CanRoll)
                {
                    terning.Roll();
                }
            }
        }

        public void ChangeCanRoll(Terning terning)
        {
            int index = Terninger.IndexOf(terning);
            if (Terninger[index].CanRoll)
            {
                Terninger[index].CanRoll = false;
                Terninger[index].ShadowOpacity = 0.70;
            }
            else if (Terninger[index].CanRoll == false)
            {
                Terninger[index].CanRoll = true;
                Terninger[index].ShadowOpacity = 0;
            }
        }

        public void NulstilTerninger()
        {
            foreach (Terning terning in Terninger)
            {
                terning.Eyes = 0;
                terning.UpdateImage();
                terning.CanRoll = true;
                terning.ShadowOpacity = 0;
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
