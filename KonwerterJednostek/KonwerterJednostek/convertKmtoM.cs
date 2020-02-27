using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    class convertKmtoM
    {
        public void conKmtoM()
        {
            string input1, input2;
            int kilometr, mila;
            double wyjscie = 0;
            Console.WriteLine("1. Konwertuj kilometry na mile 2. Konwertuj mile na kilometry.");
            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    Console.WriteLine("Wpisz kilometry: ");
                    input1 = Console.ReadLine();
                    kilometr = Convert.ToInt32(input1);
                    wyjscie = kilometr * 0.62137;
                    Console.WriteLine(" w przeliczeniu na mile to " + wyjscie);
                    break;
                case "2":
                    Console.WriteLine("Wpisz mile: ");
                    input2 = Console.ReadLine();
                    mila = Convert.ToInt32(input2);
                    wyjscie = mila / 0.62137;
                    Console.WriteLine(" w przeliczeniu na kilometry to " + wyjscie);
                    break;
                default:
                    break;
            }
        }
    }
}