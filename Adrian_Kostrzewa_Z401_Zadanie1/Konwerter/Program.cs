using System;
namespace Konwerter
{
    class Program
    {
        static double kilnafun()                          
        {
            double kg, f;
            f = double.Parse(Console.ReadLine());
            kg = 2.20462262D * f;
            return kg;
        }
        static double funnakil()                         
        {
            double kg, f;
            kg = double.Parse(Console.ReadLine());
            f = kg / 0.45359237D;
            return f;
        }
        static double KMnaM()                           
        {
            double km, m;
            m = double.Parse(Console.ReadLine());
            km = m / 1.609344D;
            return km;
        }
        static double MnaKM()                           
        {
            double km, m;
            km = double.Parse(Console.ReadLine());
            m = km * 1.609344D;
            return m;
        }
        
        static double CelnaFah()                          
        {
            double Fah, Cel;
            Fah = double.Parse(Console.ReadLine());
            Cel = 5D / 9 * (Fah - 32);
            return Cel;
        }
        static double FahnaCel()                            
        {
            double Fah, Cel;
            Cel = double.Parse(Console.ReadLine());
            Fah = 9D / 5 * Cel + 32;
            return Fah;
        }
        static void Main(string[] args)
        {
            while (true)                                   
            {
                Console.WriteLine("\nJakie jednostki konwertujemy?\n");    
                Console.WriteLine("1. kilogramy na funt?");
                Console.WriteLine("2. Funty na kilogramy?");
                Console.WriteLine("3. kilometry na mile?");
                Console.WriteLine("4. Mile na kilometry?");
                Console.WriteLine("5. Fahrenhaity na Celcjusze");
                Console.WriteLine("6. Celecjusze na Fahrenhaity?");
                Console.WriteLine("0. koniec");

                switch (Console.ReadLine())                 
                {
                    case "1":
                        Console.WriteLine("Podaj kg");
                        double wynik5 = kilnafun();
                        Console.WriteLine("to " + wynik5 + " funtow");
                        break;
                    case "2":
                        Console.WriteLine("Podaj funty");
                        double wynik6 = funnakil();
                        Console.WriteLine("to " + wynik6 + " kilogramow");
                        break;
                    
                    case "3":
                        Console.WriteLine("Podaj km");
                        double wynik3 = KMnaM();
                        Console.WriteLine("to " + wynik3 + " mil");
                        break;
                    case "4":
                        Console.WriteLine("Podaj mile");
                        double wynik4 = MnaKM();
                        Console.WriteLine("to " + wynik4 + " kilometrow");
                        break;
                    case "5":                               
                        Console.WriteLine("Podaj farenhaity");
                        double wynik1 = CelnaFah();              
                        Console.WriteLine("to " + wynik1 + " Celcjuszy");   
                        break;
                    case "6":
                        Console.WriteLine("Podaj Cele");
                        double wynik2 = FahnaCel();
                        Console.WriteLine("to " + wynik2 + " Fahrenhatiow");
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