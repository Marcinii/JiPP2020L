using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1
{
    class calc
    {
        public static double operation(string choose, double variable)
        {
            double result;
            switch (choose)
            {
                case "1":
                    result = variable + 275.15;
                    return result;
                    break;
                case "2":
                    result = variable - 275.15;
                    return result;
                    break;
                case "3":
                    result = variable * 0.62;
                    return result;
                    break;
                case "4":
                    result = variable / 0.62;
                    return result;
                case "5":
                    result = variable * 2.20;
                    return result;
                case "6":
                    result = variable / 2.20;
                    return result;
                    break;
                default:
                    return 0;
                    break;
            }
        }
        public static void transfer(string from, string to, string choose)
        {
            Console.WriteLine("Podaj " + from + " :");
            string variable = Console.ReadLine();
            double converted_variable;
            try
            {
                converted_variable = Double.Parse(variable);
            }
            catch (FormatException){
                converted_variable = 0;
                Console.WriteLine($"Nieprawidłowa dana wejsciowa: " + converted_variable);
            }
            double result = operation(choose, converted_variable);
            Console.WriteLine(converted_variable + from + " = " + result + to);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w kalkulatorze jednostek! \n Wybierz, co chcesz przeliczyć:");
            Console.WriteLine("0 - Wyjście " +
                "\n 1 - Ze stopni C na F " +
                "\n 2 - Ze stopni F na C " +
                "\n 3 - Z km na mile " +
                "\n 4 - Z mile ba km" +
                "\n 5 - kg na funty " +
                "\n 6 - Z funty na kg");
            string choose;
            do
            {
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        calc.transfer("C", "F", choose);
                        break;
                    case "2":
                        calc.transfer("F", "C", choose);
                        break;
                    case "3":
                        calc.transfer("KM", "MI", choose);
                        break;
                    case "4":
                        calc.transfer("MI", "KM", choose);
                        break;
                    case "5":
                        calc.transfer("KG", "LB", choose);
                        break;
                    case "6":
                        calc.transfer("LB", "KG", choose);
                        break;
                    default:
                        Console.WriteLine("Wybrano niepoprawny numer, spróbuj jescze raz!");
                        break;
                }
            } while (choose != "0");
        }
    }
}