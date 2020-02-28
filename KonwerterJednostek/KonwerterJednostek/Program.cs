using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konwerter jednostek\r");
            Console.WriteLine("------------------------\n");
            char czyKontynuowac = 't';

            while (czyKontynuowac == 't') {
            Console.WriteLine("Jaką operację chcesz wykonać? Wybierz z poniższej listy:");
            Console.WriteLine("Konwertowanie temperatury:");
            Console.WriteLine("\t1 - Z Celsjuszy na Farenheity");
            Console.WriteLine("\t2 - Z Farenheity na Celsjusze");
            Console.WriteLine("Konwertowanie dlugości:");
            Console.WriteLine("\t3 - Z kilometrów na mile");
            Console.WriteLine("\t4 - Z mili na kilometry");
            Console.WriteLine("Konwertowanie masy:");
            Console.WriteLine("\t5 - Z kilogramów na funty");
            Console.WriteLine("\t6 - Z funtów na kilogramy");
            Console.Write("Twój wybór? ");

            double liczba = 0;
            double wynik = 0;
            
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
                    Console.Write("Wpisz długość w kilometrach: ");
                    liczba = Convert.ToDouble(Console.ReadLine());
                    wynik = liczba * 0.62137;
                    Console.WriteLine($"Twój wynik: {wynik} mil");
                    break;
                case "4":
                    Console.Write("Wpisz długość w milach: ");
                    liczba = Convert.ToDouble(Console.ReadLine());
                    wynik = liczba/ 0.62137;
                    Console.WriteLine($"Twój wynik: {wynik} kilometrów");
                    break;
                case "5":
                    Console.Write("Wpisz masę w kilogramach: ");
                    liczba = Convert.ToDouble(Console.ReadLine());
                    wynik = liczba * 2.2046;
                    Console.WriteLine($"Twój wynik: {wynik} funtów");
                    break;
                case "6":
                    Console.Write("Wpisz masę w funtach: ");
                    liczba = Convert.ToDouble(Console.ReadLine());
                    wynik = liczba / 2.2046;
                    Console.WriteLine($"Twój wynik: {wynik} kilogramów");
                    break;
                default:
                    Console.WriteLine("Wybrałeś spoza zakresu");
                    break;
            }
            Console.Write("Czy chcesz wykonać kolejną konwersję jednostek? (t/n)");
                czyKontynuowac = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
