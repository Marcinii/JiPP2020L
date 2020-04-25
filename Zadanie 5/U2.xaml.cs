using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;


namespace application
{

    public partial class U2 : UserControl
    {
        public U2()
        {
            InitializeComponent();
            getConverterType();
            getUnitType();
            getValueType();
        }

        public void getConverterType()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT DISTINCT TOP 3 ConverterType FROM StatTable";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable("StatTable");
                sda.Fill(dt1);

                string l1 = dt1.Rows[0].Field<string>("ConverterType");
                string l2 = dt1.Rows[1].Field<string>("ConverterType");
                string l3 = dt1.Rows[2].Field<string>("ConverterType");

                topConv1.Content = l1;
                topConv2.Content = l2;
                topConv3.Content = l3;
            }
        }

        public void getUnitType()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT DISTINCT TOP 3 UnitFrom FROM StatTable";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable("StatTable");
                sda.Fill(dt2);

                string u1 = dt2.Rows[0].Field<string>("UnitFrom");
                string u2 = dt2.Rows[1].Field<string>("UnitFrom");
                string u3 = dt2.Rows[2].Field<string>("UnitFrom");

                topU1.Content = u1;
                topU2.Content = u2;
                topU3.Content = u3;
            }
        }

        public void getValueType()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT DISTINCT TOP 3 ValueFrom FROM StatTable";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt3 = new DataTable("StatTable");
                sda.Fill(dt3);

                string v1 = dt3.Rows[0].Field<string>("ValueFrom");
                string v2 = dt3.Rows[1].Field<string>("ValueFrom");
                string v3 = dt3.Rows[2].Field<string>("ValueFrom");

                topV1.Content = v1;
                topV2.Content = v2;
                topV3.Content = v3;
            }
        }
    }
}





