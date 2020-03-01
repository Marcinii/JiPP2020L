using System;

namespace Konwerter
{
    class Program
    {

        static void Main(string[] args)
        {
            Konwerter konwerter = new Konwerter();

            int wybor = 0, parametr = 0;
            double tmp = 0, dl = 0, waga = 0;
            Console.WriteLine("\r\n Wybierz konwerter: \r\n 1. Konwerter jednostek \r\n 2. Konwerter dlugosci: \r\n 3. Konwerter masy: ");
            wybor = Convert.ToInt32(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    Console.WriteLine("Konwerter jednostek");
                    Console.WriteLine("\r\n Wybierz zamiane: \r\n 1. Skala Celsjusza na Farenheita \r\n 2. Skala Farenheita na Celsjusza: \r\n");
                    parametr = Convert.ToInt32(Console.ReadLine());
                    switch (parametr)
                    {
                        case 1:
                            Console.WriteLine("Skala Celsjusza na Farenheita");
                            Console.WriteLine("Podaj temperature w Celsjuszach: ");
                            tmp = Convert.ToDouble(Console.ReadLine());
                            konwerter.CelsjuszeNaFarenheity(tmp);
                            konwerter.PokazTemperatureWFarenheitach();
                            break;
                        case 2:
                            Console.WriteLine("Skala Farenheita na Celsjusza");
                            Console.WriteLine("Podaj temperature w Farenheitach: ");
                            tmp = Convert.ToDouble(Console.ReadLine());
                            konwerter.FarenheityNaCelsjusze(tmp);
                            konwerter.PokazTemperatureWCelsjuszach();
                            break;
                        default:
                            Console.WriteLine("Zly wybor");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Konwerter dlugosci");
                    Console.WriteLine("\r\n Wybierz zamiane: \r\n 1. Kilometry na mile \r\n 2. Mile na kilometry: \r\n");
                    parametr = Convert.ToInt32(Console.ReadLine());
                    switch (parametr)
                    {
                        case 1:
                            Console.WriteLine("Zamiana kilometrow na mile");
                            Console.WriteLine("Podaj dlugosc w kilometrach: ");
                            dl = Convert.ToDouble(Console.ReadLine());
                            konwerter.KilometryNaMile(dl);
                            konwerter.PokazDlugoscWMilach();
                            break;
                        case 2:
                            Console.WriteLine("Zamiana mil na kilometry");
                            Console.WriteLine("Podaj dlugosc w milach: ");
                            dl = Convert.ToDouble(Console.ReadLine());
                            konwerter.MileNaKilometry(dl);
                            konwerter.PokazDlugoscWKilometrach();
                            break;
                        default:
                            Console.WriteLine("Zly wybor");
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Konwerter masy");
                    Console.WriteLine("\r\n Wybierz zamiane: \r\n 1. Kilogramy na funty \r\n 2. Funty na kilogramy: \r\n");
                    parametr = Convert.ToInt32(Console.ReadLine());
                    switch (parametr)
                    {
                        case 1:
                            Console.WriteLine("Zamiana kilogramow na funty");
                            Console.WriteLine("Podaj wage w kilogramach: ");
                            waga = Convert.ToDouble(Console.ReadLine());
                            konwerter.KilogramyNaFunty(waga);
                            konwerter.PokazWageWFuntach();
                            break;
                        case 2:
                            Console.WriteLine("Zamiana funtow na kilogramy");
                            Console.WriteLine("Podaj wage w funtach: ");
                            waga = Convert.ToDouble(Console.ReadLine());
                            konwerter.FuntyNaKilogramy(waga);
                            konwerter.PokazWageWKilogramach();
                            break;
                        default:
                            Console.WriteLine("Zly wybor");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Zly wybor");
                    break;
            }
        }
    }
}

