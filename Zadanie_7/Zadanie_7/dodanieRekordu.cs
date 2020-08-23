using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_7
{
    class dodanieRekordu
    {
        public static void dodajeRekord(string rodzaj,string obliczyl,double a, double b, double c,double h,double wyn)
        {
            using (Model1 context = new Model1())
            {
                MyBase dodaj = new MyBase()
                {
                    Rodzaj_figury = rodzaj,
                    Co_oblicza = obliczyl,
                    A = a,
                    B = b,
                    C = c,
                    H = h,
                    wynik = wyn
                };
                context.data.Add(dodaj);
                context.SaveChanges();
            }
        }
        public static void dodajOcene(int ocena)
        {
            using(Model1 context = new Model1())
            {
                MyRate rate = new MyRate()
                {
                    rate_value = ocena
                };
                context.rates.Add(rate);
                context.SaveChanges();
            }
        }
    }
}
