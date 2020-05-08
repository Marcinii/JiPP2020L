using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KonwerterJednostek
{
    public class OcenaDB
    {
        public void WlozRekordy(int ocena)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp4;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO ZADANIE6(Ocena) VALUES(@param1)", connection);

                command.Parameters.AddWithValue("@param1", ocena);
                command.ExecuteNonQuery();
            }
        }
    }
}
