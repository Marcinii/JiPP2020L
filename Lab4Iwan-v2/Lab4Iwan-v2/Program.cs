using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Iwan_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertUsingDataEF();
            DisplayDataUsingEF();
            Console.Read();
        }

        public static void DisplayDataUsingEF()
        {
            using (CompanyDataEntities context = new CompanyDataEntities())
            {
                List<Employees> employees = context.Employees
                    .Where(e => e.LastName.StartsWith("Kow"))
                    .OrderBy(e => e.FirstName)
                    .Skip(2)
                    .Take(15)
                    .ToList();
                foreach (Employees e in employees)
                {
                    Console.WriteLine(e.Id + ". " + e.FirstName + " " + e.LastName + " " + e.BirthDate + " " + e.isSubcon);
                }
            }
        }
        public static void InsertUsingDataEF()
        {
            using (CompanyDataEntities context = new CompanyDataEntities())
            {
                Employees NewEmployee = new Employees()
                {
                    FirstName = "Karolina",
                    LastName = "Kowalska",
                    //BirthDate=new DateTime(1993,2,4),
                    isSubcon = true
                };

                context.Employees.Add(NewEmployee);
                context.SaveChanges();
            }
        }
    }
}
