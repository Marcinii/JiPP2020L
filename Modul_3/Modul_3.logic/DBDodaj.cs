using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3
{
   public class DBDodaj
    {
        public void dodac(string a, string b, decimal c, decimal d)
        {
            using (JIPPEntities context = new JIPPEntities())
            {
                Stata newstata = new Stata()
                {
                    Rodzaj_Konwertera = a,
                    Wybrana_jednostka = b,
                    Data_Konwersji = DateTime.Now.Date,
                    Wartosc_podana = c,
                    Wartosc_uzyskana = d


                };
                context.Statas.Add(newstata);
                context.SaveChanges();
            }
        }
    }
}
