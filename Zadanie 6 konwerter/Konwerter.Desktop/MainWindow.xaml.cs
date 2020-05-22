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
using CustomControl;
using Konwerter.Logic;
using UnitConverter.Desktop;

namespace Konwerter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string init_value;
        double value;
        List<IKonwertery> converters = new List<IKonwertery>()
            {
                new Konwerter_Mas(),
                new Konwerter_Mocy(),
                new Konwerter_Odleglosci(),
                new Konwerter_Temperatur()
            };
        public MainWindow()
        {
            InitializeComponent();
            using (var rate_history = new HISTORIAEntities())
            {
                var rate = rate_history.OCENY.AsQueryable();
                List<OCENY> tmp = rate.OrderByDescending(x => x.IDOcena).Take(1).ToList();
                foreach (var a in tmp)
                {
                    OcenMnie.Rate_value = a.Ocena;
                }
            }

            CzasConvertCommand = new RelayCommand(obj => TimeConvert(), obj => string.IsNullOrEmpty(GodzinaTextBox.Text) != true && string.IsNullOrEmpty(MinutyTextBox.Text) != true);
            TimeConvertButton.Command = CzasConvertCommand;
        }

    public void DodajRecordTemp(string konw, string a, string b, string c)
        {
            using (HISTORIAEntities context = new HISTORIAEntities())
            {
                HISTORY rec = new HISTORY()
                {
                    Data = System.DateTime.Now,
                    Konwerter = konw,
                    Wartość_1 = a,
                    Wartość_2 = b,
                    Wartość_3 = c
                };
                context.HISTORY.Add(rec);
                context.SaveChanges();
            }
        }
        //POCZĄTEK SEKCJI TEMPERATUR//
        private void TempC_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TempTextBox_C.IsKeyboardFocusWithin)
                {
                    init_value = TempTextBox_C.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    TempTextBox_F.Text = converters[3].Konwertuj("C", "F", value).ToString();
                    TempTextBox_K.Text = converters[3].Konwertuj("C", "K", value).ToString();
                }
                DodajRecordTemp("Temperatury", TempTextBox_C.Text + " C", TempTextBox_F.Text + " F", TempTextBox_K.Text + " K");
            }
        }
        private void TempF_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                {
                    init_value = TempTextBox_F.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    TempTextBox_C.Text = converters[3].Konwertuj("F", "C", value).ToString();
                    TempTextBox_K.Text = converters[3].Konwertuj("F", "K", value).ToString();
                }
                DodajRecordTemp("Temperatury", TempTextBox_C.Text + " C", TempTextBox_F.Text + " F", TempTextBox_K.Text + " K");
            }
        }
        private void TempK_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TempTextBox_K.IsKeyboardFocusWithin)
                {
                    init_value = TempTextBox_K.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    TempTextBox_C.Text = converters[3].Konwertuj("K", "C", value).ToString();
                    TempTextBox_F.Text = converters[3].Konwertuj("K", "F", value).ToString();
                }
                DodajRecordTemp("Temperatury", TempTextBox_C.Text + " C", TempTextBox_F.Text + " F", TempTextBox_K.Text + " K");
            }
        }
        //KONIEC SEKCJI TEMPERATUR//

        //POCZĄTEK SEKCJI MAS//
        private void MassKg_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (MasyTextBox_Kg.IsKeyboardFocusWithin)
                {
                    init_value = MasyTextBox_Kg.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    MasyTextBox_F.Text = converters[0].Konwertuj("Kg", "F", value).ToString();
                    MasyTextBox_dkg.Text = converters[0].Konwertuj("Kg", "dkg", value).ToString();
                }
                DodajRecordTemp("Masy", MasyTextBox_Kg.Text + " Kg", MasyTextBox_F.Text + " F", MasyTextBox_dkg.Text + " dkg");
            }
        }
        private void MassF_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (MasyTextBox_F.IsKeyboardFocusWithin)
                {
                    init_value = MasyTextBox_F.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    MasyTextBox_Kg.Text = converters[0].Konwertuj("F", "Kg", value).ToString();
                    MasyTextBox_dkg.Text = converters[0].Konwertuj("F", "dkg", value).ToString();
                }
                DodajRecordTemp("Masy", MasyTextBox_Kg.Text + " Kg", MasyTextBox_F.Text + " F", MasyTextBox_dkg.Text + " dkg");
            }
        }
        private void Massdkg_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (MasyTextBox_dkg.IsKeyboardFocusWithin)
                {
                    init_value = MasyTextBox_dkg.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    MasyTextBox_Kg.Text = converters[0].Konwertuj("dkg", "Kg", value).ToString();
                    MasyTextBox_F.Text = converters[0].Konwertuj("dkg", "F", value).ToString();
                }
                DodajRecordTemp("Masy", MasyTextBox_Kg.Text + " Kg", MasyTextBox_F.Text + " F", MasyTextBox_dkg.Text + " dkg");
            }
        }
        //KONIEC SEKCJI MAS//

        //POCZĄTEK SEKCJI MOCY//
        private void MocW_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (MocTextBox_W.IsKeyboardFocusWithin)
                {
                    init_value = MocTextBox_W.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    MocTextBox_kW.Text = converters[1].Konwertuj("W", "kW", value).ToString();
                    MocTextBox_KM.Text = converters[1].Konwertuj("W", "KM", value).ToString();
                }
                DodajRecordTemp("Moc", MocTextBox_W.Text + " W", MocTextBox_kW.Text + " kW", MocTextBox_KM.Text + " KM");
            }
        }
        private void MockW_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (MocTextBox_kW.IsKeyboardFocusWithin)
                {
                    init_value = MocTextBox_kW.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    MocTextBox_W.Text = converters[1].Konwertuj("kW", "W", value).ToString();
                    MocTextBox_KM.Text = converters[1].Konwertuj("kW", "KM", value).ToString();
                }
                DodajRecordTemp("Moc", MocTextBox_W.Text + " W", MocTextBox_kW.Text + " kW", MocTextBox_KM.Text + " KM");
            }
        }
        private void MocKM_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (MocTextBox_KM.IsKeyboardFocusWithin)
                {
                    init_value = MocTextBox_KM.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    MocTextBox_kW.Text = converters[1].Konwertuj("KM", "kW", value).ToString();
                    MocTextBox_W.Text = converters[1].Konwertuj("KM", "W", value).ToString();
                }
                DodajRecordTemp("Moc", MocTextBox_W.Text + " W", MocTextBox_kW.Text + " kW", MocTextBox_KM.Text + " KM");
            }
        }
        //KONIEC SEKCJI MOCY//

        //POCZĄTEK SEKCJI ODLEGŁOŚCI//
        private void LenghtKm_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (OdlegloscTextBox_Km.IsKeyboardFocusWithin)
                {
                    init_value = OdlegloscTextBox_Km.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    OdlegloscTextBox_Mi.Text = converters[2].Konwertuj("Km", "Mi", value).ToString();
                    OdlegloscTextBox_ft.Text = converters[2].Konwertuj("Km", "ft", value).ToString();
                }
                DodajRecordTemp("Odległości", OdlegloscTextBox_Km.Text + " Km", OdlegloscTextBox_Mi.Text + " Mi", OdlegloscTextBox_ft.Text + " ft");
            }
        }
        private void KenghtMi_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (OdlegloscTextBox_Mi.IsKeyboardFocusWithin)
                {
                    init_value = OdlegloscTextBox_Mi.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    OdlegloscTextBox_Km.Text = converters[2].Konwertuj("Mi", "Km", value).ToString();
                    OdlegloscTextBox_ft.Text = converters[2].Konwertuj("Mi", "ft", value).ToString();
                }
                DodajRecordTemp("Odległości", OdlegloscTextBox_Km.Text + " Km", OdlegloscTextBox_Mi.Text + " Mi", OdlegloscTextBox_ft.Text + " ft");
            }
        }
        private void Lenghtft_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (OdlegloscTextBox_ft.IsKeyboardFocusWithin)
                {
                    init_value = OdlegloscTextBox_ft.Text;
                    if (double.TryParse(init_value, out value) == false)
                    {
                        MessageBox.Show("Podaj poprawną wartość");
                    }
                    OdlegloscTextBox_Km.Text = converters[2].Konwertuj("ft", "Km", value).ToString();
                    OdlegloscTextBox_Mi.Text = converters[2].Konwertuj("ft", "Mi", value).ToString();
                }
                DodajRecordTemp("Odległości", OdlegloscTextBox_Km.Text + " Km", OdlegloscTextBox_Mi.Text + " Mi", OdlegloscTextBox_ft.Text + " ft");
            }
        }
        //KONIEC SEKCJI ODLEGŁOSĆI//   

        //POCZĄTEK SEKCJI CZAS//

        private RelayCommand CzasConvertCommand;

        private void TimeConvert()
        {
            string godziny, minuty;
            int godz = 0, min = 0;
            godziny = GodzinaTextBox.Text;
            int.TryParse(godziny, out godz);
            minuty = MinutyTextBox.Text;
            int.TryParse(minuty, out min);
            if (godz >= 12)
            {
                godz -= 12;
                ResultH12TextBlok.Text = godz.ToString() + ":" + min.ToString() + " PM";
            }
            else
            {
                ResultH12TextBlok.Text = godz.ToString() + ":" + min.ToString() + " AM";
            }
            RotateGodzinowa.Angle = (godz * 30);
            RotateMinutnik.Angle = (min * 6);
            DodajRecordTemp("Czas", GodzinaTextBox.Text+":"+MinutyTextBox.Text+ " 24H", ResultH12TextBlok.Text, " ");
        }
        //KONIEC SEKCJI CZAS//

        public void Cala_historia_uzycia()
        {
            this.Dispatcher.Invoke(() =>
            {
                KwadratLadowania.Visibility = Visibility.Visible;
                KoloLadowania.Visibility = Visibility.Visible;
                var actual = int.Parse(page.Content.ToString());
                using (var history = new HISTORIAEntities())
                {
                    var info = history.HISTORY.AsQueryable();
                    if (DATA_OD.SelectedDate != null)
                    {
                        info = info.Where(x => x.Data >= DATA_OD.SelectedDate);
                    }
                    if (DATA_DO.SelectedDate != null)
                    {
                        info = info.Where(x => x.Data <= DATA_DO.SelectedDate);
                    }
                    HistoriaDataGrid.ItemsSource = info.OrderBy(x => x.IDHistory).Skip(10 * (actual - 1)).Take(10).ToList();
                    
                }
            });
            Task.Delay(10000).Wait();
        }

        private void CalaHistoria_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(() => Cala_historia_uzycia());
            task.Start();
            Task.WhenAll(task).ContinueWith(t =>
            {
                KwadratLadowania.Visibility = Visibility.Hidden;
                KoloLadowania.Visibility = Visibility.Hidden;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void Top5Button_Click(object sender, RoutedEventArgs e)
        {
            using (var dane = new HISTORIAEntities())
            {
                var items = dane.HISTORY.GroupBy(X => new { X.Konwerter, X.Wartość_1, X.Wartość_2, X.Wartość_3 });
                var top5 = items.Select(x => new { ile = x.Count(), x.Key.Konwerter, x.Key.Wartość_1, x.Key.Wartość_2, x.Key.Wartość_3 })
                    .OrderByDescending(x => x.ile)
                    .Take(5);
                HistoriaDataGrid.ItemsSource = top5.ToList();
            }
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            var actual = int.Parse(page.Content.ToString());
            if (actual > 1)
            {
                page.Content = actual - 1;
            }
            Cala_historia_uzycia();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var actual = int.Parse(page.Content.ToString());
            page.Content = actual + 1;
            Cala_historia_uzycia();
        }

        private void OcenMnie_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void OcenMnie_RateValueChanged(object sender, RateEventArgs e)
        {
            using (HISTORIAEntities cont = new HISTORIAEntities())
            {
                OCENY rec = new OCENY()
                {
                    Ocena = e.Value
                };
                cont.OCENY.Add(rec);
                cont.SaveChanges();
            }
        }
    }


}

