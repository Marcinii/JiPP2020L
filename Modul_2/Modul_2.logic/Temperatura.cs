using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_2 { 
   public class Temperatura:Ikonwerter

    {
        public string nazwa => "Temperatura";
        public List<string> Unit => new List<string>() {
            "Celcjusz-Farenheit",
            "Farenthajt-Celcjusz"
        };
        public double Zamiana(double zmienna, int x) {
            if (x == 1)
                return 1.8 * zmienna + 32; //faRenhait
            if (x == 2)
                return (zmienna - 32) * (5.0 / 9.0);//Celsjusz
            else return 0;
        }
    }
}
