using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KonwerterWPF
{
    class Zegar
    {
        RotateTransform godziny;
        RotateTransform minuty;

        public Zegar(RotateTransform godziny, RotateTransform minuty)
        {
            this.godziny = godziny;
            this.minuty = minuty;
        }

        public void UstawCzas(DateTime dt)
        {
            float mm = dt.Minute;
            float hh = dt.Hour % 12;
            //90 stopni - 0 minut
            //90 stopni - 12 godzina

            godziny.Angle = 90 + (hh / 12 * 360);
            minuty.Angle = 90 + (mm / 60 * 360);
        }
    }
}
