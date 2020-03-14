using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        public static void Main()
        {
            double result;
            Console.WriteLine("podaj wartość temperatury");
            string tempVar = Console.ReadLine();
            Console.WriteLine("wartość podana w: \n 1.Celsjusz \n 2.FarenHeit");
            string tempChoice = Console.ReadLine();
            if (tempChoice == "1")
            {
                result = ((9 * Convert.ToDouble(tempVar)) / 5) + 32;
                Console.WriteLine("FarenHeit: " + result + "\n");
            }

            else if (tempChoice == "2")
            {
                result = ((Convert.ToDouble(tempVar) - 32) / 1.8);
                Console.WriteLine("Celsjusz: " + result + "\n");
            }
            
            Console.WriteLine("podaj wartość odleglosci");
            string distanceVar = Console.ReadLine();
            Console.WriteLine("wartość podana w: \n 1.kilometrach \n 2.milach");
            string distanceChoice = Console.ReadLine();
            if (distanceChoice == "1")
            {
                result = Convert.ToDouble(distanceVar) * 0.62137;
                Console.WriteLine("mile: " + result + "\n");
            }

            else if (distanceChoice == "2")
            {
                result = Convert.ToDouble(distanceVar) / 0.62137;
                Console.WriteLine("kilometry: " + result + "\n");
            }

            Console.WriteLine("podaj wartość wagi");
            string weightVar = Console.ReadLine();
            Console.WriteLine("wartość podana w: \n 1.kilogramach \n 2.funtach");
            string weightChoice = Console.ReadLine();
            if (weightChoice == "1")
            {
                result = (Convert.ToDouble(weightVar) * 2.2046);
                Console.WriteLine("funty: " + result + "\n");
            }
            else if (weightChoice == "2")
            {
                result = (Convert.ToDouble(weightVar) / 2.2046);
                Console.WriteLine("kilogramy: " + result + "\n");
            }
            Console.ReadKey();
        }
    }
}