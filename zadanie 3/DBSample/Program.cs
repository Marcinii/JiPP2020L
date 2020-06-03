using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DBSample
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
            //DisplayDataUsingADONET();
            DisplayDataUsingEF();
            
        }
        public static void DisplayDataUsingADONET()
        {
            using (
            SqlConnection connection =
                new SqlConnection("Data Source=NT-27.WWSI.EDU.PL, 1601;Initial Catalog=KASETY_412_10;User ID=Z412_10;Password=Toslandek14."))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Select * FROM Z412_10.Employees", connection);

                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["FirstName"] + " " + reader["LastName"]);
                }
            }
        }
        public static void DisplayDataUsingEF()
        {
            using (KASETY_412_10Entities context = new KASETY_412_10Entities())
            {
                List<Employee> employees = context.Employees.ToList();
                foreach (Employee e in employees)
                {
                    Console.WriteLine(e.FirstName + " " + e.LastName +" " + e.IsSubcon + " " +e.BirthDate);
                }

            }

        }
        public static void InsertData()
        { 
            using (KASETY_412_10Entities context = new KASETY_412_10Entities())
            {
                Employee newEmployee = new Employee()
                {
                    FirstName = "Bartek",
                    LastName = "Marciniak",
                    IsSubcon = false,


                };
                context.Employees.Add(newEmployee);

                context.SaveChanges();
            }
                    
        }
    }

}
