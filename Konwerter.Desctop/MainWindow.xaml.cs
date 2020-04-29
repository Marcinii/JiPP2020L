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
using KonwerterJednostek;
using UnitConverter.Desktop;
using static RateUs.RateControl;

namespace Konwerter.Desctop
{
    public partial class MainWindow : Window
    {
        private List<string> hours = new List<string>();
        private List<string> hours_1 = new List<string>();
        private List<string> minutes = new List<string>();

        private DBManager db = new DBManager();

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 60; i++)
            {
                minutes.Add((i < 10 ? "0" : "") + i.ToString());
            }
            Minuty.ItemsSource = minutes;
            for (int i = 1; i < 25; i++)
            {
                hours_1.Add(i.ToString());
            }
            Godzina.ItemsSource = hours_1;

            List<string> konwertery = new List<string>();
            konwertery.Add("Wszystkie");
            konwertery.Add(nameof(KonwerterOdleglosc));
            konwertery.Add(nameof(KonwerterPredkosc));
            konwertery.Add(nameof(KonwerterTemperatura));
            konwertery.Add(nameof(KonwerterWaga));
            konwertery.Add("KonwerterCzas");
            selectConverter.ItemsSource = konwertery;
            selectConverter.SelectedIndex = 0;

            using (RateMeBaseEntities context = new RateMeBaseEntities())
            {
                RateTable rateTable = context.RateTable.ToList().Last();
                if(rateTable != null)
                {
                    rateControl.RateValue = rateTable.Ocena;
                }
            }

            rateControl.OnRateValue += this.RateControl_OnRateValue;

