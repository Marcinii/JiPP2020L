using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public class Konwersja
    {
        public int Id { get; set; }
        public DateTime DataKonwersji { get; set; }
        public string RodzajKonwertera { get; set; }
        public string JednostkaZ { get; set; }
        public string WartoscDoKonwersji { get; set; }
        public string JednostkaNa { get; set; }
        public string WartoscPoKonwersji { get; set; }
    }
}
