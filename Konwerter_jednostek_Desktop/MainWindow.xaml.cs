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

namespace Konwerter_jednostek
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IKonwerter> konwertery = new List<IKonwerter>()
            {
                new Temperatura(),
                new Masa(),
                new Objetosc(),
                new Odleglosc()
            };

        public MainWindow()
        {
            InitializeComponent();

            List<string> opcje = new List<string>();
            for (int i = 0; i < konwertery.Count; i++)
                opcje.Add(konwertery[i].Nazwa);

            CBOpcja.ItemsSource = opcje;
        }

        private void CBZ_MouseEnter(object sender, MouseEventArgs e)
        {
            int i = 0;
            while (konwertery[i].Nazwa != CBOpcja.Text)
            i++;

            List<string> opcje = new List<string>();
            for (int j=0; j<konwertery[i].Jednostki.Count;j++)
                opcje.Add(konwertery[i].Jednostki[j]);

            CBZ.ItemsSource = opcje;
        }

        private void CBNa_MouseEnter(object sender, MouseEventArgs e)
        {
            int i = 0;
            while (konwertery[i].Nazwa != CBOpcja.Text)
            i++; 

            List<string> opcje = new List<string>();
            for (int j = 0; j < konwertery[i].Jednostki.Count; j++)
                opcje.Add(konwertery[i].Jednostki[j]);

            CBNa.ItemsSource = opcje;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string WartoscWe = TBoxWartosc.Text;
            double wartosc = double.Parse(WartoscWe);

            int i = 0;
            while (konwertery[i].Nazwa != CBOpcja.Text)
                i++;

            TBlockWynik.Text = (konwertery[i].Konwerter(CBZ.Text, CBNa.Text, wartosc)).ToString("F");
        }
    }
}
