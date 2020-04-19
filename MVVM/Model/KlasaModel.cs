using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    class KlasaModel
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public int Waga { get; set; }

        public KlasaModel(string imie,string nazwisko,int wiek, int waga)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, {Wiek} lat, {Waga} kg";
        }
        public string getImie() { return this.Imie; }
        public string getNazwisko() { return this.Nazwisko; }
        public int getWiek() { return this.Wiek; }
        public int getWaga() { return this.Waga; }

        public void Zaladuj(string imie, string nazwisko, int wiek, int waga)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Wiek = wiek;
            this.Waga = waga;

        }
        
        public string ToFileFormat()
        {
            return $"{Imie}|{Nazwisko}|{Wiek}|{Waga}";
        }

        public bool czyIstnieje(KlasaModel footballer)
        {
            if (footballer.Imie != Imie)
                return false;
            if (footballer.Nazwisko != Nazwisko)
                return false;
            if (footballer.Wiek != Wiek)
                return false;
            if (footballer.Waga != Waga)
                return false;
            return true;
        }
    }
}
