using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1
{
    class Program
    {
        static void Main(string[] args)
        {

            Temperatura temp = new Temperatura();
            Dlugosc dlu = new Dlugosc();
            Waga wag = new Waga();
            Random rnd = new Random();
            while (true)
            {
                Console.WriteLine("1.Celsjusz-Farenhait\n2.Farenhait-Celcjusz\n3.Kilomertr-mila\n4.Mila-Kilometr\n5.Kilogram-funt\n6.Funt-kilogram\n0.Koniec\n");

                int x = Convert.ToInt32(Console.ReadLine());

                switch (x)
                {
                    case 1:

                        Console.Write("Celsjusz=  ");
                        temp.Celsjusz = Convert.ToDouble(Console.ReadLine());
                        temp.Zam1();
                        Console.WriteLine("Farenheit= " + temp.Farenheit + "\n");
                        break;
                    case 2:
                        Console.Write("Farenheit= ");
                        temp.Farenheit = Convert.ToDouble(Console.ReadLine());
                        temp.Zam2();
                        Console.WriteLine("Celsjusz= " + temp.Celsjusz + "\n");
                        break;

                    case 3:
                        Console.Write("Kilometry= ");
                        dlu.Kilometry = Convert.ToDouble(Console.ReadLine());
                        dlu.Zam1();
                        Console.WriteLine("Mile= " + dlu.Mile + "\n");
                        break;

                    case 4:
                        Console.Write("Mile= ");
                        dlu.Mile = Convert.ToDouble(Console.ReadLine());
                        dlu.Zam2();
                        Console.WriteLine("Kilometry= " + dlu.Kilometry + "\n");
                        break;


                    case 5:
                        Console.Write("Kilogram= ");
                        wag.Kilogram = Convert.ToDouble(Console.ReadLine());
                        wag.Zam1();
                        Console.WriteLine("Funt= " + wag.Funt + "\n");
                        break;

                    case 6:
                        Console.Write("Funt=  ");
                        wag.Funt = Convert.ToDouble(Console.ReadLine());
                        wag.Zam2();
                        Console.WriteLine("Kilogram= " + wag.Kilogram + "\n");
                        break;

                    default:
                        return;

                }



            }
        }
    }
}
