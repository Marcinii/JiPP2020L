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
using Konwerter.Logic;
using KonwerterPrzedrostkow;
using System.Threading;

namespace Konwerter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {   
            InitializeComponent();
            combobox_rodzaj_konwersji.ItemsSource = new Lista().GetKonwerters();

            ConvertCommand = new RelayCommand(obj => Konwersja(), obj => combobox_rodzaj_konwersji != null &&  string.IsNullOrEmpty(textbox_in.Text) != true);
            button_ok.Command = ConvertCommand;

            WystawOcene.RateValue = WyswietlDaneEF_Ocena();
        }

        private RelayCommand ConvertCommand;

        private void Konwersja()
        {
            string costam = combobox_rodzaj_konwersji.SelectedItem.ToString();
            double wartosc_wejsciowa = double.Parse(textbox_in.Text);

            double wynik = 0;

            wynik = ((IPrzedrostki)combobox_rodzaj_konwersji.SelectedItem).Konwerter(wartosc_wejsciowa);

            textbox_out.Text = wynik.ToString();
        }

        int WyswietlDaneEF_Ocena()
        {
            using (BazaDanychKonwerterEntities4 context = new BazaDanychKonwerterEntities4())
            {
                List<TabelaKonwerter> Tabela_Ocenas = context.TabelaKonwerter.ToList();
                TabelaKonwerter T = Tabela_Ocenas.Last();
                string tmp = (T.Ocena).ToString();
                bool test = int.TryParse(tmp, out int result);
                if (!test) { result = 0; }
                return result;
            }
        }

        public void WstawDaneEF_Ocena(int Ocenka)
        {
            using (BazaDanychKonwerterEntities4 context = new BazaDanychKonwerterEntities4())
            {

                TabelaKonwerter newTabelaKonwerter = new TabelaKonwerter()
                {

                    Ocena = Ocenka,
                    Data = DateTime.Today

                };

                context.TabelaKonwerter.Add(newTabelaKonwerter);

                context.SaveChanges();
            }
        }

        private void WystawOcene_RateValueChanged(object sender, KontrolkaOcena.RateMe.RateEventArgs e)
        {

            tokenSource = new CancellationTokenSource();
            GridZaslonka.Visibility = Visibility.Visible;

            Task task1 = new Task(() => WstawDaneEF_Ocena(e.Value));
            task1.Start();

            Task task2 = new Task(() => Zapychacz(tokenSource.Token), tokenSource.Token);
            task2.Start();

            Task.WhenAll(task1, task2).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    MessageBox.Show("Coś się posypało");
                }

                Dispatcher.Invoke(() => GridZaslonka.Visibility = Visibility.Hidden);
            });
            
        }


        CancellationTokenSource tokenSource;

        private void Zapychacz(CancellationToken ct)
        {
            Task.Delay(2000).Wait();
        }


    }
}
