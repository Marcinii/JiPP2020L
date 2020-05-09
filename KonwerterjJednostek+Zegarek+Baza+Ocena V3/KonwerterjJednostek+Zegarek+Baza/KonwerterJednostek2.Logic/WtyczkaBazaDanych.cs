using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterJednostek2;

using KonwerterJednostek2.Logic;

namespace KonwerterJednostek2.Logic
{
    public class WtyczkaBazaDanych
    {
        static void Main(string[] args)
        {

        }




        public void WstawDaneEF(string RodzajKonwertera, string Jednostka_IN, string Jednostka_OUT, double Liczba_IN, double Liczba_OUT)
        {
            using (BazaDanychKonwerterEntities12 context = new BazaDanychKonwerterEntities12())
            {

                TabelaKonwerter newTabelaKonwerter = new TabelaKonwerter()
                {
                    RodzajKonwertera = RodzajKonwertera,
                    Jednostka_IN = Jednostka_IN,
                    Jednostka_OUT = Jednostka_OUT,
                    Data = DateTime.Today,
                    Liczba_IN = Liczba_IN.ToString(),
                    Liczba_OUT = Liczba_OUT.ToString(),
                    Ocena=null
                    
                };

                context.TabelaKonwerter.Add(newTabelaKonwerter);

                context.SaveChanges();
            }
        }

        public void WstawDaneOcena(int Ocena)
        {
            using (BazaDanychKonwerterEntities12 context = new BazaDanychKonwerterEntities12())
            {

                TabelaKonwerter newTabelaKonwerter = new TabelaKonwerter()
                {
                    Ocena = Ocena
                };

                context.TabelaKonwerter.Add(newTabelaKonwerter);

                context.SaveChanges();
            }
        }
    }
}

