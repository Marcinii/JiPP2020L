using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class DataBaseImplementation
    {
        static void StartDataBase()
        {
            DisplayDataUsingADONET();
        }
       

        public static void DisplayDataUsingADONET()
        {
            System.Data.SqlClient.SqlConnection connection = new SqlConnection("Data Source=DESKTOP-NGSM7L3'\'MSSQLSERVER01;Initial Catalog=zadanieC.semestr4.4;Integrated Security=True");

            connection.Open();

            SqlCommand comand = new SqlCommand("SELECT * FROM tab", connection);

            IDataReader reader = comand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["konwerter"] + " " + reader["Data"]);
            }

            connection.Close();
        }

        
    }

}
