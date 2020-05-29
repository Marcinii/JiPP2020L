using System;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool pom = true;
            while (pom)
            {
                Console.WriteLine("Naciśnij \n 1 - konwerter temperatur \n 2 - konwerter długości \n 3 - konwerter mas \n 0 - wyjście");
                int a = int.Parse(Console.ReadLine());

                switch (a)
                {
                    case 1:
                        Converter.Temp();
                        break;

                    case 2:
                        Converter.Lengths();
                        break;

                    case 3:
                        Converter.Mass();
                        break;
                    case 0:
                        pom = false;
                        break;
                }
            }
        }
    }

    class Converter
    {
        static public void Temp()
        {
            Console.Clear();
            Console.WriteLine("Wpisz: \n 1 - Konwertuj Celsjusze na Farenheity \n 2 - Konwertuj Farenheity na Celsjusze");

            int b;
            float temp;
            float oldTemp;

            b = int.Parse(Console.ReadLine());

            if (b == 1)
            {
                Console.Clear();
                Console.WriteLine("Wpisz temperature");
                temp = float.Parse(Console.ReadLine());
                oldTemp = temp;
                temp = (temp * 1.8f) + 32f;
                Console.WriteLine(oldTemp + " Celsjuszy to " + temp + " Farenheitow");
                Console.WriteLine("Aby kontynuować naciśnij dowolny klawisz");
                Console.ReadKey();
                Console.Clear();
            }
            else if (b == 2)
            {
                Console.Clear();
                Console.WriteLine("Wpisz temperature");
                temp = float.Parse(Console.ReadLine());
                oldTemp = temp;
                temp = (temp - 32f) / 1.8f;
                Console.WriteLine(oldTemp + " Farenheitow to " + temp + " Celsjuszy");
                Console.WriteLine("Aby kontynuować naciśnij dowolny klawisz");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static public void Lengths()
        {
            Console.Clear();
            Console.WriteLine("Wpisz: \n 1 - Konwertuj kilometry na mile \n 2 - Konwertuj mile na kilometry");

            int b;
            float temp;
            float oldTemp;

            b = int.Parse(Console.ReadLine());

            if (b == 1)
            {
                Console.Clear();
                Console.WriteLine("Wpisz dlugosc");
                temp = float.Parse(Console.ReadLine());
                oldTemp = temp;
                temp = temp * 0.62137f;
                Console.WriteLine(oldTemp + " kilometrow to " + temp + " mil");
                Console.WriteLine("Aby kontynuować naciśnij dowolny klawisz");
                Console.ReadKey();
                Console.Clear();
            }
            else if (b == 2)
            {
                Console.Clear();
                Console.WriteLine("Wpisz dlugosc");
                temp = float.Parse(Console.ReadLine());
                oldTemp = temp;
                temp = temp / 0.62137f;
                Console.WriteLine(oldTemp + " mil to " + temp + " kilometrow");
                Console.WriteLine("Aby kontynuować naciśnij dowolny klawisz");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static public void Mass()
        {
            Console.Clear();
            Console.WriteLine("Wpisz: \n 1 - Konwertuj kilogramy na funty \n 2 - Konwertuj funty na kilogramy");

            int b;
            float temp;
            float oldTemp;

            b = int.Parse(Console.ReadLine());

            if (b == 1)
            {
                Console.Clear();
                Console.WriteLine("Wpisz mase");
                temp = float.Parse(Console.ReadLine());
                oldTemp = temp;
                temp = temp * 2.2046f;
                Console.WriteLine(oldTemp + " kilogramow to " + temp + " funtow");
                Console.WriteLine("Aby kontynuować naciśnij dowolny klawisz");
                Console.ReadKey();
                Console.Clear();
            }
            else if (b == 2)
            {
                Console.Clear();
                Console.WriteLine("Wpisz dlugosc");
                temp = float.Parse(Console.ReadLine());
                oldTemp = temp;
                temp = temp / 2.2046f;
                Console.WriteLine(oldTemp + " funtow to " + temp + " kilogramy");
                Console.WriteLine("Aby kontynuować naciśnij dowolny klawisz");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
