using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    class convertKgtoF
    {
        public void conKgtoF()
        {
            string input1, input2;
            int kilogram, funt;
            double wyjscie = 0;
            Console.WriteLine("1. Konwertuj kilogramy na funty 2. Konwertuj funty na kilogramy.");
            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    Console.WriteLine("Wpisz kilogramy: ");
                    input1 = Console.ReadLine();
                    kilogram = Convert.ToInt32(input1);
                    wyjscie = kilogram * 2.2046;
                    Console.WriteLine(" w przeliczeniu na funty to " + wyjscie);
                    break;
                case "2":
                    Console.WriteLine("Wpisz funty: ");
                    input2 = Console.ReadLine();
                    funt = Convert.ToInt32(input2);
                    wyjscie = funt / 2.2046;
                    Console.WriteLine(" w przeliczeniu na kilogramy to " + wyjscie);
                    break;
                default:
                    break;
            }
        }
    }



}
