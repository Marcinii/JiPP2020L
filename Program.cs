using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class Convunit
    {
        public static void CnaF()
        {
            Console.Write("Podaj stopnie Celcjusza: ");
            int celsius = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fahrenheit = {0}", celsius * 18 / 10 + 32);
        }
        public static void FnaC()
        {
            Console.Write("Podaj stopnie Ferenheita: ");
            int faren = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Celcjusza = {0}", (faren - 32) / 10 + 32);
        }
        public static void MnaK()
        {
            Console.WriteLine("Podaj mile:");
            double miles = Convert.ToDouble(Console.ReadLine());
            double kilometers = miles * 1.6;
            Console.WriteLine(kilometers + " Kilometrow");
        }
        public static void KnaM()
        {
            Console.WriteLine("Podaj kilometry:");
            double kilometers = Convert.ToDouble(Console.ReadLine());
            double miles = kilometers * 0.62;
            Console.WriteLine(miles + " Mil");
        }
        public static void KnaF()
        {
            Console.WriteLine("Podaj kilogramy:");
            double kilogram = Convert.ToDouble(Console.ReadLine());
            double funt = kilogram * 2.2046;
            Console.WriteLine(funt + " funtów");
        }
        public static void FnaK()
        {
            Console.WriteLine("Podaj funty:");
            double funt = Convert.ToDouble(Console.ReadLine());
            double kilogram = funt *2.2046;
            Console.WriteLine(kilogram + " kilogramów");
        }
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Wybierz konwerter: \n1) Ze stopni Celcjusza na Farenheita \n2) Ze stopni Farenheita na Celcjusza \n3) Mile na kilometry \n4) Kilometry na Mile \n5) Kilogramy na Funty \n6) Funty na Kilogramy");
                Console.WriteLine("_______________________\n");

                int choice;
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    CnaF();
                }
                if (choice == 2)
                {
                    FnaC();
                }
                if (choice == 3)
                {
                    MnaK();
                }
                if (choice == 4)
                {
                    KnaM();
                }
                if (choice == 5)
                {
                    KnaF();
                }
                if (choice == 6)
                {
                    FnaK();
                }
            } while (true);
        }
    }
}
    
