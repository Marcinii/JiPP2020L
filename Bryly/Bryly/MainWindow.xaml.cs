using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using static MyControls.DataControl;

namespace Bryly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> items = new List<string>();
            items.Add("Sześcian");
            items.Add("Prostopadłościan");
            items.Add("Walec");
            items.Add("Kula");

            dataControl.SetItems(items);
            dataControl.OnClick += DataControl_OnClick;

            resultsGrid.ItemsSource = LadujDane();
        }

        public List<BrylaTable> LadujDane()
        {
            using (BrylyDBEntities context = new BrylyDBEntities())
            {
                List<BrylaTable> lista = context.BrylaTables.ToList();
                return lista;
            }
        }

        public void DodajRekord(BrylaTable bryla)
        {
            using (BrylyDBEntities context = new BrylyDBEntities())
            {
                context.BrylaTables.Add(bryla);
                context.SaveChanges();
            }
        }

        private void DataControl_OnClick(object sender, EventArgs e)
        {
            DataEventArgs data = e as DataEventArgs;
            Compute(data.a, data.b, data.h, data.r, data.item);
        }

        private void Compute(string a, string b, string h, string r, string type)
        {
            IBryla bryla = null;
            switch (type)
            {
                case "Sześcian":
                    bryla = KonwertujSzescian(a);
                    break;
                case "Prostopadłościan":
                    bryla = KonwertujProstopadloscian(a, b, h);
                    break;
                case "Walec":
                    bryla = KonwertujWalec(r, h);
                    break;
                case "Kula":
                    bryla = KonwertujKula(r);
                    break;
                default:
                    MessageBox.Show("Nie wybrano bryły");
                    return;
            }

            

            if(bryla != null)
            {
                double wynik = bryla.Oblicz();
                MessageBox.Show("Objętość wynosi: " + wynik);
                SendToDB(wynik, bryla.InputToString(), bryla.Name());
            }
            else
            {
                MessageBox.Show("Błąd!");
            }
        }

        private void SendToDB(double wynik, string input, string type)
        {
            LoadMask.Visibility = Visibility.Visible;
            Thread t = new Thread(() =>
            {
                Thread.Sleep(5000);
                DodajRekord(new BrylaTable { Input = input, Name = type, Result = wynik.ToString() });
                List<BrylaTable> updates = LadujDane();

                Dispatcher.Invoke(() =>
                {
                    resultsGrid.ItemsSource = updates;
                    LoadMask.Visibility = Visibility.Hidden;
                    MessageBox.Show("Zapisano w bazie");
                });
            });
            t.Start();

        }

        private IBryla KonwertujKula(string r)
        {
            try
            {
                double rr = Double.Parse(r);
                return new Kula(rr);
            }
            catch
            {
                return null;
            }
        }

        private IBryla KonwertujWalec(string r, string h)
        {
            try
            {
                double rr = Double.Parse(r);
                double hh = Double.Parse(h);
                return new Walec(rr, hh);
            }
            catch
            {
                return null;
            }
        }

        private IBryla KonwertujProstopadloscian(string a, string b, string h)
        {
            try
            {
                double aa = Double.Parse(a);
                double bb = Double.Parse(b);
                double hh = Double.Parse(h);
                return new Prostopadloscian(aa, bb, hh);
            }
            catch
            {
                return null;
            }
        }

        private IBryla KonwertujSzescian(string a)
        {
            try
            {
                double aa = Double.Parse(a);
                return new Szescian(aa);
            }
            catch
            {
                return null;
            }
        }
    }
}
