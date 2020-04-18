using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    class KonverterService
    {
        public List<IKonwerter> GetConverters()
        {
            return new List<IKonwerter>()
            {
                new Cisnienie_hPa_To_Pa(),
                new Cisnienie_Pa_To_hPa(),
                new CelciusToFarenheit(),
                new FahrenheitToCelcius(),
                new KilogramsToPounds(),
                new PoundsToKilograms(),
                new MilesToKilometres(),
                new KilometresToMiles(),
                new Time12To24(),
                new Time24To12()
            };
        }
    }
}
