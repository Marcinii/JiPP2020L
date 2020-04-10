using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace KonwerterJednostek.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            

            //Temperatura

            comboboxTempJednZ.ItemsSource = new List<string>()
            {
                "C",
                "F",
                "K"
            };

            comboboxTempJednDo.ItemsSource = new List<string>()
            {
                "C",
                "F",
                "K"
            };

            //Masa
            comboboxMasaJednZ.ItemsSource = new List<string>()
            {
                "f",
                "kg",
                "g"
            };

            comboboxMasaJednDo.ItemsSource = new List<string>()
            {
                "f",
                "kg",
                "g"
            };

            //Dlugosc
            comboboxDlugoscJednZ.ItemsSource = new List<string>()
            {
                "km",
                "m",
                "mm"
            };

            comboboxDlugoscJednDo.ItemsSource = new List<string>()
            {
                "km",
                "m",
                "mm"
            };
            //Litry
            comboboxLitryJednZ.ItemsSource = new List<string>()
            {
                "m^3",
                "l"                
            };

            comboboxLitryJednDo.ItemsSource = new List<string>()
            {
                "m^3",
                "l"
            };
            comboboxFiltrKonwerterWybor.ItemsSource = new List<string>()
            {
                "TEMPERATURA",
                "MASA",
                "DLUGOSC",
                "LITRY"
            };
    }


        private void przyciskCzymJestem_Click(object sender, RoutedEventArgs e)
        {

            labelIntro1.Foreground = Brushes.DarkGoldenrod;
        }

        
        private void przyciskKonwersjaTemp_Click(object sender, RoutedEventArgs e)
        {
            KonwerterTemperatura konw = new KonwerterTemperatura();
            
            string wejscie = textBoxWartoscTemp.Text;
            double wejscieL = Convert.ToDouble(wejscie);
            //MessageBox.Show("Brawo!" + liczba);
            
            double wynikL = konw.Konwertuj(comboboxTempJednZ.Text, comboboxTempJednDo.Text, wejscieL); 
            textblockWynikTemp.Text = Convert.ToString(wynikL);
            DateTime currentTime = DateTime.Now;
            WlozDoBD rekord = new WlozDoBD();
            rekord.WlozRekordy("TEMPERATURA", comboboxTempJednZ.Text, comboboxTempJednDo.Text, wejscieL, wynikL, currentTime);
        }
        private void przyciskKonwersjaMasa_Click(object sender, RoutedEventArgs e)
        {
            KonwerterMas konw = new KonwerterMas();

            string wejscie = textBoxWartoscMasa.Text;
            double wejscieL = Convert.ToDouble(wejscie);

            //MessageBox.Show("Brawo!" + liczba);
            double wynikL = konw.Konwertuj(comboboxMasaJednZ.Text, comboboxMasaJednDo.Text, wejscieL);
            textblockWynikMasa.Text = Convert.ToString(wynikL);

            DateTime currentTime = DateTime.Now;
            WlozDoBD rekord = new WlozDoBD();
            rekord.WlozRekordy("MASA", comboboxMasaJednZ.Text, comboboxMasaJednDo.Text, wejscieL, wynikL, currentTime);
        }

        private void przyciskKonwersjaDlugosc_Click(object sender, RoutedEventArgs e)
        {
            KonwerterDlugosc konw = new KonwerterDlugosc();

            string wejscie = textBoxWartoscDlugosc.Text;
            double wejscieL = Convert.ToDouble(wejscie);
            //MessageBox.Show("Brawo!" + liczba);
            double wynikL = konw.Konwertuj(comboboxDlugoscJednZ.Text, comboboxDlugoscJednDo.Text, wejscieL);
            textblockWynik_Dlugosc.Text = Convert.ToString(wynikL);

            DateTime currentTime = DateTime.Now;
            WlozDoBD rekord = new WlozDoBD();
            rekord.WlozRekordy("DLUGOSC", comboboxDlugoscJednZ.Text, comboboxDlugoscJednDo.Text, wejscieL, wynikL, currentTime);
        }
        private void przyciskKonwersjaLitry_Click(object sender, RoutedEventArgs e)
        {
            KonwerterLitry konw = new KonwerterLitry();

            string wejscie = textBoxWartoscLitry.Text;
            double wejscieL = Convert.ToDouble(wejscie);
            //MessageBox.Show("Brawo!" + liczba);
            double wynikL = konw.Konwertuj(comboboxLitryJednZ.Text, comboboxLitryJednDo.Text, wejscieL);
            textblockWynik_Litry.Text = Convert.ToString(wynikL);

            DateTime currentTime = DateTime.Now;
            WlozDoBD rekord = new WlozDoBD();
            rekord.WlozRekordy("LITRY", comboboxLitryJednZ.Text, comboboxLitryJednDo.Text, wejscieL, wynikL, currentTime);
        }










        private void buttonKonwertujGodzine_Click(object sender, RoutedEventArgs e)
        {
            KonwerterGodzina konw = new KonwerterGodzina();

            string wejscieH = textboxGodzina24.Text;
            int wejscieL = Convert.ToInt32(wejscieH);

            string wejscieMIN = textboxMinuty24.Text;
            double wejscieK = Convert.ToDouble(wejscieMIN);

            if (wejscieL >= 12)
                textboxMinutySUFIKS.Text = "PM";
            else
                textboxMinutySUFIKS.Text = "AM";

            int wynikL = konw.Konwertuj(wejscieL);

            textboxGodzina12.Text = Convert.ToString(wynikL);
            textboxMinuty12.Text = Convert.ToString(wejscieK);


            //mechanizm obracajacy wskazowka godziny
            wskazowka1.Angle = 0;
            wskazowka2.Angle = 0;

            for (int i = 0; i < wynikL; i++)
                wskazowka1.Angle += 30;

            wskazowka1.Angle -= 90;

            //mechanizm obracajacy wskazowka minut
            wskazowka2.Angle = 0;

            for (int i = 0; i < wejscieK; i++)
                wskazowka2.Angle += 6;

            wskazowka2.Angle -= 90;
        }












        private void ComboBoxJednostkaDlugosc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxTempJednZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void comboboxTempJednDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBoxWartoscMasa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxWartoscDlugosc_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboboxDlugoscJednZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxMasaJednZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxDlugoscJednDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxMasaJednDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBoxWartoscLitry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboboxLitryJednZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxLitryJednDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void konwerterWybor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void przyciskWyswietlTabele_Click(object sender, RoutedEventArgs e)
        {
            //WlozDoBD rekordy = new WlozDoBD();
            //rekordy.OdczytajRekordy();
            using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp4;Integrated Security=True"))
            {
                connection.Open();

                string Query = "select FORMAT (DataOperacji, 'dd-MM-yyyy') as DataOperacji,NazwaOperacji,Wartosc,JednostkaZ,JednostkaDo,Wynik from ZADANIE5  ";
                SqlCommand command = new SqlCommand(Query, connection);
                command.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                DataTable dt = new DataTable("ZADANIE5");
                dataAdp.Fill(dt);
                datagridDane.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
            }
        }

        private void comboboxFiltrKonwerterWybor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp4;Integrated Security=True"))
            {
                connection.Open();

                String Query = "Select * FROM [dbo].[ZADANIE5] Where NazwaOperacji=@Fnazwa";

                //SqlParameter parametr = new SqlParameter("@Fnazwa", SqlDbType.VarChar) ;

                SqlCommand command = new SqlCommand(Query, connection);

                //MessageBox.Show(comboboxFiltrKonwerterWybor.SelectedValue.ToString());

                command.Parameters.AddWithValue("@Fnazwa", comboboxFiltrKonwerterWybor.SelectedItem.ToString());

                command.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                DataTable dt = new DataTable("ZADANIE5");
                dataAdp.Fill(dt);
                datagridDane.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
            }

        }

        private void przyciskFiltrujPoDacie_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp4;Integrated Security=True"))
            {
                connection.Open();

                String Query = "Select * FROM [dbo].[ZADANIE5] Where DataOperacji BETWEEN @FOD AND @FDO";

                SqlCommand command = new SqlCommand(Query, connection);
             
                command.Parameters.AddWithValue("@FOD", datepickerOd.SelectedDate);
                command.Parameters.AddWithValue("@FDO", datepickerDo.SelectedDate);

                command.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                DataTable dt = new DataTable("ZADANIE5");
                dataAdp.Fill(dt);
                datagridDane.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
            }
        }

        private void checkboxFiltrujStronicowanie_Click(object sender, RoutedEventArgs e)
        {
            if (checkboxFiltrujStronicowanie.IsChecked!=false)
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp4;Integrated Security=True"))
                {
                    connection.Open();

                    String Query = "Select TOP 20 * FROM [dbo].[ZADANIE5]";

                    SqlCommand command = new SqlCommand(Query, connection);

                    command.ExecuteNonQuery();

                    SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("ZADANIE5");
                    dataAdp.Fill(dt);
                    datagridDane.ItemsSource = dt.DefaultView;
                    dataAdp.Update(dt);
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp4;Integrated Security=True"))
                {
                    connection.Open();

                    String Query = "Select * FROM [dbo].[ZADANIE5]";

                    SqlCommand command = new SqlCommand(Query, connection);

                    command.ExecuteNonQuery();

                    SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("ZADANIE5");
                    dataAdp.Fill(dt);
                    datagridDane.ItemsSource = dt.DefaultView;
                    dataAdp.Update(dt);
                }
            }
        }

        private void przyciskFiltrujNajpopularniejszyKonwerter_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp4;Integrated Security=True"))
            {
                connection.Open();

                String Query = "Select TOP(3) NazwaOperacji,Count(NazwaOperacji) AS IloscWystapien FROM [dbo].[ZADANIE5]  GROUP BY NazwaOperacji ORDER BY IloscWystapien DESC";

                SqlCommand command = new SqlCommand(Query, connection);

                command.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                DataTable dt = new DataTable("ZADANIE5");
                dataAdp.Fill(dt);
                datagridDane.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
            }
        }

        private void przyciskTopKonwersjeWgDat_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp4;Integrated Security=True"))
            {
                connection.Open();

                String Query = "Select TOP(3) NazwaOperacji,Count(NazwaOperacji) AS IloscWystapien FROM [dbo].[ZADANIE5] Where DataOperacji BETWEEN @FOD AND @FDO GROUP BY NazwaOperacji ORDER BY IloscWystapien DESC";

                
                SqlCommand command = new SqlCommand(Query, connection);
                
                command.Parameters.AddWithValue("@FOD", datepickerOd.SelectedDate);
                command.Parameters.AddWithValue("@FDO", datepickerDo.SelectedDate);

                command.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                DataTable dt = new DataTable("ZADANIE5");
                dataAdp.Fill(dt);
                datagridDane.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
            }
        }
    }
}
