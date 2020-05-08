using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{
    public class Konwerter_Mocy :IKonwertery
    {
        double wynik, dana;
        public double Wynik { get => wynik; set => wynik = value; }
        public double Dana { get => dana; set => dana = value; }

        public void Konwertuj_i_Pokaz(string z_jednostki, string do_jednostki, double dana)
        {
            Konwertuj(z_jednostki, do_jednostki, dana);
            Console.WriteLine(dana.ToString() + " " + z_jednostki + " = " + this.Wynik.ToString() + do_jednostki);
        }
        public double Konwertuj(string z_jednostki, string do_jednostki, double dana)
        {
            this.Dana = dana;
            if (z_jednostki == "W")
            {
                if (do_jednostki == "kW")
                {
                    this.Wynik = dana / 1000;
                }
                if (do_jednostki == "KM")
                {
                    this.Wynik = (dana / 1000) * 1.36;
                }
            }
            if (z_jednostki == "KM")
            {
                if (do_jednostki == "W")
                {
                    this.Wynik = (dana / 1.36) * 1000;
                }
                if (do_jednostki == "kW")
                {
                    this.Wynik = dana / 1.36;
                }
            }
            if (z_jednostki == "kW")
            {
                if (do_jednostki == "KM")
                {
                    this.Wynik = dana * 1.36;
                }
                if (do_jednostki == "W")
                {
                    this.Wynik = dana * 1000;
                }
            }
            if (z_jednostki == do_jednostki)
            {
                this.wynik = dana;
            }
            return this.Wynik;
        }
    }
}
