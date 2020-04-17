using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4Iwan
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertUsingDataEF();    
            //DisplayDataUsingADONET();
            DisplayDataUsingEF();
            Console.Read();
        }


        public static void DisplayDataUsingADONET()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CompanyData;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Employees", connection);
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["FirstName"] + " " + reader["LastName"]);

                }
            }


            //connection.Close();
        }
        public static void DisplayDataUsingEF()
        {
            using (CompanyDataEntities context = new CompanyDataEntities())
            {
                List<Employees> employees = context.Employees
                    .Where(e=>e.LastName.StartsWith("Kow"))
                    .OrderBy(e=>e.FirstName)
                    .Skip(2)
                    .Take(15)
                    .ToList();
                foreach(Employees e in employees)
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
