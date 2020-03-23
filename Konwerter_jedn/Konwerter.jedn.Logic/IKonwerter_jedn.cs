using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jedn
{
    public interface IKonwerter_jedn
    {
      string Nazwa { get; }

      List<string> Jednostki { get; }

        string naPodst(string Zjakiej, string dane);
        string naWybr(string Zjakiej, string DOjakiej, string dane);
    }
}
