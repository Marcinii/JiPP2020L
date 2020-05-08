using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RareAPP
{
    /// <summary>
    /// Logika interakcji dla klasy RateMyApp.xaml
    /// </summary>
    public partial class RateMyApp : UserControl
    {
        public RateMyApp()
        {
            InitializeComponent();
        }

        private int _RateValue = 0;
        public int RateValue
        {
            get { return _RateValue; }
            set
            {

                if (value < 6 && value > 0){
                    if (_RateValue == value)
                    {
                        UpdateButtons();
                        SaveRateAPP(0.ToString());
                        _RateValue = 0;
                    }
                    else
                    {
                        _RateValue = value;
                        UpdateButton();
                        SaveRateAPP(value.ToString());
                    }
                }
            }
        }
        private void UpdateButton()
        {
            foreach (var b in RateGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.Yellow);
            }
            if (_RateValue > 0)
            {
                for (int i = 0; i < _RateValue; i++)
                {
                    ((Button)RateGrid.Children[i]).Background = new SolidColorBrush(Colors.Blue);
                }
            }
        }
        private void UpdateButtons()
        {
            foreach (var b in RateGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.Yellow);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = RateGrid.Children.IndexOf((Button)sender) + 1;

        }
        private void SaveRateAPP(string a)
        {
            SqlConnection connection = new SqlConnection("Data Source=DCPC\\SQLEXPRESS; Initial Catalog=Baza_Csharp; Integrated Security=SSPI;");
            connection.Open();
            SqlCommand command;
            command = new SqlCommand("update [Baza_Csharp].[dbo].[OcenaAPP] set wartosc ="+a, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    } }
