using Konwerter;
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

namespace Converter.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IEConverter> Converters = new List<IEConverter>()
            {
                new WeightConverter(),
                new Konwerter.LengthConverter(),
                new TempConverter(),
                new VolumeConverter()

            };
        IEConverter CurrentConverter;
        public MainWindow()
        {

            InitializeComponent();
        }

        private void DocelowaJednostka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DocelowaJednostka1.Items.Clear();

            foreach (IEConverter converter in Converters)
            {
                foreach (string unit in converter.Units)
                {
                    if (unit == DocelowaJednostka.SelectedItem.ToString()) 
                    {
                        CurrentConverter = converter;
                    }
                }
            }

            foreach (string unit in CurrentConverter.Units)
            {
                if (unit != DocelowaJednostka.SelectedItem.ToString())
                {
                    DocelowaJednostka1.Items.Add(unit);
                }
            }
        }

        private void DocelowaJednostka_Initialized(object sender, EventArgs e)
        {         

            foreach (IEConverter converter in Converters)
            {
                foreach (string unit in converter.Units)
                {
                    DocelowaJednostka.Items.Add(unit);
                }
            }
        }

        private void DocelowaJednostka1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DocelowaJednostka.SelectedItem != null && DocelowaJednostka1.SelectedItem != null && Wartosc.Text != null)
            Wynik.Content = CurrentConverter.ConvertUnit(DocelowaJednostka.SelectedItem.ToString(), DocelowaJednostka1.SelectedItem.ToString(),float.Parse(Wartosc.Text));          
        }
    }
}
