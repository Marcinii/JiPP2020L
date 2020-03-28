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
using Konwerter;
using System.Globalization;
using System.Windows.Media.Animation;

namespace Converter.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RotateTransform MinTrans = new RotateTransform();
        public RotateTransform HourTrans = new RotateTransform();
        List<IEConverter> Converters = new List<IEConverter>()
            {
                new WeightConverter(),
                new Konwerter.LengthConverter(),
                new TempConverter(),
                new VolumeConverter(),
                new Converter.Logic.TimeConverter()

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
            if (CurrentConverter.Name == "Czas")
            {
                MinTrans.Angle = (DateTime.ParseExact(Wartosc.Text, "HH:mm", CultureInfo.CurrentCulture).Minute * 6);
                Minute.RenderTransform = MinTrans;
                HourTrans.Angle = (DateTime.ParseExact(Wartosc.Text, "HH:mm", CultureInfo.CurrentCulture).Hour * 30);
                Hour.RenderTransform = HourTrans;
            }

            if (DocelowaJednostka.SelectedItem != null && DocelowaJednostka1.SelectedItem != null && Wartosc.Text != null && CurrentConverter.Name != "Czas")
                Wynik.Content = CurrentConverter.ConvertUnit(DocelowaJednostka.SelectedItem.ToString(), DocelowaJednostka1.SelectedItem.ToString(),float.Parse(Wartosc.Text)); 
            else
                Wynik.Content = CurrentConverter.ConvertUnit(DocelowaJednostka.SelectedItem.ToString(), DocelowaJednostka1.SelectedItem.ToString(), Wartosc.Text);
        }
    }
}
