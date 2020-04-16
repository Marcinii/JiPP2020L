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
        private Godziny godziny = null;
        private Zegar zegar = null;
        private Baza db = new Baza();
        private string aktualnyKonwerterStr = "";

        public MainWindow()
        {
            InitializeComponent();
            aktualnyKonwerter = new CelsjuszNaFarenheit();
            zegar = new Zegar(GodzinyTransform, MinutyTransform);
            OdswiezDataGrid();

            List<string> rodzajeKonwerterow = new List<string>();
            rodzajeKonwerterow.Add("Wszystkie");
            rodzajeKonwerterow.Add("CelsjuszFarenheit");
            rodzajeKonwerterow.Add("FarenheitCelsjusz");
            rodzajeKonwerterow.Add("MetryKilometry");
            rodzajeKonwerterow.Add("MileKilometry");
            rodzajeKonwerterow.Add("KilometryMile");
            rodzajeKonwerterow.Add("GodzinySekund");
            rodzajeKonwerterow.Add("KilogramyFunty");
            rodzajeKonwerterow.Add("FuntyKilogramy");
            rodzajeKonwerterow.Add("Godziny24na12");
            rodzajeKonwerterow.Add("Godziny12na24");
            konwerteryList.ItemsSource = rodzajeKonwerterow;
            konwerteryList.SelectedIndex = 0;
        }

        private void ZmienKonwerter(object sender, RoutedEventArgs e)
        {
            godziny = null;

            ZegarGrid.Visibility = Visibility.Hidden;
            RadioButton checkBox = (RadioButton) sender;
            aktualnyKonwerterStr = checkBox.Name;
            switch (checkBox.Name)
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
                case "Godziny24na12":
                    godziny = new Godziny("24", "12");
                    ZegarGrid.Visibility = Visibility.Visible;
                    break;
                case "Godziny12na24":
                    godziny = new Godziny("12", "24");
                    ZegarGrid.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(godziny != null)
            {
                godziny.AddInput(Wartosc.Text.ToString());
                zegar.UstawCzas(godziny.ToDateTime());
                db.DodajRekord(new KonwersjeTabela()
                {
                    czas = DateTime.Now,
                    nazwa = aktualnyKonwerterStr,
                    wartosc_a = Wartosc.Text.ToString(),
                    wartosc_b = godziny.GetOutput()
                });
                OdswiezDataGrid();
                MessageBox.Show("Wynik: " + godziny.GetOutput());
            }
            else
            {
                double wartosc = double.Parse(Wartosc.Text.ToString());
                aktualnyKonwerter.DodajWartosc(wartosc);
                db.DodajRekord(new KonwersjeTabela()
                {
                    czas = DateTime.Now,
                    nazwa = aktualnyKonwerterStr,
                    wartosc_a = Wartosc.Text.ToString(),
                    wartosc_b = aktualnyKonwerter.Przelicz().ToString()
                });
                OdswiezDataGrid();
                MessageBox.Show("Wynik: " + aktualnyKonwerter.Przelicz());
            }
            
        }

        private void OdswiezDataGrid()
        {
            dataGrid.ItemsSource = db.LadujDane();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.LadujPofiltrowane(konwerteryList.SelectedItem.ToString(), dateFrom.SelectedDate, dateTo.SelectedDate);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.TopKonwersje();
        }
    }
}
