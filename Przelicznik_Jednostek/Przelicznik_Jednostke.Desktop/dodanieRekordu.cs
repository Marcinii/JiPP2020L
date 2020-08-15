using Przelicznik_Jednostek;
using Przelicznik_Jednostek.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Przelicznik_Jednostke.Desktop
{
   public class dodanieRekordu
    {
        public static void dodajRekord(string kowerjsa, string przed, string po)
        {
            using (model_danych context = new model_danych())
            {
                daneBazaDBO dodaj = new daneBazaDBO()
                {
                    
                    typ_konwersji = kowerjsa,
                    data_konwersji = DateTime.Now,
                    jed_przed = przed,
                    jed_po = po
                };
                context.bazaDane.Add(dodaj);
                context.SaveChanges();
            }
        }
        public static void dodajOcene(int ocenaq)
        {
            using (model_danych context = new model_danych())
            {
               ocenaDBO dodajOcene = new ocenaDBO()
                {

                    ocena = ocenaq

            };
            context.OcenaDBOs.Add(dodajOcene);
            context.SaveChanges();
        }
            
        }

    }
}
