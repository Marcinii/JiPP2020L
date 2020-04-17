using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul4DBSample02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz co robimy:");
            Console.WriteLine("1.Sprawdzamy Wyniki");
            Console.WriteLine("2.Konwersje jednostek");
            Console.Write("Podaj Numer: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Wybierz typ sortowania:");
                    Console.WriteLine("1.Rodzaj Konwersji");
                    Console.WriteLine("2.Zakres Dat");
                    Console.WriteLine("3.Stronicowanie");
                    Console.WriteLine("4.Popularne");
                    Console.Write("Podaj Numer: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                    DisplayDataUsingEF_One();
                            break;
                        case "2":
                            Console.Write("Podaj 1-sza Date (MM/DD/YYYY): ");
                            string dateOne = Console.ReadLine();
                            Console.Write("Podaj 2-ga Date (MM/DD/YYYY): ");
                            string dateTwo = Console.ReadLine();
                            DateTime dateTimeOne = DateTime.Parse(dateOne);
                            DateTime dateTimeTwo = DateTime.Parse(dateTwo);
                            if (dateTimeOne > dateTimeTwo)
                            {
                                DateTime temp = dateTimeTwo;
                                dateTimeTwo = dateTimeOne;
                                dateTimeOne = temp;
                            }
                            DisplayDataUsingEF_Two(dateTimeOne, dateTimeTwo);
                            break;
                        case "3":
                            Console.Write("Podaj Strone: ");
                            int strona = Convert.ToInt32(Console.ReadLine());
                            DisplayDataUsingEF_Thr(strona);
                            break;
                    }
                    break;
                case "2":
            Double liczba = 0;

                    Console.WriteLine("Konwerter Jednostek");
                    Console.WriteLine("Wybierz Konwerter:");
                    Console.WriteLine("1.Temperatura");
                    Console.WriteLine("2.Dlugosc");
                    Console.WriteLine("3.Masa");
                    Console.Write("Podaj Numer: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Wybierz Opcje:");
                            Console.WriteLine("1.Celsjusz->Farenheit");
                            Console.WriteLine("2.Farenheit->Celsjusz");
                            Console.Write("Podaj Numer: ");
                            switch (Console.ReadLine())
                            {

                                case "1":
                                    Console.Write("Podaj Liczbe: ");
                                    liczba = Convert.ToDouble(Console.ReadLine());
                                    Console.Write($"{liczba} Celsjusza = " + (liczba * (9 / 5) + 32) + " Farenheita");
                                    InsertDataUsingEF("Celsjusz->Farenheit", Convert.ToSingle(liczba), Convert.ToSingle(liczba * (9 / 5) + 32));
                                    break;
                                case "2":
                                    Console.Write("Podaj Liczbe: ");
                                    liczba = Convert.ToDouble(Console.ReadLine());
                                    Console.Write($"{liczba} Farenheita = " + ((liczba - 32) / (5 / 9)) + " Celsjusza");
                                    InsertDataUsingEF("Farenheit->Celsjusz", Convert.ToSingle(liczba), Convert.ToSingle((liczba - 32) / (9 / 5)));
                                    break;
                            }
                            break;
                        case "2":
                            Console.WriteLine("Wybierz Opcje:");
                            Console.WriteLine("1.Kilometry->Mile");
                            Console.WriteLine("2.Mile->Kilometry");
                            Console.Write("Podaj Numer: ");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Write("Podaj Liczbe: ");
                                    liczba = Convert.ToDouble(Console.ReadLine());
                                    Console.Write($"{liczba} Kilometry = " + (liczba / 1.609344) + " Mile");
                                    InsertDataUsingEF("Kilometry->Mile", Convert.ToSingle(liczba), Convert.ToSingle(liczba / 1.609344));
                                    break;
                                case "2":
                                    Console.Write("Podaj Liczbe: ");
                                    liczba = Convert.ToDouble(Console.ReadLine());
                                    Console.Write($"{liczba} Mile = " + (liczba * 1.609344) + " Kilometry");
                                    InsertDataUsingEF("Mile->Kilometry", Convert.ToSingle(liczba), Convert.ToSingle(liczba * 1.609344));
                                    break;
                            }
                            break;
                        case "3":
                            Console.WriteLine("Wybierz Opcje:");
                            Console.WriteLine("1.Kilogramy->Funty");
                            Console.WriteLine("2.Funty->Kilogramy");
                            Console.Write("Podaj Numer: ");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Write("Podaj Liczbe: ");
                                    liczba = Convert.ToDouble(Console.ReadLine());
                                    Console.Write($"{liczba} Kilogramy = " + (liczba / 0.45359237) + " Funty");
                                    InsertDataUsingEF("Kilogramy->Funty", Convert.ToSingle(liczba), Convert.ToSingle(liczba / 0.45359237));
                                    break;
                                case "2":
                                    Console.Write("Podaj Liczbe: ");
                                    liczba = Convert.ToDouble(Console.ReadLine());
                                    Console.Write($"{liczba} Funty = " + (liczba * 0.45359237) + " Kilogramy");
                                    InsertDataUsingEF("Funty->Kilogramy", Convert.ToSingle(liczba), Convert.ToSingle(liczba * 0.45359237));
                                    break;
                            }
                            break;
                    }
                    break;
            }
            Console.ReadKey();

        }

        public static void DisplayDataUsingEF_One()
        {
            using (CompanyDataEntities context = new CompanyDataEntities())
            {
                List<Employee> employees = context.Employees
                    .OrderBy(e => e.rodzajKonwersji)
                    .ToList();

                foreach (Employee e in employees)
                {
                    Console.WriteLine(e.Id + " " + e.rodzajKonwersji + " " + e.liczbaDo + " " + e.liczbaPo + " " + e.dataKonwersji.ToString("d"));
                }
            }
        }

        public static void DisplayDataUsingEF_Two(DateTime dateOne, DateTime dateTwo)
        {
            using (CompanyDataEntities context = new CompanyDataEntities())
            {
                List<Employee> employees = context.Employees
                    .ToList();

                foreach (Employee e in employees)
                {
                    if (e.dataKonwersji >= dateOne && e.dataKonwersji <= dateTwo)
                    Console.WriteLine(e.Id + " " + e.rodzajKonwersji + " " + e.liczbaDo + " " + e.liczbaPo + " " + e.dataKonwersji.ToString("d"));
                }
            }
        }

        public static void DisplayDataUsingEF_Thr(int strona)
        {
            using (CompanyDataEntities context = new CompanyDataEntities())
            {
                List<Employee> employees = context.Employees
                    .Skip((strona-1)*20)
                    .Take(20)
                    .ToList();

                foreach (Employee e in employees)
                {
                    Console.WriteLine(e.Id + " " + e.rodzajKonwersji + " " + e.liczbaDo + " " + e.liczbaPo + " " + e.dataKonwersji.ToString("d"));
                }
            }
        }

        public static void InsertDataUsingEF(string nazwa, float liczbaone, float liczbatwo)
        {
            using (CompanyDataEntities context = new CompanyDataEntities())
            {
                Employee newEmployee = new Employee()
                {
                    rodzajKonwersji = nazwa,
                    liczbaDo = liczbaone,
                    liczbaPo = liczbatwo,
                    dataKonwersji = DateTime.Today
                };

                context.Employees.Add(newEmployee);

                context.SaveChanges();
            }
        }
    }
}
