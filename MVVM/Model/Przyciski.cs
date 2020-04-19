using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace MVVM.Model
{
    class Przyciski
    {

        public  List<KlasaModel> lista = new List<KlasaModel>();
        public string getImie(int indeks)
        {
            return lista[indeks].getImie();
        }
        public string getNazwisko(int indeks)
        {
            return lista[indeks].getNazwisko();
        }
        public int getWiek(int indeks)
        {
            return lista[indeks].getWiek();
        }
        public int getWaga(int indeks)
        {
            return lista[indeks].getWaga();
        }
        #region przyciski
        public void Dodaj(string imie, string nazwisko, int wiek, int waga)
        {

            imie=imie.Trim();
            nazwisko=nazwisko.Trim();
            var nowy = new KlasaModel(imie, nazwisko, wiek, waga);
            int dl = lista.Count;
            for (int i = 0; i < dl; i++)
            {
                var footballer = lista[i] as KlasaModel;
                if (footballer.czyIstnieje(nowy))
                {
                    break;
                }
                else
                {
                    lista.Add(nowy);
                    break;
                }
            }
                
        }
        public void Edytuj(int indeks,string imie, string nazwisko, int wiek, int waga)
        {

            if (IsEmpty(imie) == false && IsEmpty(nazwisko) == false)
            {
                imie = imie.Trim();
                nazwisko = nazwisko.Trim();

                lista[indeks].Zaladuj(imie, nazwisko, wiek, waga);
            }
            
        }
        public void Usun(int indeks)
        {
            lista.RemoveAt(indeks);
        }
        #endregion

        #region strumienie
        public  void DoPliku(string plik)
        {
            int n = lista.Count;
            KlasaModel[] km = null;
            if (n>0)
            {
                km = new KlasaModel[n];
                int i = 0;
                foreach (var k in lista)
                    km[i++] = k as KlasaModel;
                using (StreamWriter stream = new StreamWriter(plik))
                {
                    foreach (var k in km)
                        stream.WriteLine(k.ToFileFormat());
                    stream.Close();
                }
            }
            
        }
        public void ZPliku(string nazwa)
        {
            if(File.Exists(nazwa))
            {
                var temp = File.ReadAllLines(nazwa);
                var dlugosc = temp.Length;
                for (int i=0;i<dlugosc;i++)
                {
                    var str = CreateFromString(temp[i]);
                    lista.Add(str);
                }
            }
        }

        public KlasaModel CreateFromString(string str)
        {
            string imie, nazwisko;
            int wiek, waga;
            var pola = str.Split('|');
            if (pola.Length == 4)
            {
                nazwisko = pola[1];
                imie = pola[0];
                wiek = int.Parse(pola[2]);
                waga = int.Parse(pola[3]);
                return new KlasaModel(imie, nazwisko, wiek, waga);
            }
            throw new Exception("Błędny format danych z pliku");

        }
        #endregion

        public bool IsEmpty(string str)
        {
            if (str == null || str.Trim() == "")
                return true;
            else
                return false;
        }
        public string[] Show()
        {
            string[] pilkarz = new string[lista.Count];
            for (int i = 0; i < pilkarz.Length; i++)
            {
                pilkarz[i] = lista[i].ToString();
            }
            return pilkarz;
        }
    }
    
}
