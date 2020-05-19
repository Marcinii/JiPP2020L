using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{

    public interface IKonwerter
    {
        string Konwertuj(string jednostkaZ, string jednostkaDo, string wartoscString);
        string Nazwa { get; }
        List<string> Jednostki { get; }
    }

    public abstract class IKonwerterDomyslny : IKonwerter
    {
        public virtual List<string> Jednostki { get => new List<string>(SlownikWartosci?.Keys); }

        public abstract string Nazwa { get; }

        protected Dictionary<string, double> SlownikWartosci;

        public string Konwertuj(string jednostkaZ, string jednostkaDo, string wartoscString)
        {
            double wartosc = 0;
            try
            {
                Double.TryParse(wartoscString, out wartosc);

                return (wartosc * (SlownikWartosci[jednostkaZ] / SlownikWartosci[jednostkaDo])).ToString();
            }
            catch (Exception)
            {
                return wartoscString;
            }
        }
    }

}

