using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public static class Dispatcher
    {

        public static object ConvertWithDispatch(string unitFrom, string unitTo, object valueToConvert)
        {
            var converter = DispatchConvert(unitFrom, unitTo);
            return converter.Convert(valueToConvert);
        }

        public static IKonwerter DispatchConvert(string unitFrom, string unitTo)
        {
            switch (unitFrom)
            {
                case "c":
                    switch (unitTo)
                    {
                        case "f":
                            return new CelciusToFarenheit();
                        default:
                            throw new Exception("Zła konwersja");
                    }

                case "f":
                    switch (unitTo)
                    {
                        case "c":
                            return new FahrenheitToCelcius();
                        default:
                            throw new Exception("Zła konwersja");
                    }

                case "kg":
                    switch (unitTo)
                    {
                        case "lb":
                            return new KilogramsToPounds();
                        default:
                            throw new Exception("Zła konwersja");
                    }

                case "lb":
                    switch (unitTo)
                    {
                        case "kg":
                            return new PoundsToKilograms();
                        default:
                            throw new Exception("Zła konwersja");
                    }

                case "km":
                    switch (unitTo)
                    {
                        case "mil":
                            return new KilometresToMiles();
                        default:
                            throw new Exception("Zła konwersja");
                    }

                case "mil":
                    switch (unitTo)
                    {
                        case "km":
                            return new MilesToKilometres();
                        default:
                            throw new Exception("Zła konwersja");
                    }

                case "Pa":
                    switch (unitTo)
                    {
                        case "hPa":
                            return new Cisnienie_Pa_To_hPa();
                        default:
                            throw new Exception("Zła konwersja");
                    }


                case "hPa":
                    switch (unitTo)
                    {
                        case "Pa":
                            return new Cisnienie_hPa_To_Pa();
                        default:
                            throw new Exception("Zła konwersja");
                    }

                case "T12":
                    switch (unitTo)
                    {
                        case "T24":
                            return new Time12To24();
                        default:
                            throw new Exception("Zła konwersja");
                    }
                case "T24":
                    switch (unitTo)
                    {
                        case "T12":
                            return new Time24To12();
                        default:
                            throw new Exception("Zła konwersja");
                    }
                default:
                    throw new Exception("Nieznana jednostka");
            }
        }
    }
}
