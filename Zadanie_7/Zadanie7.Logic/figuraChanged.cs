using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie_7;

namespace Zadanie7.Logic
{
    public class figuraChanged
    {
        public List<Ifigury> pobierz()
        {
          return  new List<Ifigury>()
            {
                new trojkat(),
                new kwadrat()
            };
        }
    }
}
