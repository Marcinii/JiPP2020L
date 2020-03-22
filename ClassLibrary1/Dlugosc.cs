using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2
{

    public class Dlugosc: Ikonwerter

    {
       public string nazwa => "Dlugosc";
        public List<string> Unit => new List<string>() {
            "Kilometry -Mile",
            "Mile-Kilometry",
            "Metry-Kilometry",
            "Kilometry-Metry"
    };
        public double Zamiana(double wynik, int x)
        {
            if (x == 1)
                return 0.62137*wynik; //Mile na Kilometry
            if (x == 2)
                return wynik*1.6079344;//Kilometry na Mile
            if (x == 3)
                return wynik * 0.001;//Metry na Kilometry
            if (x == 4)
                return wynik * 1000;//Kilometry na Metry
            else return 0;
        }
    }
}
