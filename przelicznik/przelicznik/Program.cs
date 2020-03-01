using System;

namespace Konwerter
{

    class Konwerter
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konwerter jednostek\r\n");
            char wyborOpcji = 't';

            while (wyborOpcji == 't')
            {
                double liczba = 0;
                double wynik = 0;
                Console.WriteLine("Jaką operację chcesz wykonać? Wybierz z listy poniżej:\n");

                Console.WriteLine("Konwertowanie temperatury:");
                Console.WriteLine("1- Ze stopni Celsjusza na stopnie Farenheita");
                Console.WriteLine("2- Ze stopni Farenheita na stopnie Celsjusza \n");

                Console.WriteLine("Konwertowanie masy:");
                Console.WriteLine("3- kilogramy na funty");
                Console.WriteLine("4- funty na kilogramy\n");

                Console.WriteLine("Konwertowanie dlugości:");
                Console.WriteLine("5- Z kilometrów na mile");
                Console.WriteLine("6- Z mili na kilometry\n");

                Console.Write("Twój wybór?:\n");

                

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Wpisz temperaturę w stopniach Celsjusza: ");
                        liczba = Convert.ToDouble(Console.ReadLine());
                        wynik = (9.0 / 5.0) * liczba + 32;
                        Console.WriteLine($"Twój wynik: {wynik} stopni Fahrenheita");
                        break;
                    case "2":
                        Console.Write("Wpisz temperaturę w stopniach Fahrenheita: ");
                        liczba = Convert.ToDouble(Console.ReadLine());
                        wynik = (5.0 / 9.0) * (liczba - 32);
                        Console.WriteLine($"Twój wynik: {wynik} stopni Celsjusza");
                        break;
                    case "3":
                        Console.Write("Wpisz masę w kilogramach: ");
                        liczba = Convert.ToDouble(Console.ReadLine());
                        wynik = liczba * 2.2046;
                        Console.WriteLine($"Twój wynik: {wynik} funtów");
                        break;
                    case "4":
                        Console.Write("Wpisz masę w funtach: ");
                        liczba = Convert.ToDouble(Console.ReadLine());
                        wynik = liczba * 0.4535;
                        Console.WriteLine($"Twój wynik: {wynik} kilogramów");
                        break;
                    case "5":
                        Console.Write("Wpisz długość w kilometrach: ");
                        liczba = Convert.ToDouble(Console.ReadLine());
                        wynik = liczba / 1.6093;
                        Console.WriteLine($"Twój wynik: {wynik} mil");
                        break;
                    case "6":
                        Console.Write("Wpisz długość w milach: ");
                        liczba = Convert.ToDouble(Console.ReadLine());
                        wynik = liczba * 1.6093;
                        Console.WriteLine($"Twój wynik: {wynik} kilometrów");
                        break;
                    
                }
                Console.Write("Czy chcesz wykonać kolejne konwersje? (t/n)");
                wyborOpcji = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
