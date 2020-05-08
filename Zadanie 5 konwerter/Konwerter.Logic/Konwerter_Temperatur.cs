using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{
    public class Konwerter_Temperatur :IKonwertery
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
            if(z_jednostki == "C")
            {
                if(do_jednostki == "F")
                {
                    this.Wynik = (dana * 1.8) + 32;                    
                }
                if(do_jednostki == "K")
                {
                    this.Wynik = 273.15 + dana;
                }
            }
            if(z_jednostki == "F")
            {
                if(do_jednostki == "C")
                {
                    this.Wynik = (dana - 32) / 1.8;
                }
                if(do_jednostki == "K")
                {
                    this.Wynik = 273.15 + ((dana - 32) / 1.8);
                }
            }
            if(z_jednostki == "K")
            {
                if(do_jednostki == "C")
                {
                    this.Wynik = dana - 273.15;
                }
                if(do_jednostki == "F")
                {
                    this.Wynik = ((dana - 273.15) * 1.8) + 32;
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
