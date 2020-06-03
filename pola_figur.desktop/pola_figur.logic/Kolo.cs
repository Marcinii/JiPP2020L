using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pola_figur.logic
{
    public class Kolo :IPola_figur
    {
        public string Name => "Koło";
        private decimal r;
        const decimal PI = 3.14159m;
        private decimal pole;
        private decimal obwod;
        public List<string> obliczenia => new List<string>
        {
            "Pole",
            "Obwód"
        };
        public decimal R { get => r; set { r = value; } }
        public decimal Pole { get => pole; set { pole = value; } }
        public decimal Obwod { get => obwod; set { obwod = value; } }
        public decimal Licz_pole(decimal r)
        {
            R = r;
            Pole = PI * (R * R);
            return Pole;
        }        
        public decimal Licz_obwod(decimal r)
        {
            R = r;
            Obwod = 2 * PI * R;
            return Obwod;
        }
    }
}