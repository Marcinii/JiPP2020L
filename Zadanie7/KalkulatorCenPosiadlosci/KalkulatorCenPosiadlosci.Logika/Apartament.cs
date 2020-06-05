using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorCenPosiadlosci.Logika
{
    public class Apartament : IPosiadlosc
    {
        public string nazwa => "Apartament";

        public double mnoznikCeny => 105;

        public double ObliczCene(double WielkoscPosiadlosci, Miejscowosc miejscowosc)
        {
            double oplatyDodatkowe = WielkoscPosiadlosci * (mnoznikCeny/1.2);
            double mnoznik = double.Parse(miejscowosc.mnoznikCeny.ToString());
            return WielkoscPosiadlosci * mnoznikCeny * mnoznik + oplatyDodatkowe;
        }
    }
}
