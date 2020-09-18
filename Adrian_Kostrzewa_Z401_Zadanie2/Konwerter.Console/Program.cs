using System;
using System.Collections.Generic;


namespace Konwerter
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Ikonwenter> kw = new List<Ikonwenter>()
            {
                new CelnaFah(),
                new FahnaCel(),
                new FunnaKil(),
                new KilnaFun(),
                new KMnaM(),
                new MnaKM(),
                new KMHnaMPH(),
                new MPHnaKMH()

            };
            while (true)
            {
                Console.WriteLine("\nJakie jednostki konwertujemy?\n");
                Console.WriteLine("1. kilogramy na funt?");
                Console.WriteLine("2. Funty na kilogramy?");
                Console.WriteLine("3. kilometry na mile?");
                Console.WriteLine("4. Mile na kilometry?");
                Console.WriteLine("5. Fahrenhaity na Celcjusze");
                Console.WriteLine("6. Celecjusze na Fahrenhaity?");
                Console.WriteLine("7. Km/h na mph?");
                Console.WriteLine("8. Mph na km/h?");
                Console.WriteLine("0. Koniec");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Podaj Kilogramy");
                        double w1 = Convert.ToDouble(Console.ReadLine());
                        KilnFun k1 = new KilnFun();
                        Console.WriteLine("Kilogramow to " + (k1.Konwer("z", "na", w1)).ToString() + " Funtow");
                        break;
                    case "2":
                        Console.WriteLine("Podaj Funty");
                        double w2 = Convert.ToDouble(Console.ReadLine());
                        FunnKil k2 = new FunnKil();
                        Console.WriteLine("Funtow to " + (k2.Konwer("z", "na", w2)).ToString() + " Kilogramow");
                        break;
                    case "3":
                        Console.WriteLine("Podaj Kilomety");
                        double w3 = Convert.ToDouble(Console.ReadLine());
                        KMnaM k3 = new KMnaM();
                        Console.WriteLine("Kilometorw to " + (k3.Konwer("z", "na", w3)).ToString() + " Mil");
                        break;
                    case "4":
                        Console.WriteLine("Podaj Mile");
                        double w4 = Convert.ToDouble(Console.ReadLine());
                        MnaKM k4 = new MnaKM();
                        Console.WriteLine("Mil to " + (k4.Konwer("z", "na", w4)).ToString() + " Kilometrow");
                        break;
                    case "5":
                        Console.WriteLine("Podaj farenhaity");
                        double w5 = Convert.ToDouble(Console.ReadLine());
                        FahnaCel k5 = new FahnaCel();
                        Console.WriteLine("Fahrenhaita to " + (k5.Konwer("z", "na", w5)).ToString() + " Celcjuszy");
                        break;
                    case "6":
                        Console.WriteLine("Podaj Celcjuze");
                        double w6 = Convert.ToDouble(Console.ReadLine());
                        CelnaFah k6 = new CelnaFah();
                        Console.WriteLine("Celcjusza to " + (k6.Konwer("z", "na", w6)).ToString() + " Fahrenhaitow");
                        break;
                    case "7":
                        Console.WriteLine("Podaj KM/h");
                        double w7 = Convert.ToDouble(Console.ReadLine());
                        KMHnaMPH k7 = new KWnW();
                        Console.WriteLine("Km/h " + (k7.Konwer("z", "na", w7)).ToString() + " mp/h");
                        break;
                    case "8":
                        Console.WriteLine("Podaj mp/h");
                        double w8 = Convert.ToDouble(Console.ReadLine());
                        MPHnaKMH k8 = new KWnKM();
                        Console.WriteLine("mp/h " + (k8.Konwer("z", "na", w8)).ToString() + " KM/h");
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
