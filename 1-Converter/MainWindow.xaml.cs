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

namespace _1_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<string> choices = new List<string> { "Temperature - C to F", "Temperature - F to C",
        "Distance - km to mile", "Distance - mile to km", "Weight - kg to lbs", "Weight - lbs to kg"};

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i<choices.Count; i++)
            {
                Listofchoice.Items.Add(choices[i]);
            }
            Listofchoice.SelectedItem = choices[0];

        }

        private void Convert(object sender, RoutedEventArgs e)
        {
            string choice = Listofchoice.SelectedItem.ToString();
            double newValue = 0;
            if (double.TryParse(Toconvert.Text, out double orgValue)) {
                if (choice == choices[0])
                {
                    newValue = orgValue * 9 / 5 + 32;
                }
                else if (choice == choices[1])
                {
                    newValue = (orgValue - 32) * 5 / 9;
                }
                else if (choice == choices[2])
                {
                    newValue = orgValue * 0.621371192;
                }
                else if (choice == choices[3])
                {
                    newValue = orgValue * 1 / 0.621371192;
                }
                else if (choice == choices[4])
                {
                    newValue = orgValue * 2.20462262;
                }
                else if (choice == choices[5])
                {
                    newValue = orgValue * 1 / 2.20462262;
                }

                Converted.Content = newValue;
            }
            else
            {
                Converted.Content = "NaN";
            }
            
            


            // get choice
            // click
            // pobierz wartosc wprowadzona
            // ustaw odpowiedni tekst w label
        }
    }
}
