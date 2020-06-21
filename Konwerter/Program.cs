using System;

namespace Konwerter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz: \n 1 - konwerter temperatur \n 2 - konwerter dlugosci \n 3 - konwerter mas");

            int a;

            a = int.Parse(Console.ReadLine());

            if (a == 1)
            {
                ConvertTemp();
            }
            else if (a == 2)
            {
                ConvertLengths();
            }
            else if (a == 3)
            {
                ConvertMass();
            }

            void ConvertTemp() 
            {
                Console.WriteLine("Wpisz: \n 1 - Konwertuj Celsjusze na Farenheity \n 2 - Konwertuj Farenheity na Celsjusze");

                int b;
                float temp;
                float oldTemp;
                
                b = int.Parse(Console.ReadLine());

                if (b == 1)
                {
                    Console.WriteLine("Wpisz temperature");
                    temp = float.Parse(Console.ReadLine());
                    oldTemp = temp;
                    temp = (temp * 1.8f) + 32f;
                    Console.WriteLine(oldTemp + " Celsjuszy to " + temp + " Farenheitow");
                }
                else if (b == 2)
                {
                    Console.WriteLine("Wpisz temperature");
                    temp = float.Parse(Console.ReadLine());
                    oldTemp = temp;
                    temp = (temp - 32f) / 1.8f;
                    Console.WriteLine(oldTemp + " Farenheitow to " + temp + " Celsjuszy");
                }
            }

            void ConvertLengths() 
            {
                Console.WriteLine("Wpisz: \n 1 - Konwertuj kilometry na mile \n 2 - Konwertuj mile na kilometry");

                int b;
                float temp;
                float oldTemp;

                b = int.Parse(Console.ReadLine());

                if (b == 1)
                {
                    Console.WriteLine("Hello");
                    Console.WriteLine("Wpisz dlugosc");
                    temp = float.Parse(Console.ReadLine());
                    oldTemp = temp;
                    temp = temp * 0.62137f;
                    Console.WriteLine(oldTemp + " kilometrow to " + temp + " mil");
                }
                else if (b == 2)
                {
                    Console.WriteLine("Wpisz dlugosc");
                    temp = float.Parse(Console.ReadLine());
                    oldTemp = temp;
                    temp = temp / 0.62137f;
                    Console.WriteLine(oldTemp + " mil to " + temp + " kilometrow");
                }
            }

            void ConvertMass()
            {
                Console.WriteLine("Wpisz: \n 1 - Konwertuj kilogramy na funty \n 2 - Konwertuj funty na kilogramy");

                int b;
                float temp;
                float oldTemp;

                b = int.Parse(Console.ReadLine());

                if (b == 1)
                {
                    Console.WriteLine("Wpisz mase");
                    temp = float.Parse(Console.ReadLine());
                    oldTemp = temp;
                    temp = temp * 2.2046f;
                    Console.WriteLine(oldTemp + " kilogramow to " + temp + " funtow");
                }
                else if (b == 2)
                {
                    Console.WriteLine("Wpisz dlugosc");
                    Console.WriteLine("Hello");
                    temp = float.Parse(Console.ReadLine());
                    oldTemp = temp;
                    temp = temp / 2.2046f;
                    Console.WriteLine(oldTemp + " funtow to " + temp + " kilogramy");
                }
            }
        }
    }
}
