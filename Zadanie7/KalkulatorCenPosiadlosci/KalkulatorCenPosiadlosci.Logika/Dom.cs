using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorCenPosiadlosci.Logika
{
    public class Dom : IPosiadlosc
    {
        public string nazwa => "Dom";

        public double mnoznikCeny => 40;

        public double ObliczCene(double WielkoscPosiadlosci, Miejscowosc miejscowosc)
        {
            double oplatyDodatkowe = WielkoscPosiadlosci * ( mnoznikCeny / 2);
            double mnoznik = double.Parse(miejscowosc.mnoznikCeny.ToString());
            return WielkoscPosiadlosci * mnoznikCeny * mnoznik+ oplatyDodatkowe;
        }
    }
}
