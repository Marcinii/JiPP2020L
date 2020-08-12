using System;
using System.Text;
using System.Collections.Generic;

namespace KonwerterJednostek.Biblioteka
{
    public class KonwerterCzasu : IKonwerter
    {
        public string Nazwa => "Czas";
        public List<string> Jednostki => new List<string>() { "am", "pm", "h" };
        public double Konwertuj(double wartWejsc, string jednWejsc, string jednWyjsc)
        {
            return 0;
        }
    }

    public class KonwerterDystansu : IKonwerter
    {
        public string Nazwa => "Dystans";
        public List<string> Jednostki => new List<string> { "m", "ft" /* stopy */, "yd" /* yardy */  };
        public double Konwertuj(double wartWejsc, string jednWejsc, string jednWyjsc)
        {
            switch (jednWejsc)
            {
                case "m":
                    if (jednWyjsc == "ft") { return wartWejsc * 3.281; }
                    else if (jednWyjsc == "yd") { return wartWejsc * 1.09361; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
                case "ft":
                    if (jednWyjsc == "m") { return wartWejsc / 3.281; }
                    else if (jednWyjsc == "yd") { return wartWejsc / 3; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
                case "yd":
                    if (jednWyjsc == "ft") { return wartWejsc * 3; }
                    else if (jednWyjsc == "m") { return wartWejsc / 1.09361; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
            }
            throw new Exception("Niepoprawna jednostka");
        }
    }

    public class KonwerterMasy : IKonwerter
    {
        public string Nazwa => "Masa";
        public List<string> Jednostki => new List<string> { "g", "kg", "oz" /* uncja */ };
        public double Konwertuj(double wartWejsc, string jednWejsc, string jednWyjsc)
        {
            switch (jednWejsc)
            {
                case "g":
                    if (jednWyjsc == "kg") { return wartWejsc / 1000; }
                    else if (jednWyjsc == "oz") { return wartWejsc / 28.35; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
                case "kg":
                    if (jednWyjsc == "g") { return wartWejsc * 1000; }
                    else if (jednWyjsc == "oz") { return wartWejsc * 35.274; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
                case "oz":
                    if (jednWyjsc == "g") { return wartWejsc * 28.35; }
                    else if (jednWyjsc == "kg") { return wartWejsc / 35.274; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
            }
            throw new Exception("Niepoprawna jednostka");

        }
    }

    public class KonwerterObjetosci : IKonwerter
    {
        public string Nazwa => "Objetosc";
        public List<string> Jednostki => new List<string> { "m3", "cm3", "l" };
        public double Konwertuj(double wartWejsc, string jednWejsc, string jednWyjsc)
        {
            switch (jednWejsc)
            {
                case "cm3":
                    if (jednWyjsc == "m3") { return wartWejsc / 1000000; }
                    else if (jednWyjsc == "l") { return wartWejsc / 1000; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
                case "m3":
                    if (jednWyjsc == "cm3") { return wartWejsc * 1000000; }
                    else if (jednWyjsc == "l") { return wartWejsc * 1000; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
                case "l":
                    if (jednWyjsc == "cm3") { return wartWejsc * 1000; }
                    else if (jednWyjsc == "m3") { return wartWejsc / 1000; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
            }
            throw new Exception("Niepoprawna jednostka");
        }
    }

    public class KonwerterTemperatury : IKonwerter
    {
        public string Nazwa => "Temperatura";
        public List<string> Jednostki => new List<string> { "C", "F", "K" };
        public double Konwertuj(double wartWejsc, string jednWejsc, string jednWyjsc)
        {
            switch (jednWejsc)
            {
                case "C":
                    if (jednWyjsc == "F") { return (wartWejsc * 9 / 5) + 32; }
                    else if (jednWyjsc == "K") { return wartWejsc + 273.15; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
                case "F":
                    if (jednWyjsc == "C") { return (wartWejsc - 32) * 5 / 9; }
                    else if (jednWyjsc == "K") { return ((wartWejsc - 32) * 5 / 9) + 273.15; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
                case "K":
                    if (jednWyjsc == "F") { return ((wartWejsc - 273.15) * 9 / 5) + 32; }
                    else if (jednWyjsc == "C") { return wartWejsc - 273.15; }
                    else if (jednWyjsc == jednWejsc) { return wartWejsc; }
                    break;
            }
            throw new Exception("Niepoprawna jednostka");
        }
    }
}
