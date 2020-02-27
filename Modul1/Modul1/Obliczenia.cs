using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1
{
    class Temperatura
    {
        public double Celsjusz { get; set; }
        public double Farenheit { get; set; }
        public void Zam1() { Farenheit = 1.8 * Celsjusz + 32; }
        public void Zam2() { Celsjusz = (Farenheit - 32) * (5.0 / 9.0); }
    }
    class Dlugosc
    {
        public double Kilometry { get; set; }
        public double Mile { get; set; }
        public void Zam1() { Mile = Kilometry * 0.62137; }
        public void Zam2() { Kilometry = Mile * 1.609344; }
    }
    class Waga
    {
        public double Kilogram { get; set; }
        public double Funt { get; set; }
        public void Zam1() { Funt = Kilogram * 0.45359237; }
        public void Zam2() { Kilogram = Funt * 2.20462262; }
    }
}
