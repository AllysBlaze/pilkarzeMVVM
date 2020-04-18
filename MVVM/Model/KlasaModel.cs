using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    class KlasaModel
    {
        public string Zawartosc { get; set; }

        public KlasaModel(string zawartosc)
        {
            Zawartosc = zawartosc;
        }

        public override string ToString()
        {
            return $"{Zawartosc}";
        }
        public string getZawartosc() { return this.Zawartosc; }
    }
}
