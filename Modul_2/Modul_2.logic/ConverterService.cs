using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_2

{
    public class ConverterService
    {
        public List<Ikonwerter> GetConverter()
        {
            return new List<Ikonwerter>
            {
                new Dlugosc(),
                new Temperatura(),
                new Czas(),
                new Waga()
            };
        }
    }
}