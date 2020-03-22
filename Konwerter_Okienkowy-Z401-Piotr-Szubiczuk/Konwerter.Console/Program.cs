using System;
using System.Collections.Generic;


namespace Konwerter
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Ikonwenter> konw = new List<Ikonwenter>()
            {
                new CnF(),
                new FnC(),
                new FnKG(),
                new KGnF(),
                new KMnM(),
                new MnKM()

            };
            while (true)
            {
                Console.WriteLine("\nCo zamieniamy?\n");
                Console.WriteLine("1. Fahrenhaity na celcjusze");
                Console.WriteLine("2. Celcjusze na fahrenhaity");
                Console.WriteLine("3. Kilometry na mile");
                Console.WriteLine("4. Mile na kilometry");
                Console.WriteLine("5. Kilogram na funt");
                Console.WriteLine("6. Funt na kilogram");
                Console.WriteLine("7. Funt na kilogram");
                Console.WriteLine("8. Funt na kilogram");
                Console.WriteLine("0. Wyjscie");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Podaj farenhaity");
                        double wartosc = Convert.ToDouble(Console.ReadLine());
                        FnC kon1 = new FnC();
                        Console.WriteLine("Fahrenhaita to " + (kon1.Konwer("z", "na", wartosc)).ToString() + " Celcjuszy");
                        break;
                    case "2":
                        Console.WriteLine("Podaj Celcjuze");
                        double wartosc2 = Convert.ToDouble(Console.ReadLine());
                        CnF kon2 = new CnF();
                        Console.WriteLine("Celcjusza to " + (kon2.Konwer("z", "na", wartosc2)).ToString() + " Fahrenhaitow");
                        break;
                    case "3":
                        Console.WriteLine("Podaj Funty");
                        double wartosc3 = Convert.ToDouble(Console.ReadLine());
                        FnKG kon3 = new FnKG();
                        Console.WriteLine("Funtow to " + (kon3.Konwer("z", "na", wartosc3)).ToString() + " Kilogramow");
                        break;
                    case "4":
                        Console.WriteLine("Podaj Kilogramy");
                        double wartosc4 = Convert.ToDouble(Console.ReadLine());
                        KGnF kon4 = new KGnF();
                        Console.WriteLine("Kilogramow to " + (kon4.Konwer("z", "na", wartosc4)).ToString() + " Funtow");
                        break;
                    case "5":
                        Console.WriteLine("Podaj Kilomety");
                        double wartosc5 = Convert.ToDouble(Console.ReadLine());
                        KMnM kon5 = new KMnM();
                        Console.WriteLine("Kilometorw to " + (kon5.Konwer("z", "na", wartosc5)).ToString() + " Mil");
                        break;
                    case "6":
                        Console.WriteLine("Podaj Mile");
                        double wartosc6 = Convert.ToDouble(Console.ReadLine());
                        MnKM kon6 = new MnKM();
                        Console.WriteLine("Mil to " + (kon6.Konwer("z", "na", wartosc6)).ToString() + " Kilometrow");
                        break;
                    case "7":
                        Console.WriteLine("Podaj Kilowaty");
                        double wartosc7 = Convert.ToDouble(Console.ReadLine());
                        KWnW kon7 = new KWnW();
                        Console.WriteLine("Kilowatow " + (kon7.Konwer("z", "na", wartosc7)).ToString() + " Watow");
                        break;
                    case "8":
                        Console.WriteLine("Podaj Kilowaty");
                        double wartosc8 = Convert.ToDouble(Console.ReadLine());
                        KWnKM kon8 = new KWnKM();
                        Console.WriteLine("Kilowatow " + (kon8.Konwer("z", "na", wartosc8)).ToString() + "Koni mechanicznych");
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Zly wybor");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
