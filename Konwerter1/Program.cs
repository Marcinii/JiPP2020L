using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter1
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("                 To jest konwerter jednostek              ");
            Console.WriteLine("");
            Console.WriteLine("Aby dokonac konwersji wybierz numer: ");
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("1. Stopnie Celcjusza na stopnie Farenheita.");
            Console.WriteLine("2. Stopnie Farenheita na stopnie Celcjusza.");

            Console.WriteLine("");
            Console.WriteLine("3. Kilometry na mile.");
            Console.WriteLine("4. Mile na kilometry.");

            Console.WriteLine("");
            Console.WriteLine("5. Kilogramy na funty.");
            Console.WriteLine("6. Funty na kilogramy.");
            Console.WriteLine("");


            int w = 7;
            
            w = Convert.ToInt32(Console.ReadLine());
            
            switch (w)
            {


                case 1:

                    float temp = 0;
                    float f = 0;

                    Console.WriteLine("Stopnie Celcjusza na stopnie Farenheita");
                    Console.WriteLine("Wpisz temperature w stopniach Celcjusza");
                    Console.ReadLine();

                    f = 32 + 5 / 9 * temp;

                    Console.WriteLine(f);
                    Console.WriteLine("Stopni Farenheita");

                    break;


                case 2:

                    float temp2 = 0;
                    float c = 0;

                    Console.WriteLine("Stopnie Farenheita na stopnie Celcjusza");
                    Console.WriteLine("Wpisz temperature w stopniach Farenheita");
                   // temp2 = Convert.ToSingle(temp2);
                    Console.ReadLine();

                    c =  5 / 9 *(temp2-32);

                    Console.WriteLine(c);
                    Console.WriteLine("Stopni Celcjusza");

                    break;




                case 3:

                    float kil = 0;
                    float mile = 0;

                    Convert.ToSingle(1.609);

                    

                   


                    Console.WriteLine("Kilometry na mile");
                    Console.WriteLine("Wpisz ilosc kilometrow:");
                    Console.ReadLine();

                    mile = (kil * 1609)/1000;


                    Console.WriteLine(mile);
                    Console.WriteLine("Kilometrow");

                    break;

                
                
                
                case 4:
                    
                    float ki = 0;
                    float mil = 0;
                  

                    Console.WriteLine("Mile na kilometry");
                    Console.WriteLine("Wpisz ilosc Mil:");
                    Console.ReadLine();

                    ki = (mil / 1609)/1000;


                    Console.WriteLine(ki);
                    Console.WriteLine("Mil");

                    break;




                case 5:

                    double funt = 0;
                    
                    double kg = 0;

                    Console.WriteLine("Kilogramy na funty");
                    Console.WriteLine("Wpisz ilosc kilogramow:");
                    
                    Console.ReadLine();
                    Convert.ToDouble(funt);
                    Convert.ToDouble(kg);

                    funt = (kg* 2204)/1000;


                    Console.WriteLine(funt);
                    Console.WriteLine("Kilogramow");


                    break;




                case 6:
                    


                    float funty = 0;
                    float kg1 = 0;
                    
                    Console.WriteLine("Funty na kilogramy");
                    Console.WriteLine("Wpisz ilosc funtow:");

                    Console.ReadLine();

                    kg1 = (funty / 2204)/1000;


                    Console.WriteLine(kg1);
                    Console.WriteLine("Kilogramow");

                    break;
                    


            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Koniec");
            Console.ReadLine();
            return (0);
        }

    }
}
