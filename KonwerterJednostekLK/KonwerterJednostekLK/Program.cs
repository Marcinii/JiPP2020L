using System;

namespace KonwerterJednostekLK
{

    class Program
    {
        static void TemperatureConvert()
        {
            Console.WriteLine("Wpisz: \n 1 - Konwertuj Celsjusze na Farenheity \n 2 - Konwertuj Farenheity na Celsjusze");
            int choice;
            float value, convertedValue;
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Wpisz temperature: ");
                value = float.Parse(Console.ReadLine());
                convertedValue = (value * 1.8f) + 32;
                Console.WriteLine(value + " Celsjuszy to " + convertedValue + " Farenheitow");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Wpisz temperature: ");
                value = float.Parse(Console.ReadLine());
                convertedValue = (value - 32) / 1.8f;
                Console.WriteLine(value + " Farenheitow to " + convertedValue + " Celsjuszy");
            }
        }
        static void LenghtConvert()
        {
            Console.WriteLine("Wpisz: \n 1 - Konwertuj Mile na Kilometry \n 2 - Konwertuj Kilometry na Mile");
            int choice;
            float value, convertedValue;
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Wpisz ilosc Mil: ");
                value = float.Parse(Console.ReadLine());
                convertedValue = value * 1.61f;
                Console.WriteLine(value + " Mil to " + convertedValue + " Kilometrow");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Wpisz ilosc Kilometrow: ");
                value = float.Parse(Console.ReadLine());
                convertedValue = value / 1.61f;
                Console.WriteLine(value + " Kilometrow to " + convertedValue + " Mil");
            }
        }
        static void MassConvert()
        {
            Console.WriteLine("Wpisz: \n 1 - Konwertuj Funty na Kilogramy \n 2 - Konwertuj Kilogramy na Funty");
            int choice;
            float value, convertedValue;
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Wpisz liczbe Funtów: ");
                value = float.Parse(Console.ReadLine());
                convertedValue = value / 2.2046f;
                Console.WriteLine(value + " Funtow to " + convertedValue + " Kilogramow");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Wpisz liczbe Kilogramow: ");
                value = float.Parse(Console.ReadLine());
                convertedValue = value*2.2046f;
                Console.WriteLine(value + " Kilogramow to " + convertedValue + " Funtow");
            }
        }
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Wybierz konwerter: \n1) temperatury \n2) dlugosci \n3) masy");
                Console.WriteLine("_______________________\n");

                int choice;
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    TemperatureConvert();
                }
                if(choice == 2)
                {
                    LenghtConvert();
                }
                if (choice == 3)
                {
                    MassConvert();
                }

            } while (true);
           
            
    }
    }
}

            

 