            relayCommand = new RelayCommand(obj => Konwertuj(), obj => Godzina.SelectedItem != null && Minuty.SelectedItem != null);
           PrzeliczCzas.Command = relayCommand;
        }

        private RelayCommand relayCommand;

        private void Konwertuj()
        {
            if (Convert.ToInt32(Godzina.SelectedItem) < 12)
            {
                CzasWynik.Text = Godzina.SelectedItem + ":" + Minuty.SelectedItem + "AM";
            }
            else
            {
                CzasWynik.Text = (Convert.ToInt32(Godzina.SelectedItem) - 12).ToString() + ":" + Minuty.SelectedItem + "PM";
            }

            SetClock(Convert.ToInt32(Godzina.SelectedItem), Convert.ToInt32(Minuty.SelectedItem));

            db.SaveToDB(new Statistic()
            {
                conversion_data = DateTime.Now,
                converter_type = "KonwerterCzas",
                unit_from = "24h",
                unit_to = "12h",
                insert_data = Godzina.SelectedItem + ":" + Minuty.SelectedItem,
                output_data = CzasWynik.Text
            }, dataGrid);
        }

        private void RateControl_OnRateValue(object sender, RateEventArgs e)
        {
            using (RateMeBaseEntities context = new RateMeBaseEntities())
            {
                context.RateTable.Add(new RateTable()
                {
                    Ocena = e.Value
                });
                context.SaveChanges();
            }
        }

        private void TempCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.TemperaturaTextBox.Text != null && this.TempComboboxZ.SelectedValue != null && this.TempComboboxNa.SelectedValue != null)
            {
                KonwerterTemperatura kt = new KonwerterTemperatura();
                double wartosc = Convert.ToDouble(this.TemperaturaTextBox.Text);
                string temperaturaZ = (string)((ComboBoxItem)((ComboBox)this.TempComboboxZ).SelectedValue).Content;
                string temperaturaNa = (string)((ComboBoxItem)((ComboBox)this.TempComboboxNa).SelectedValue).Content;
                this.TempWynik.Text = Math.Round(kt.Konwertuj(temperaturaZ, temperaturaNa, wartosc), 1, MidpointRounding.ToEven).ToString();

                db.SaveToDB(new Statistic()
                {
                    conversion_data = DateTime.Now,
                    converter_type = nameof(KonwerterTemperatura),
                    unit_from = temperaturaZ,
                    unit_to = temperaturaNa,
                    insert_data = this.TemperaturaTextBox.Text, 
                    output_data = this.TempWynik.Text
                }, dataGrid);
            }
            return;
        }

        private void OdlCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.OdlegloscTextBox.Text != null && this.OdlComboboxZ.SelectedValue != null && this.OdlComboboxNa.SelectedValue != null)
            {
                KonwerterOdleglosc ko = new KonwerterOdleglosc();
                double wartosc = Convert.ToDouble(this.OdlegloscTextBox.Text);
                string odlegloscZ = (string)((ComboBoxItem)((ComboBox)this.OdlComboboxZ).SelectedValue).Content;
                string odlegloscNa = (string)((ComboBoxItem)((ComboBox)this.OdlComboboxNa).SelectedValue).Content;
                this.OdlWynik.Text = Math.Round(ko.Konwertuj(odlegloscZ, odlegloscNa, wartosc), 3, MidpointRounding.ToEven).ToString();

                db.SaveToDB(new Statistic()
                {
                    conversion_data = DateTime.Now,
                    converter_type = nameof(KonwerterOdleglosc),
                    unit_from = odlegloscZ,
                    unit_to = odlegloscNa,
                    insert_data = this.OdlegloscTextBox.Text,
                    output_data = this.OdlWynik.Text
                }, dataGrid);
            }
            return;
        }

        private void PreCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.PredkoscTextBox.Text != null && this.PreComboboxZ.SelectedValue != null && this.PreComboboxNa.SelectedValue != null)
            {
                KonwerterPredkosc kp = new KonwerterPredkosc();
                double wartosc = Convert.ToDouble(this.PredkoscTextBox.Text);
                string PredkoscZ = (string)((ComboBoxItem)((ComboBox)this.PreComboboxZ).SelectedValue).Content;
                string PredkoscNa = (string)((ComboBoxItem)((ComboBox)this.PreComboboxNa).SelectedValue).Content;
                this.PreWynik.Text = Math.Round(kp.Konwertuj(PredkoscZ, PredkoscNa, wartosc), 1, MidpointRounding.ToEven).ToString();

                db.SaveToDB(new Statistic()
                {
                    conversion_data = DateTime.Now,
                    converter_type = nameof(KonwerterPredkosc),
                    unit_from = PredkoscZ,
                    unit_to = PredkoscNa,
                    insert_data = this.PredkoscTextBox.Text,
                    output_data = this.PreWynik.Text
                }, dataGrid);
            }
            return;
        }

        private void WagaCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.WagaTextBox.Text != null && this.WagaComboboxZ.SelectedValue != null && this.WagaComboboxNa.SelectedValue != null)
            {
                KonwerterWaga kw = new KonwerterWaga();
                double wartosc = Convert.ToDouble(this.WagaTextBox.Text);
                string WagaZ = (string)((ComboBoxItem)((ComboBox)this.WagaComboboxZ).SelectedValue).Content;
                string WagaNa = (string)((ComboBoxItem)((ComboBox)this.WagaComboboxNa).SelectedValue).Content;
                this.WagaWynik.Text = Math.Round(kw.Konwertuj(WagaZ, WagaNa, wartosc), 1, MidpointRounding.ToEven).ToString();

                db.SaveToDB(new Statistic()
                {
                    conversion_data = DateTime.Now,
                    converter_type = nameof(KonwerterWaga),
                    unit_from = WagaZ,
                    unit_to = WagaNa,
                    insert_data = this.WagaTextBox.Text,
                    output_data = this.WagaWynik.Text
                }, dataGrid);
            }
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetClock(int hours, int minutes)
        {
            Minutes.Angle = minutes * (360 / 60);
            Hours.Angle = hours * (360 / 12);
        }

        private void ButtonB_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = (Storyboard) Resources["ClockOffStoryboard"];
            storyboard.Begin();
        }

        private void ButtonA_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = (Storyboard)Resources["ClockOnStoryboard"];
            storyboard.Begin();
        }

        private void selectConverter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string konwerter = selectConverter.SelectedItem as string;
            dataGrid.ItemsSource = db.Filter(konwerter, dateFrom.SelectedDate, dateTo.SelectedDate);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string konwerter = selectConverter.SelectedItem as string;
            dataGrid.ItemsSource = db.Filter(konwerter, dateFrom.SelectedDate, dateTo.SelectedDate);
        }

        private void ButtonClickPrev(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.TakePrev();
        }

        private void ButtonClickNext(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.TakeNext();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            topKonwersje.ItemsSource = db.Top3c();
        }
    }
}