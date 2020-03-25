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
using UnitConverter;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Unit.ItemsSource = new List<string>()
            {
                new TemperatureConverter().Name,
                new LenghtConverter().Name,
                new WeightConverter().Name,
            };
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            List<IConverter> Converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new LenghtConverter(),
                new WeightConverter(),
            };

            decimal InputValue = decimal.Parse(Input.Text);
            string UnitValue = Unit.Text;
            string FromValue = From.Text;
            string ToValue = To.Text;
            string AnswerValue = "";
            for (int i = 0; i < Converters.Count; i++)
            {
                if(Converters[i].Name == UnitValue)
                {
                    AnswerValue = Converters[i].Convert(FromValue, ToValue, InputValue) + "";
                }
            }

            Answer.Text = AnswerValue;
        }

        private void Unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<IConverter> Converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new LenghtConverter(),
                new WeightConverter(),
            };

            List<string> Measurement = new List<string>();

            for (int i = 0; i < Converters.Count; i++)
            {
                if ((string)Unit.SelectedItem == Converters[i].Name)
                {
                    for (int j = 0; j < Converters[i].Units.Count; j++)
                    {
                        Measurement.Add(Converters[i].Units[j]);
                    }
                }
            }
            From.ItemsSource = Measurement;
            To.ItemsSource = Measurement;
        }
    }
}
