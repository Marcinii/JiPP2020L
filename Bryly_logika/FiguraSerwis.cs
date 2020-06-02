using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaBryly
{
    public class FiguraSerwis
    {
        public List<IFigura> GetFiguras()

        {
            return new List<IFigura>()
            {
                new Kwadrat(),
                new Prostokat(),
                new Trojkat()
            };
        }
    }
}
