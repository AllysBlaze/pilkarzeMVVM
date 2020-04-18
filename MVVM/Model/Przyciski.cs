using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    class Przyciski
    {
        public List<KlasaModel> lista = new List<KlasaModel>();
        public string getZawartosc(int indeks) { return lista[indeks].getZawartosc(); }
        public void Dodaj(string zawartosc)
        {
            lista.Add(new KlasaModel(zawartosc));
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
