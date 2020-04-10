using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KonwerterJednostek
{
    public class WlozDoBD
    {
        
        public void WlozRekordy(string nazwa, string jednostkaZ, string jednostkaDo, double wartosc, double wynik, DateTime currentTime)
        {          
            using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp4;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                connection.Open();

                

                SqlCommand command = new SqlCommand("INSERT INTO ZADANIE5(NazwaOperacji,Wartosc,JednostkaZ,JednostkaDo,Wynik,DataOperacji) VALUES(@param2,@param3,@param4,@param5,@param6,@param7)", connection);

                command.Parameters.AddWithValue("@param2", nazwa);
                command.Parameters.AddWithValue("@param3", wartosc);
                command.Parameters.AddWithValue("@param4", jednostkaZ);
                command.Parameters.AddWithValue("@param5", jednostkaDo);
                command.Parameters.AddWithValue("@param6", wynik);
                command.Parameters.AddWithValue("@param7", currentTime);
                command.ExecuteNonQuery();
            }
        }
    }
}
