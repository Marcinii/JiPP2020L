using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
   public class Daj
    {
        public void dodaj(string x, int i)
        {
            using (DziennikEntities context = new DziennikEntities())
            {
                Uczen newucz = new Uczen()
                {
                    Przedmiot = x,
                    Ocena = i,
                    Data = DateTime.Now
                };
                context.Uczen.Add(newucz);
                context.SaveChanges();
            }
        }
    }
}
