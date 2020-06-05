using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorCenPosiadlosci.Logika
{
    public class Mieszkanie : IPosiadlosc
    {
        public string nazwa => "Mieszkanie";

        public double mnoznikCeny => 60;

        public double ObliczCene(double WielkoscPosiadlosci, Miejscowosc miejscowosc)
        {
            double mnoznik = double.Parse(miejscowosc.mnoznikCeny.ToString());
            return WielkoscPosiadlosci * mnoznikCeny * mnoznik;
        }
    }
}
