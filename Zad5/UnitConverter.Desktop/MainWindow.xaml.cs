using System;
using System.Windows;
using System.Windows.Controls;
using UnitConverter.Logic;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string where = "";
        public static string data_od = "";
        public static string data_do = "";
        public List<string> daty_zrodlo = new List<string>();

        public string ocena_baza;
        private readonly RelayCommand ConvertCommand;
        private readonly RelayCommand FiltrujCommand;

        public void Daty_source()
        {
            SqlConnection connection = new SqlConnection("Data Source=DCPC\\SQLEXPRESS; Initial Catalog=Baza_Csharp; Integrated Security=SSPI;");
            connection.Open();
            SqlCommand command;
                command = new SqlCommand("SELECT distinct Data FROM[Baza_Csharp].[dbo].[Konwerter] order by Data desc ", connection);
                IDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {

                string new_Data = reader["Data"].ToString().Trim();
                    
                    daty_zrodlo.Add(new_Data);
                }
            connection.Close();
        }
        public class Record
        {
            public string Id { get; set; }
            public string Data { get; set; }
            public string Jednostka1 { get; set; }
            public string Jednostka2 { get; set; }
            public string Watrosc1 { get; set; }
            public string Watrosc2 { get; set; }
        }
        public static List<Record> records = new List<Record>();
        public static void Zobacz_logi(string where)
        {
            records.Clear();
            SqlConnection connection = new SqlConnection("Data Source=DCPC\\SQLEXPRESS; Initial Catalog=Baza_Csharp; Integrated Security=SSPI;");
            connection.Open();
            SqlCommand command;
            if (where == "" && data_od == "" && data_do == "")
            {
               command = new SqlCommand("SELECT top 3 [Jednostka_1],[Jednostka_2],COUNT(1) as ile_razy FROM[Baza_Csharp].[dbo].[Konwerter] group by Jednostka_1, Jednostka_2 order by COUNT(1) desc ", connection);
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Record record = new Record
                    {
                        Id = reader["ile_razy"].ToString().Trim(),
                        Jednostka1 = reader["Jednostka_1"].ToString().Trim(),
                        Jednostka2 = reader["Jednostka_2"].ToString().Trim(),
                    };
                    records.Add(record);
                }
            }
            else if (where != "" && data_od == "" && data_do == "")
            {
               command = new SqlCommand("SELECT [Id],[Data],[Jednostka_1],[Jednostka_2],[wartosc_in],[wartosc_out]  FROM[Baza_Csharp].[dbo].[Konwerter] " + where + " ", connection);
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Record record = new Record
                    {
                        Id = reader["Id"].ToString().Trim(),
                        Data = reader["Data"].ToString().Trim(),
                        Jednostka1 = reader["Jednostka_1"].ToString().Trim(),
                        Jednostka2 = reader["Jednostka_2"].ToString().Trim(),
                        Watrosc1 = reader["wartosc_in"].ToString().Trim(),
                        Watrosc2 = reader["wartosc_out"].ToString().Trim()
                    };
                    records.Add(record);
                }
            }
            else
            {
                command = new SqlCommand("SELECT [Id],[Data],[Jednostka_1],[Jednostka_2],[wartosc_in],[wartosc_out]  FROM[Baza_Csharp].[dbo].[Konwerter] " +
                     where + " and Data >='" + data_od.Substring(6, 4) + "-" + data_od.Substring(3, 2) + "-" + data_od.Substring(0, 2) + "' and Data <='" +
                     data_do.Substring(6, 4) + "-" + data_do.Substring(3, 2) + "-" + data_do.Substring(0, 2) + "'", connection);

                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Record record = new Record
                    {
                        Id = reader["Id"].ToString().Trim(),
                        Data = reader["Data"].ToString().Trim(),
                        Jednostka1 = reader["Jednostka_1"].ToString().Trim(),
                        Jednostka2 = reader["Jednostka_2"].ToString().Trim(),
                        Watrosc1 = reader["wartosc_in"].ToString().Trim(),
                        Watrosc2 = reader["wartosc_out"].ToString().Trim()
                    };
                    records.Add(record);
                }
            }
            connection.Close();
        }       
        public void Dodaj_logi()
        {
            SqlConnection connection = new SqlConnection("Data Source=DCPC\\SQLEXPRESS; Initial Catalog=Baza_Csharp; Integrated Security=SSPI;");
            connection.Open();
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.Date.ToString("yyyy-MM-dd");
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Konwerter] ([Data],[Jednostka_1],[Jednostka_2],[wartosc_in],[wartosc_out]) VALUES" +
                " ('" + sqlFormattedDate + "','" + unitFromCombobox.Text.ToString() + "','" + unitToCombobox.Text.ToString() + "','" + inputTextBox.Text.ToString() +
                "','" + outputTextBlock.Text.ToString() + "')", connection); ;
            command.ExecuteNonQuery();
            connection.Close();
            DaneSQL.ItemsSource = null;
            Zobacz_logi(where);
            DaneSQL.ItemsSource = records;
        }
        public MainWindow()
        {
            InitializeComponent();
            ConverterCombobox.ItemsSource = new ConverterService().GetConverters();
            Daty_source();
            Data_do_combo.ItemsSource = daty_zrodlo;
            Data_od_combo.ItemsSource = daty_zrodlo;
            Zobacz_logi(where);       
            DaneSQL.ItemsSource=records;

            RateMe.RateValue = OcenaValue();
            ConvertCommand = new RelayCommand(obj => Convert2(),obj => unitFromCombobox.SelectedItem != null && unitToCombobox.SelectedItem != null && string.IsNullOrEmpty(inputTextBox.Text) != true);
            ConvertButton.Command = ConvertCommand;
            FiltrujCommand = new RelayCommand(obj => Filtuj(), obj => ConverterCombobox.SelectedItem != null);
            Filtruj.Command = FiltrujCommand;

        }
        private int OcenaValue()
        {
            SqlConnection connection = new SqlConnection("Data Source=DCPC\\SQLEXPRESS; Initial Catalog=Baza_Csharp; Integrated Security=SSPI;");
            connection.Open();
            SqlCommand command;
           
                command = new SqlCommand("SELECT top 1 wartosc FROM[Baza_Csharp].[dbo].[OcenaAPP]", connection);
                IDataReader reader = command.ExecuteReader();
                reader.Read();
                ocena_baza = reader["wartosc"].ToString().Trim();
            return Convert.ToInt32(ocena_baza);
        }
        private void ConverterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromCombobox.ItemsSource = ((IConverter)ConverterCombobox.SelectedItem).Units;
            unitToCombobox.ItemsSource = ((IConverter)ConverterCombobox.SelectedItem).Units;
        }
        private void Convert2()
        {   
            string inputText = inputTextBox.Text;
            string inputValue = System.Convert.ToString(inputText);
            string result = ((IConverter)ConverterCombobox.SelectedItem).Convert(
                unitFromCombobox.SelectedItem.ToString(),
                unitToCombobox.SelectedItem.ToString(),
                inputValue);
            outputTextBlock.Text = result.ToString();

            if (Convert.ToString(unitFromCombobox.SelectedItem) == "24" && Convert.ToString(unitToCombobox.SelectedItem) == "12")
            {
                double x, y;
                
                int index = result.IndexOf(":");
                if (index == 1)
                {
                     x = Convert.ToDouble(result.Substring(0, 1));
                     y = Convert.ToDouble(result.Substring(2, 2));
                }
                else
                {
                     x = Convert.ToDouble(result.Substring(0, 2));
                     y = Convert.ToDouble(result.Substring(3, 2));
                }
                
                x = x * 30 + 90;
                y = y * 6 + 90;
                
                Pokaz_Zegar(x,y);
            }
            Dodaj_logi();
        }
        private void Pokaz_Zegar( double min, double hour)
        {
            WskHour.Angle = hour;
            WskMin.Angle = min;
        }
        private void Filtuj()
        {
            if (ConverterCombobox.SelectedIndex.ToString() == "1")
            {
                where = " where Jednostka_1 in ('C','K','F')";
            }
            if (ConverterCombobox.SelectedIndex.ToString() == "0")
            {
                where = " where Jednostka_1 in ('km','mi')";
            }
            if (ConverterCombobox.SelectedIndex.ToString() == "2")
            {
                where = " where Jednostka_1 in ('kg','f','t')";
            }
            if (ConverterCombobox.SelectedIndex.ToString() == "3")
            {
                where = " where Jednostka_1 in ('godz','min','s')";
            }
            if (ConverterCombobox.SelectedIndex.ToString() == "4")
            {
                where = " where Jednostka_1 in ('12','24')";
            }

            if(Data_do_combo.SelectedIndex.ToString() != "-1" && Data_od_combo.SelectedIndex.ToString() !="-1")
            {
                data_do = Data_do_combo.SelectedItem.ToString();
                data_od = Data_od_combo.SelectedItem.ToString();
            }


            DaneSQL.ItemsSource = null;
            Zobacz_logi(where);
            DaneSQL.ItemsSource = records;

        }
    }
}
