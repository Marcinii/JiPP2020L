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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Konwerter_ver01;


namespace Konwerter_ver01.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int nrstrony { get; set; }
        public MainWindow()
        {
            // nrstrony = 0;
            InitializeComponent();
            WybKon.ItemsSource = new ZestawKonw().GetConverter();
            // WybKonBaza.ItemsSource = new ZestawKonw().GetConverter();

            //CykCyk.Angle = 6;
            /* JednZtemp.ItemsSource = new Konwerter_ver01.ConTemp().Jedn;
             JednDotemp.ItemsSource = new Konwerter_ver01.ConTemp().Jedn;
             JednZodl.ItemsSource = new Konwerter_ver01.ConOdl().Jedn;
             JednDoodl.ItemsSource = new Konwerter_ver01.ConOdl().Jedn;
             JednZwag.ItemsSource = new Konwerter_ver01.ConWag().Jedn;
             JednDowag.ItemsSource = new Konwerter_ver01.ConWag().Jedn;
             JednZspe.ItemsSource = new Konwerter_ver01.ConSpe().Jedn;
             JednDospe.ItemsSource = new Konwerter_ver01.ConSpe().Jedn;
             */
        }

        private void WybKon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            JednZ.ItemsSource = ((IConverter)WybKon.SelectedItem).Jedn;
            JednDo.ItemsSource = ((IConverter)WybKon.SelectedItem).Jedn;
        }

        private void Wykonajtemp_Click(object sender, RoutedEventArgs e)
        {
            string InputDane = Dane.Text;
            //double inputValue;
            //double.TryParse(inputDane, out inputValue);
            var Result = ((IConverter)WybKon.SelectedItem).Convert(JednZ.SelectedItem.ToString(), JednDo.SelectedItem.ToString(), InputDane);
            ((Storyboard)Resources["StoryboardJajo"]).Stop();
            Wynik.Text = Result.ToString();
            WstawRekordDoBazy();
        }

        private void WstawRekordDoBazy()
        {

            using (KonwerterDane context = new KonwerterDane())
            {
                KonwerterDa NowyRekord = new KonwerterDa()
                {
                    KonwerterCzas = DateTime.Now,
                    WybKon = ((IConverter)WybKon.SelectedItem).Name.ToString(),
                    JednZ = JednZ.SelectedItem.ToString(),
                    InputDane = Dane.Text,
                    JednDo = JednDo.SelectedItem.ToString(),
                    Result = Wynik.Text
                };

                context.KonwerterDaWy.Add(NowyRekord);
                context.SaveChanges();
            }

        }

        private void WynikButton_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["StoryboardJajo"]).Begin();
            string InputDane = Dane.Text;
            var Result = ((IConverter)WybKon.SelectedItem).Convert(JednZ.SelectedItem.ToString(), JednDo.SelectedItem.ToString(), InputDane);
            WynikGraf.Text = Result.ToString() + " " + JednDo.SelectedItem.ToString();



            if (Convert.ToString(JednZ.SelectedItem) == "24h" && Convert.ToString(JednDo.SelectedItem) == "12h")
            {
                double cyk, pyk;

                double index = Result.IndexOf(":");
                if (index == 1)
                {
                    pyk = Convert.ToDouble(Result.Substring(0, 1));
                    cyk = Convert.ToDouble(Result.Substring(2, 2));
                }
                else
                {
                    pyk = Convert.ToDouble(Result.Substring(0, 2));
                    cyk = Convert.ToDouble(Result.Substring(3, 2));
                }

                cyk *= 6;
                pyk = (pyk + cyk / 360) * 30;

                Pokaz_Zegar(cyk, pyk);
            }
            if (Convert.ToString(JednZ.SelectedItem) == "12h" && Convert.ToString(JednDo.SelectedItem) == "24h")
            {
                double cyk, pyk;

                double index = Result.IndexOf(":");
                if (index == 1)
                {
                    pyk = Convert.ToDouble(Result.Substring(0, 1));
                    cyk = Convert.ToDouble(Result.Substring(2, 2));
                }
                else
                {
                    pyk = Convert.ToDouble(Result.Substring(0, 2));
                    cyk = Convert.ToDouble(Result.Substring(3, 2));
                }

                cyk *= 6;
                pyk = (pyk + cyk / 360) * 30;

                Pokaz_Zegar(cyk, pyk);
            }
        }
        private void Pokaz_Zegar(double cyk, double pyk)
        {
            PykPyk.Angle = pyk;
            CykCyk.Angle = cyk;
        }

        /*private void PokazWynikButton_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["StoryboardKom12"]).Begin();
        }*/

        private void WysWynikiB_Click(object sender, RoutedEventArgs e)
        {

            using (KonwerterDane context = new KonwerterDane())
                {
                    nrstrony = 0;
                    if (DateTime.TryParse(DataOd.Text, out DateTime dataod)) { } else dataod = new DateTime(2020, 04, 01);
                    if (DateTime.TryParse(DataDo.Text, out DateTime datado)) { datado = new DateTime(datado.Year, datado.Month, datado.Day, 23, 59, 59); } else datado = DateTime.Now;

                    List<KonwerterDa> konstat = context.KonwerterDaWy.Where(k => k.WybKon == (((IConverter)WybKon.SelectedItem).Name)).Where(k => k.KonwerterCzas >= dataod).Where(k => k.KonwerterCzas <= datado).OrderBy(k => k.KonwerterCzas).Skip(nrstrony * 8).Take(8).ToList();

                    Statystyki.ItemsSource = konstat;
                }
        }
        

        private void NastepnaStrona_Click(object sender, RoutedEventArgs e)
        {
            nrstrony++;
            using (KonwerterDane context = new KonwerterDane())
            {
                if (DateTime.TryParse(DataOd.Text, out DateTime dataod)) { } else dataod = new DateTime(2020, 04, 01);
                if (DateTime.TryParse(DataDo.Text, out DateTime datado)) { datado = new DateTime(datado.Year, datado.Month, datado.Day, 23, 59, 59); } else datado = DateTime.Now;
                List<KonwerterDa> konstat = context.KonwerterDaWy.Where(k => k.WybKon == (((IConverter)WybKon.SelectedItem).Name)).Where(k => k.KonwerterCzas >= dataod).Where(k => k.KonwerterCzas <= datado).OrderBy(k => k.KonwerterCzas).Skip(nrstrony * 8).Take(8).ToList();

                Statystyki.ItemsSource = konstat;
            }
        }

        private void PoprzedniaStrona_Click(object sender, RoutedEventArgs e)
        {
            using (KonwerterDane context = new KonwerterDane())
            {
                if (nrstrony != 0) nrstrony--;
                if (DateTime.TryParse(DataOd.Text, out DateTime dataod)) { } else dataod = new DateTime(2020, 04, 01);
                if (DateTime.TryParse(DataDo.Text, out DateTime datado)) { datado = new DateTime(datado.Year, datado.Month, datado.Day, 23, 59, 59); } else datado = DateTime.Now;
                List<KonwerterDa> konstat = context.KonwerterDaWy.Where(k => k.WybKon == (((IConverter)WybKon.SelectedItem).Name)).Where(k => k.KonwerterCzas >= dataod).Where(k => k.KonwerterCzas <= datado).OrderBy(k => k.KonwerterCzas).Skip(nrstrony * 8).Take(8).ToList();

                Statystyki.ItemsSource = konstat;
            }
        }

        private void StatystykiNajczesciej_Click(object sender, RoutedEventArgs e)
        {
            using (KonwerterDane context = new KonwerterDane())
            {
                if (DateTime.TryParse(DataOd.Text, out DateTime dataod)) { } else dataod = new DateTime(2020, 04, 01);
                if (DateTime.TryParse(DataDo.Text, out DateTime datado)) { datado = new DateTime(datado.Year, datado.Month, datado.Day, 23, 59, 59); } else datado = DateTime.Now;
                Tabela2.ItemsSource = context.KonwerterDaWy.Where(m => m.WybKon == (((IConverter)WybKon.SelectedItem).Name)).Where(m => m.KonwerterCzas >= dataod).Where(m => m.KonwerterCzas <= datado).GroupBy(m => new { m.WybKon, m.JednZ, m.JednDo }).Select(m => new { m.Key.WybKon, m.Key.JednZ, m.Key.JednDo, Ile_razy = m.Count() }).OrderByDescending(m => m.Ile_razy).Take(3).ToList();
            }
        }
    }
}

