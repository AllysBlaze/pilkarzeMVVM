using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace MVVM.ViewModel
{
    using Model;
    using BaseClass;
    using System.Windows.Input;
    class KlasaViewModel : ViewModelBase
    {
        private string zawartosc=null;
        public string Zawartosc
        {
            get
            {
                return zawartosc;

            }
            set
            {
                zawartosc = value;
                onPropertyChanged(nameof(Zawartosc));
            }
        }
        private string[] pilkarze;
        public string[] Pilkarze
        {
            get { return pilkarze; }
            set
            {
                pilkarze = value;
                onPropertyChanged(nameof(Pilkarze));
            }
        }

        private Przyciski przycisk = new Przyciski();
        private int indeks = -1;
        public int Indeks
        {
            get
            {
                return indeks;
            }
            set
            {
                indeks = value;
                if (indeks != -1)
                    zawartosc = przycisk.getZawartosc(indeks);
                onPropertyChanged(nameof(indeks));
            }
            
        }

        private ICommand dodaj = null;
        public ICommand Dodaj
        {
            get
            {
                if(dodaj==null)
                {
                    dodaj = new RelayCommand(x => { przycisk.Dodaj(Zawartosc); Refresh(); });
                }
                return dodaj;
            }
        }
        public void Refresh()
        {
            Pilkarze = przycisk.Show();
            Zawartosc = null;
        }
        
    }
}
