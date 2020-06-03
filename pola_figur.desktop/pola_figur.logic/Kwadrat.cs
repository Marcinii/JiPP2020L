using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pola_figur.logic
{
    public class Kwadrat :IPola_figur
    {
        public string Name => "Kwadrat";
        private decimal a;
        private decimal pole;
        private decimal obwod;
        public List<string> obliczenia => new List<string>
        {
            "Pole",
            "Obwód"
        };
        public decimal A { get => a; set { a = value; } }
        public decimal Pole { get => pole; set { pole = value; } }
        public decimal Obwod { get => obwod; set { obwod = value; } }
        public decimal Licz_pole(decimal a)
        {
            A = a;
            Pole = (A * A);
            return Pole;
        }
        public decimal Licz_obwod(decimal a)
        {
            A = a;
            Obwod = 4 * A;
            return Obwod;
        }
    }
}
