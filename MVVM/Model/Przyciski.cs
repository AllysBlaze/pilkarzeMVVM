using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
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
            if(dl==0)
                lista.Add(nowy);

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
        public  void DoPliku()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;

            using (XmlWriter w = XmlWriter.Create("pilkarze.xml", set))
            {
                w.WriteStartElement("lista");
                foreach (var k in lista)
                {
                    w.WriteStartElement("Pilkarz");
                    w.WriteElementString("Imie", k.Imie);
                    w.WriteElementString("Nazwisko", k.Nazwisko);
                    w.WriteElementString("Wiek", k.Wiek.ToString());
                    w.WriteElementString("Waga", k.Waga.ToString());
                    w.WriteEndElement();
                }
                w.WriteEndElement();
            }
            
            
        }
        public void ZPliku()
        {
            string imie, nazwisko;
            int wiek, waga;
            XmlReaderSettings set = new XmlReaderSettings();
            set.IgnoreWhitespace = true;
            if (File.Exists("pilkarze.xml"))
            {
                using (XmlReader r = XmlReader.Create("pilkarze.xml", set))
                {
                    r.ReadStartElement("lista");
                    while (r.Name == "Pilkarz")
                    {
                        XElement p = (XElement)XNode.ReadFrom(r);
                        imie = (string)p.Element("Imie");
                        nazwisko = (string)p.Element("Nazwisko");
                        wiek = (int)p.Element("Wiek");
                        waga = (int)p.Element("Waga");
                        lista.Add(new KlasaModel(imie, nazwisko, wiek, waga));

                    }
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
