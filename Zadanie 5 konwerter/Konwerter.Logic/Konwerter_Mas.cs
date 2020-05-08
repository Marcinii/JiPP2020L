using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{
    public class Konwerter_Mas :IKonwertery
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
            if (z_jednostki == "Kg")
            {
                if (do_jednostki == "F")
                {
                    this.Wynik = dana * 2.2046;
                }
                if (do_jednostki == "dkg")
                {
                    this.Wynik = dana * 100;
                }
            }
            if (z_jednostki == "F")
            {
                if (do_jednostki == "Kg")
                {
                    this.Wynik = dana / 2.2046;
                }
                if (do_jednostki == "dkg")
                {
                    this.Wynik = (dana / 2.2046) * 100;
                }
            }
            if (z_jednostki == "dkg")
            {
                if (do_jednostki == "Kg")
                {
                    this.Wynik = dana / 100;
                }
                if (do_jednostki == "F")
                {
                    this.Wynik = (dana / 100) * 2.2046;
                }
            }
            if ( z_jednostki == do_jednostki)
            {
                this.wynik = dana;
            }
            return this.Wynik;
        }
    }
}
