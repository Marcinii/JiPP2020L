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
using UnitConverter.Desktop;

namespace Konwerter_ver01.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public int nrstrony { get; set; }
        public int stronaostatnia { get; set; }
        public MainWindow()
        {
            nrstrony = 0;
            stronaostatnia = 0;
            InitializeComponent();
            WybKon.ItemsSource = new ZestawKonw().GetConverter();
            //WybKonWyn.ItemsSource = new ZestawKonw().GetConverter();
            // WybKonBaza.ItemsSource = new ZestawKonw().GetConverter();

            rateControl.RateValue = 5;

            //rateControl.RateValueChanged += RateControl_RateValueChanged;

            using (RateDane context = new RateDane())
            {
                List<RateDa> rate = context.RateDaWy.Where(f => f.IdRate == context.RateDaWy.Count()).ToList();
                rateControl.RateValue = rate[0].RateValue;
            }

            Wykonajtemp_ClickCommand = new RelayCommand(obj => Wykonajtemp_Click(), obj => JednZ.SelectedItem != null && JednDo.SelectedItem != null && string.IsNullOrEmpty(Dane.Text) != true);
            Wykonajtemp.Command = Wykonajtemp_ClickCommand;
            WynikButton_ClickCommand = new RelayCommand(obj => WynikButton_Click(), obj => JednZ.SelectedItem != null && JednDo.SelectedItem != null && string.IsNullOrEmpty(Dane.Text) != true);
            WynikButton.Command = WynikButton_ClickCommand;

            WysWynKon_ClickCommand = new RelayCommand(obj => WysWynKon_Click(), obj => WybKon.SelectedItem != null);
            WysWynKon.Command = WysWynKon_ClickCommand;

            PoprzedniaStrona_ClickCommand = new RelayCommand(obj => PoprzedniaStrona_Click(), obj => nrstrony > 0);
            PoprzedniaStrona.Command = PoprzedniaStrona_ClickCommand;
            NastepnaStrona_ClickCommand = new RelayCommand(obj => NastepnaStrona_Click(), obj => nrstrony< stronaostatnia);
            NastepnaStrona.Command = NastepnaStrona_ClickCommand;

            PopWyb_ClickCommand = new RelayCommand(obj => PopWyb_Click(), obj => nrstrony > 0);
            PopWyb.Command = PopWyb_ClickCommand;
            NastWyb_ClickCommand = new RelayCommand(obj => NastWyb_Click(), obj => nrstrony < stronaostatnia);
            NastWyb.Command = NastWyb_ClickCommand;


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

        //private void RateControl_RateValueChanged(object sender, Common.Controls.RateMe.RateEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void WybKon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            JednZ.ItemsSource = ((IConverter)WybKon.SelectedItem).Jedn;
            JednDo.ItemsSource = ((IConverter)WybKon.SelectedItem).Jedn;
        }

        private RelayCommand Wykonajtemp_ClickCommand;
        private void Wykonajtemp_Click()
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
        public static void RateDoBD(int Value)
        {
            using (RateDane context = new RateDane())
            {
                RateDa NowyRekord = new RateDa()
                {
                    RateValue = Value
                };
                context.RateDaWy.Add(NowyRekord);
                context.SaveChanges();
            }
        }
        private RelayCommand WynikButton_ClickCommand;
        private void WynikButton_Click()
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
                    
                    List<KonwerterDa> konstat = context.KonwerterDaWy.Where(k => k.KonwerterCzas >= dataod).Where(k => k.KonwerterCzas <= datado).OrderBy(k => k.KonwerterCzas).Skip(nrstrony * 8).Take(8).ToList();
                    //List<KonwerterDa> konstat2 = context.KonwerterDaWy.Where(k => k.WybKon == (((IConverter)WybKon.SelectedItem).Name)).Where(k => k.KonwerterCzas >= dataod).Where(k => k.KonwerterCzas <= datado).OrderBy(k => k.KonwerterCzas).Skip(nrstrony * 8).Take(8).ToList();

                Statystyki.ItemsSource = konstat;

                stronaostatnia = context.KonwerterDaWy.Where(m => m.KonwerterCzas >= dataod).Where(m => m.KonwerterCzas <= datado).Count();
                if (stronaostatnia % 8 == 0) { stronaostatnia = stronaostatnia / 8 - 1; }
                else stronaostatnia = stronaostatnia / 8;
            }
        }
        private RelayCommand NastepnaStrona_ClickCommand;
        private void NastepnaStrona_Click()
        {
            nrstrony++;
            using (KonwerterDane context = new KonwerterDane())
            {
                if (DateTime.TryParse(DataOd.Text, out DateTime dataod)) { } else dataod = new DateTime(2020, 04, 01);
                if (DateTime.TryParse(DataDo.Text, out DateTime datado)) { datado = new DateTime(datado.Year, datado.Month, datado.Day, 23, 59, 59); } else datado = DateTime.Now;
                List<KonwerterDa> konstat = context.KonwerterDaWy.Where(k => k.KonwerterCzas >= dataod).Where(k => k.KonwerterCzas <= datado).OrderBy(k => k.KonwerterCzas).Skip(nrstrony * 8).Take(8).ToList();

                Statystyki.ItemsSource = konstat;
            }
        }

        private RelayCommand PoprzedniaStrona_ClickCommand;
        private void PoprzedniaStrona_Click()
        {
            using (KonwerterDane context = new KonwerterDane())
            {
                if (nrstrony != 0) nrstrony--;
                if (DateTime.TryParse(DataOd.Text, out DateTime dataod)) { } else dataod = new DateTime(2020, 04, 01);
                if (DateTime.TryParse(DataDo.Text, out DateTime datado)) { datado = new DateTime(datado.Year, datado.Month, datado.Day, 23, 59, 59); } else datado = DateTime.Now;
                List<KonwerterDa> konstat = context.KonwerterDaWy.Where(k => k.KonwerterCzas >= dataod).Where(k => k.KonwerterCzas <= datado).OrderBy(k => k.KonwerterCzas).Skip(nrstrony * 8).Take(8).ToList();

                Statystyki.ItemsSource = konstat;
            }
        }

        private void StatystykiNajczesciej_Click(object sender, RoutedEventArgs e)
        {
            using (KonwerterDane context = new KonwerterDane())
            {
                if (DateTime.TryParse(DataOd.Text, out DateTime dataod)) { } else dataod = new DateTime(2020, 04, 01);
                if (DateTime.TryParse(DataDo.Text, out DateTime datado)) { datado = new DateTime(datado.Year, datado.Month, datado.Day, 23, 59, 59); } else datado = DateTime.Now;
                Tabela2.ItemsSource = context.KonwerterDaWy.Where(m => m.KonwerterCzas >= dataod).Where(m => m.KonwerterCzas <= datado).GroupBy(m => new { m.WybKon, m.JednZ, m.JednDo }).Select(m => new { m.Key.WybKon, m.Key.JednZ, m.Key.JednDo, Ile_razy = m.Count() }).OrderByDescending(m => m.Ile_razy).Take(3).ToList();
            }
        }

        private RelayCommand WysWynKon_ClickCommand;

        private void WysWynKon_Click()
        {
            using (KonwerterDane context = new KonwerterDane())
            {
                nrstrony = 0;
                if (DateTime.TryParse(DataOd.Text, out DateTime dataod)) { } else dataod = new DateTime(2020, 04, 01);
                if (DateTime.TryParse(DataDo.Text, out DateTime datado)) { datado = new DateTime(datado.Year, datado.Month, datado.Day, 23, 59, 59); } else datado = DateTime.Now;

                //List<KonwerterDa> konstat = context.KonwerterDaWy.Where(k => k.KonwerterCzas >= dataod).Where(k => k.KonwerterCzas <= datado).OrderBy(k => k.KonwerterCzas).Skip(nrstrony * 8).Take(8).ToList();
                List<KonwerterDa> konstat = context.KonwerterDaWy.Where(k => k.WybKon == (((IConverter)WybKon.SelectedItem).Name)).Where(k => k.KonwerterCzas >= dataod).Where(k => k.KonwerterCzas <= datado).OrderBy(k => k.KonwerterCzas).Skip(nrstrony * 8).Take(8).ToList();

                Statystyki.ItemsSource = konstat;
                stronaostatnia = context.KonwerterDaWy.Where(m => m.WybKon == (((IConverter)WybKon.SelectedItem).Name)).Where(m => m.KonwerterCzas >= dataod).Where(m => m.KonwerterCzas <= datado).Count();
                if (stronaostatnia % 8 == 0) stronaostatnia = stronaostatnia / 8 - 1;
                else stronaostatnia = stronaostatnia / 8;
            }
        }
        private RelayCommand PopWyb_ClickCommand;
        private void PopWyb_Click()
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
        private RelayCommand NastWyb_ClickCommand;
        private void NastWyb_Click()
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

        private void rateControl_RateValueChanged_1(object sender, Common.Controls.RateMe.RateEventArgs e)
        {
            RateDoBD(e.Value);
        }
    }
}

