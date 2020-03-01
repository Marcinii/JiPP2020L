using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    class Konwerter
    {
        protected double temperaturaWCelsjuszach;
        protected double temperaturaWFarenheitach;
        protected double dlugoscWKilometrach;
        protected double dlugoscWMilach;
        protected double wagaWKilogramach;
        protected double wagaWFuntach;

        public double CelsjuszeNaFarenheity(double temperatura)
        {
            temperaturaWCelsjuszach = temperatura;
            Console.WriteLine("Temperatura w Celsjuszach: " + temperaturaWCelsjuszach.ToString());
            temperaturaWFarenheitach = ((9 / 5) * temperaturaWCelsjuszach) + 32;
            return temperaturaWFarenheitach;
        }

        public double AktualnaTemperaturawFarenheitach()
        {
            return temperaturaWFarenheitach;
        }

        public void PokazTemperatureWFarenheitach()
        {
            double tmpWF = AktualnaTemperaturawFarenheitach();
            Console.WriteLine("Temperatura w Farenheitach: " + tmpWF.ToString());
        }

        public double FarenheityNaCelsjusze(double temperatura)
        {
            temperaturaWFarenheitach = temperatura;
            Console.WriteLine("Temperatura w Farenheitach: " + temperaturaWFarenheitach.ToString());
            temperaturaWCelsjuszach = (temperaturaWFarenheitach - 32) / (9/5);
            return temperaturaWCelsjuszach;
        }

        public double AktualnaTemperaturawCelsjuszach()
        {
            return temperaturaWCelsjuszach;
        }

        public void PokazTemperatureWCelsjuszach()
        {
            double tmpC = AktualnaTemperaturawCelsjuszach();
            Console.WriteLine("Temperatura w Celsjuszach: " + tmpC.ToString());
        }

        public double KilometryNaMile(double km)
        {
            dlugoscWKilometrach = km;
            Console.WriteLine("Dlugosc w kilometrach: " + dlugoscWKilometrach.ToString());
            dlugoscWMilach = dlugoscWKilometrach*1.609;
            return dlugoscWMilach;
        }

        public double AktualnaDlugoscWMilach()
        {
            return dlugoscWMilach;
        }

        public void PokazDlugoscWMilach()
        {
            double dlWMilach = AktualnaDlugoscWMilach();
            Console.WriteLine("Dlugosc w Milach: " + dlWMilach.ToString());
        }

        public double MileNaKilometry(double mile)
        {
            dlugoscWMilach = mile;
            Console.WriteLine("Dlugosc w milach: " + dlugoscWMilach.ToString());
            dlugoscWKilometrach = dlugoscWMilach * 0.621371192;
            return dlugoscWKilometrach;
        }

        public double AktualnaDlugoscWKilometrach()
        {
            return dlugoscWKilometrach;
        }

        public void PokazDlugoscWKilometrach()
        {
            double dlWKM = AktualnaDlugoscWKilometrach();
            Console.WriteLine("Dlugosc w Kilometrach: " + dlWKM.ToString());
        }

        public double KilogramyNaFunty(double kg)
        {
            wagaWKilogramach = kg;
            Console.WriteLine("Waga w kilogramach: " + wagaWKilogramach.ToString());
            wagaWFuntach = wagaWKilogramach * 2.20462262;
            return wagaWFuntach;
        }

        public double AktualnaWagaWFuntach()
        {
            return wagaWFuntach;
        }

        public void PokazWageWFuntach()
        {
            double wagaWFuntach = AktualnaWagaWFuntach();
            Console.WriteLine("Waga w funtach: " + wagaWFuntach.ToString());
        }

        public double FuntyNaKilogramy(double funty)
        {
            wagaWFuntach = funty;
            Console.WriteLine("Waga w funtach: " + wagaWFuntach.ToString());
            wagaWKilogramach = wagaWFuntach * 0.45359237;
            return wagaWKilogramach;
        }

        public double AktualnaWagaWKilogramach()
        {
            return wagaWKilogramach;
        }

        public void PokazWageWKilogramach()
        {
            double wagaWKG = AktualnaWagaWKilogramach();
            Console.WriteLine("Waga w Kilogramach: " + wagaWKG.ToString());
        }

    }
}
