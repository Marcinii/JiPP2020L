using System;

namespace ConsoleApp14
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Co chcesz przekonwertować?");
            Console.WriteLine("1. Stopnie Celcjusza na Farenheita");
            Console.WriteLine("2. Stopnie Farenheita na Celcjusza");
            Console.WriteLine("3. Mile na Kilometry");
            Console.WriteLine("4. Kilometry na mile");
            Console.WriteLine("5. Kilogramy na Funty");
            Console.WriteLine("6. Funty na Kilogramy");

            Console.WriteLine("Wybierz pozycje funkcji konwertera");
            string wybor = Console.ReadLine();

            Console.WriteLine("Podaj wartość");
            public string wartosc = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Console.WriteLine("°C -> °F");
                    c2f(wartosc);
                    break;

                case "2":
                    Console.WriteLine("°F -> °C");
                    f2c(wartosc);
                    break;

                case "3":
                    Console.WriteLine("Mile -> Kilometry");
                    m2k(wartosc);
                    break;

                case "4":
                    Console.WriteLine("Kilometry -> Mile");
                    k2m(wartosc);
                    break;

                case "5":
                    Console.WriteLine("Kilogramy -> Funty");
                    k2f(wartosc);
                    break;

                case "6":
                    Console.WriteLine("Funty -> Kilogramy");
                    f2k(wartosc);
                    break;
            }


            public void c2f(string wartosc)
            {
                double result, value = Convert.ToDouble(wartosc);

                result = (value * 9 / 5) + 32;

                Console.WriteLine(result);
            }

            public void f2c(string wartosc)
            {
                double result, value = Convert.ToDouble(wartosc);

                result = (value - 32) * 5 / 9;

                Console.WriteLine(result);
            }

            public void m2k(string wartosc)
            {
                double result, value = Convert.ToDouble(wartosc);

                result = value * 1.609;

                Console.WriteLine(result);
            }

            public void k2m(string wartosc)
            {
                double result, value = Convert.ToDouble(wartosc);

                result = value / 1.609;

                Console.WriteLine(result);
            }

            public void k2f(string wartosc)
            {
                double result, value = Convert.ToDouble(wartosc);

                result = value * 2.4419;

                Console.WriteLine(result);
            }

            public void f2k(string wartosc)
            {
                double result, value = Convert.ToDouble(wartosc);

                result = value / 2.4419;

                Console.WriteLine(result);
            }
        }
    }
}