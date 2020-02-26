using System;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What will we convert");
            Console.WriteLine("1) Temperature");
            Console.WriteLine("2) Distance");
            Console.WriteLine("3) Weight");
            switch (getInt())
            {
                case 1:
                    Console.WriteLine("1) Celsius to Fahrenheit");
                    Console.WriteLine("2) Fahrenheit to Celsius");
                    switch (getInt())
                    {
                        case 1:
                            Console.WriteLine("How many Celsius?");
                            float celcius = getFloat();
                            Console.WriteLine("It will be this much in Fahrenheit: {0}", ((celcius * 9 / 5) + 32));
                            break;
                        case 2:
                            Console.WriteLine("How many Fahrenheit?");
                            float fahrenheit = getFloat();
                            Console.WriteLine("It will be this much in Celsius: {0}", ((fahrenheit - 32) * 5 / 9));
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("1) Kilometers to Miles");
                    Console.WriteLine("2) Miles to Kilometers");
                    switch (getInt())
                    {
                        case 1:
                            Console.WriteLine("How many Kilometers?");
                            float kilometers = getFloat();
                            Console.WriteLine("It will be this much in Miles: {0}", (kilometers / 1.609));
                            break;
                        case 2:
                            Console.WriteLine("How many Miles?");
                            float miles = getFloat();
                            Console.WriteLine("It will be this much in Kilometers: {0}", (miles * 1.609));
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("1) Kilograms to Pounds");
                    Console.WriteLine("2) Pounds to Kilograms ");
                    switch (getInt())
                    {
                        case 1:
                            Console.WriteLine("How many Kilograms?");
                            float kilograms = getFloat();
                            Console.WriteLine("It will be this much in Pounds: {0}", (kilograms * 2.205));
                            break;
                        case 2:
                            Console.WriteLine("How many Pounds?");
                            float pounds = getFloat();
                            Console.WriteLine("It will be this much in Kilograms: {0}", (pounds / 2.205));
                            break;
                    }
                    break;
            }

        }
        static public int getInt()
        {
            int number = 0;
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("You typed wrong! Good day Sir!");
                Environment.Exit(0);
            }

            return number;
        }
        static public float getFloat()
        {
            float number = 0;
            try
            {
                number = float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("You typed wrong! Good day Sir!");
                Environment.Exit(0);
            }

            return number;
        }
    }
}
