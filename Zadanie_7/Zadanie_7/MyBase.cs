using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_7
{
    public class MyBase
    {
        [Key]
        public int id { get; set; }
        public string Rodzaj_figury { get; set; }
        public string Co_oblicza { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double H { get; set; }
        public double wynik { get; set; }
    }
}
