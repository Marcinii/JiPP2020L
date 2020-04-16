using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace application
{

    public partial class U1 : UserControl
    {
        public U1()
        {
            InitializeComponent();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT * FROM StatTable";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("StatTable");
                sda.Fill(dt);
                StatGrid.ItemsSource = dt.DefaultView;
            }
        }

    }
}
