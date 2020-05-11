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
        private string nazwa = "plik.txt";
        private Przyciski przycisk = new Przyciski();
        public KlasaViewModel()
        {
            przycisk.ZPliku();
            Refresh();
        }
        #region Imie, Nazwisko itp
        private string imie=null;
        public string Imie
        {
            get
            {
                return imie;

            }
            set
            {
                imie = value;
                onPropertyChanged(nameof(Imie));
            }
        }
        private string nazwisko = null;
        public string Nazwisko
        {
            get
            {
                return nazwisko;

            }
            set
            {
                nazwisko = value;
                onPropertyChanged(nameof(Nazwisko));
            }
        }

        private int wiek=15;
        public int Wiek
        {
            get
            {
                return wiek;

            }
            set
            {
                wiek = value;
                onPropertyChanged(nameof(Wiek));
            }
        }
        private int waga=40;
        public int Waga
        {
            get
            {
                return waga;

            }
            set
            {
                waga = value;
                onPropertyChanged(nameof(Waga));
            }
        }
        #endregion
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
        private int indeks = -1;
        
        #region przyciski
        private ICommand dodaj = null;
        public ICommand Dodaj
        {
            get
            {
                if(dodaj==null)
                {
                    dodaj = new RelayCommand(x => { przycisk.Dodaj(Imie, Nazwisko, Wiek, Waga); Refresh(); },
                        x => (Imie != null && Nazwisko != null));
                }
                return dodaj;
            }
        }
        private ICommand edytuj = null;
        public ICommand Edytuj
        {
            get
            {
                if (edytuj == null)
                {
                    edytuj = new RelayCommand(x => { przycisk.Edytuj(Indeks,Imie, Nazwisko, Wiek, Waga); Refresh(); },
                        x => Imie != null && Nazwisko != null);
                }
                return edytuj;
            }
        }
        private ICommand usun = null;
        public ICommand Usun
        {
            get
            {
                if (usun == null)
                {
                    usun = new RelayCommand(x => { przycisk.Usun(Indeks); Refresh(); },
                        x=>(Indeks>-1));
                }
                return usun;
            }
        }
        #endregion
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
                {
                    Imie = przycisk.getImie(indeks);
                    Nazwisko = przycisk.getNazwisko(indeks);
                    Wiek = przycisk.getWiek(indeks);
                    Waga = przycisk.getWaga(indeks);
                }
                onPropertyChanged(nameof(indeks));
            }

        }


        
        public void Refresh()
        {
            Pilkarze = przycisk.Show();
            Imie = null;
            Nazwisko = null;
            Wiek = 15;
            Waga = 40;
            przycisk.DoPliku();
        }

    }
}
