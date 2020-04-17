using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace KonwerterJednostek2.Logic
{
    public class WtyczkaBazaDanych
    {
        static void Main(string[] args)
        {
            WyswietlDaneEF();
        }

        public static void WyswietlDaneEF()
        {
            using (BazaDanychKonwerterEntities12 context = new BazaDanychKonwerterEntities12())
            {
                List<TabelaKonwerter> LogiUzycia = context.TabelaKonwerter
                    .OrderBy(T => T.ID)
                    //.Skip(2)
                    //.Take(2)
                    .ToList();

                foreach (TabelaKonwerter T in LogiUzycia)
                {
                    Console.WriteLine(T.RodzajKonwertera);
                }
            }

        }

        public void WstawDaneEF(string RodzajKonwertera, string Jednostka_IN, string Jednostka_OUT, double Liczba_IN, double Liczba_OUT)
        {
            using (BazaDanychKonwerterEntities12 context = new BazaDanychKonwerterEntities12())
            {
                
                TabelaKonwerter newLogiUzycia = new TabelaKonwerter()
                {
                    RodzajKonwertera = RodzajKonwertera,
                    Jednostka_IN = Jednostka_IN,
                    Jednostka_OUT = Jednostka_OUT,
                    //Data = DateTime.Today.ToString(),
                    //Liczba_IN = Liczba_IN.ToString(),
                    //Liczba_OUT = Liczba_OUT.ToString()

                };

                context.TabelaKonwerter.Add(newLogiUzycia);

                context.SaveChanges();
            }
        }
    }
}

