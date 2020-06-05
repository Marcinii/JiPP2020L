using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorCenPosiadlosci.Logika
{
    public interface IPosiadlosc
    {
        string nazwa { get; }

        double mnoznikCeny { get; }

        double ObliczCene(double WielkoscPosiadlosci, Miejscowosc miejscowosc);       
    }
}
