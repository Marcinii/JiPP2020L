using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3
{
    public class DBOcena
    {
        public void dodac2(int a)
        {
            using (JIPPEntities context = new JIPPEntities())
            {
                Ocena newo = new Ocena()
                {
                    Oceny = a

                };
                context.Ocenas.Add(newo);
                context.SaveChanges();
            }
        }
    }
}
