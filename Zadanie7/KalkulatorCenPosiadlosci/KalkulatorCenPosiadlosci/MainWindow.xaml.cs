using KalkulatorCenPosiadlosci.Logika;
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
using System.Globalization;
using reusables;
using System.Threading;

namespace KalkulatorCenPosiadlosci
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void Okno_Loaded(object sender, RoutedEventArgs e)
        {
            SpisMiejscowosci.ZaladujBazeDanych();
            Posiadlosc.Items.Add(Program.dom.nazwa);
            Posiadlosc.Items.Add(Program.apartament.nazwa);
            Posiadlosc.Items.Add(Program.mieszkanie.nazwa);

            foreach (Miejscowosc miejscowosc in SpisMiejscowosci.Miejscowosci) 
            {
                Miejscowosc.Items.Add(miejscowosc.nazwa);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() => ObliczCene());
            thread.Start();

        }

        private void Ladowanie() 
        {
            Thread.Sleep(5000);
        }
        private void ObliczCene() 
        {
            Dispatcher.Invoke(() =>
            {
                Ladowanie();
                Miejscowosc ObecnaMiejscowosc = null;
                foreach (Miejscowosc miejscowosc in SpisMiejscowosci.Miejscowosci)
                {
                    if (Miejscowosc.SelectedItem.ToString() == miejscowosc.nazwa)
                        ObecnaMiejscowosc = miejscowosc;
                }

                double WielkoscPomieszczenia = double.Parse(Wielkosc.Text);
                if (Posiadlosc.SelectedItem.ToString() == "Dom")
                {

                    Cena.Content = Program.dom.ObliczCene(WielkoscPomieszczenia, ObecnaMiejscowosc) + " PLN";
                }
                else if (Posiadlosc.SelectedItem.ToString() == "Apartament")
                {
                    Cena.Content = Program.apartament.ObliczCene(WielkoscPomieszczenia, ObecnaMiejscowosc) + " PLN";
                }
                else if (Posiadlosc.SelectedItem.ToString() == "Mieszkanie")
                {
                    Cena.Content = Program.mieszkanie.ObliczCene(WielkoscPomieszczenia, ObecnaMiejscowosc) + " PLN";
                }
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            ReusableControl control = new ReusableControl();
            var host = new Window();
            host.Content = control;
            host.Show();
        }
    }
}
