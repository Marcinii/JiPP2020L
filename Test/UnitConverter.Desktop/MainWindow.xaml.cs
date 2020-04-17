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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UnitConverter.Logic;
using System.Data.SqlClient;
using System.Data;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            converterCombobox.ItemsSource = new ConverterService().GetConverters();
        
        }

        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromCombobox.ItemsSource = ((IConverter)converterCombobox.SelectedItem).Units;
            unitToCombobox.ItemsSource = ((IConverter)converterCombobox.SelectedItem).Units;
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            decimal inputValue = decimal.Parse(inputText); // !! TryParse

           
            //clockRotation.Angle = clockRotation.Angle / int.Parse(inputText);

            decimal result = ((IConverter)converterCombobox.SelectedItem).Convert(
                unitFromCombobox.SelectedItem.ToString(),
                unitToCombobox.SelectedItem.ToString(),
                inputValue);

            outputTextBlock.Text = result.ToString();

            if (result == 12)
            {
                clockRotation.Angle = 90;
            }
            else if (result == 3)
            {
                clockRotation.Angle = 180;
            }
            else if (result == 6)
            {
                clockRotation.Angle = 270;
            }
            else if (result == 9)
            {
                clockRotation.Angle = 360;
            }

        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["circleStoryboard"]).Begin();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["circleStoryboard"]).Stop();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
           DisplayDataUsingADONET();

            void DisplayDataUsingADONET()
            {
                string sql = "SELECT * FROM dbo.tab";
                System.Data.SqlClient.SqlConnection connection = new SqlConnection("Data Source=DESKTOP-NGSM7L3\'MSSQLSERVER01;Initial Catalog=zadanieC.semestr4.4;Integrated Security=True");
                {
                    connection.Open();



                    using (SqlCommand cmdSel = new SqlCommand(sql, connection))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmdSel);
                        da.Fill(dt);



                        dataGrid.ItemsSource = dt.DefaultView;



                    }
                    connection.Close();
                }
            }

 
 

            
        }
    
    }
}
/*
 Fill="#FFFF4C4C"

     */
