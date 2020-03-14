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
using KonwerterLogika;

namespace KonwerterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IKonwerter aktualnyKonwerter;

        public MainWindow()
        {
            InitializeComponent();
            aktualnyKonwerter = new CelsjuszNaFarenheit();
        }

        private void ZmienKonwerter(object sender, RoutedEventArgs e)
        {
            RadioButton checkBox = (RadioButton) sender;
            switch(checkBox.Name)
            {
                case "CelsjuszFarenheit":
                    aktualnyKonwerter = new CelsjuszNaFarenheit();
                    break;
                case "FarenheitCelsjusz":
                    aktualnyKonwerter = new FarenheitNaCelsjusz();
                    break;
                case "MetryKilometry":
                    aktualnyKonwerter = new MetryNaKilometry();
                    break;
                case "MileKilometry":
                    aktualnyKonwerter = new MileNaKilometry();
                    break;
                case "KilometryMile":
                    aktualnyKonwerter = new KilometryNaMile();
                    break;
                case "GodzinySekund":
                    aktualnyKonwerter = new GodzinyNaSekundy();
                    break;
                case "KilogramyFunty":
                    aktualnyKonwerter = new KilogramyNaFunty();
                    break;
                case "FuntyKilogramy":
                    aktualnyKonwerter = new FuntyNaKilogramy();
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double wartosc = double.Parse(Wartosc.Text.ToString());
            aktualnyKonwerter.DodajWartosc(wartosc);
            MessageBox.Show("Wynik: " + aktualnyKonwerter.Przelicz());
        }
    }
}
