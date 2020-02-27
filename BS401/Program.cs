using System;

namespace ZAD1
{
    class Konwerter
    {
        public double Temperatura(double tem, bool co)
        {
            double f = 0, c = 0;
            if (co == true)
            {
                c = tem;
                f = 32 + ((9.0 / 5.0) * c);
                return f;
            }
            else
            {
                f = tem;
                c = 5.0 / 9.0 * (f - 32);
                return c;
            }
        }
 
        public double Odleglosc(double odl, bool co)
        {
            double km = 0, mi = 0;
            if (co == true)
            {
                mi = odl;
                km = mi / 0.62137;
                return km;
            }
            else
            {
                km = odl;
                mi = km * 0.62137;
                return mi;
            }
        }
        public double Masa(double mas, bool co)
        {
            double kg = 0, lb = 0;
            if (co == true)
            {
                lb = mas;
                kg = lb / 2.2046;
                return kg;
            }
            else
            {
                kg = mas;
                lb = kg * 2.2046;
                return lb;
            }
        }
        
    }
    class Zadanie { 
   
        static void Main(string[] args)
        {
            int numer = 0;
            double liczba;
            bool czyBlad = true;
            Konwerter przelicz = new Konwerter();

            while (czyBlad) 
                {
                Console.WriteLine("Wybierz opcje: \n1) Celsjusz na Fahrenheit [C ==> F] \n2) Fahrenheit na Celsjusz [F ==> C] \n3) Kilometry na Mile [km ==> mi] \n4) Mile na Kilometry [mi ==> km] \n5) Funty na Kilogramy [lb ==> kg] \n6) Kilogramy na Funty [kg ==> lb]");
                Console.WriteLine("\n\nWybierz opcje wpisujac liczbe od 1 do 6: ");
                numer = int.Parse(Console.ReadLine());
                Console.WriteLine("\nWprowadz dane: ");
                liczba = int.Parse(Console.ReadLine());
                switch (numer)
                    {
                        case 1:
                        if (liczba < -273.15) { break; }
                            Console.WriteLine(przelicz.Temperatura(liczba, true));
                            czyBlad = false;
                            break;
                        case 2:
                        if(liczba < -459.67) { break; }
                            Console.WriteLine(przelicz.Temperatura(liczba, false));
                            czyBlad = false;
                            break;
                        case 3:
                        if (liczba < 0) { break; }
                            Console.WriteLine(przelicz.Odleglosc(liczba, true));
                            czyBlad = false;
                            break;
                        case 4:
                        if (liczba < 0) { break; }
                            Console.WriteLine(przelicz.Odleglosc(liczba, false));
                            czyBlad = false;
                            break;
                        case 5:
                        if (liczba < 0) { break; }
                            Console.WriteLine(przelicz.Masa(liczba, true));
                            czyBlad = false;
                            break;
                        case 6:
                        if (liczba < 0) { break; }
                            Console.WriteLine(przelicz.Masa(liczba, false));
                            czyBlad = false;
                            break;
                        default:
                            Console.WriteLine("blad");
                            czyBlad = true;
                            break;
                    }
                }
        }

    }
}
