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
using UnitKonwerter;

namespace UnitKonwerter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            typKonwertera.ItemsSource = new List<IKonwerter>()
            {
                new KonwerterPredkosci(),
                new KonwerterDlugosci(),
                new KonwerterMasy(),
                new KonwerterTemperatury(),
                new KonwerterGodzin()
            };
            typKonwertera.DisplayMemberPath = "Name";

            WczytajHistorie();






            ocen.RateValueChanged += Ocen_RateValueChanged;


            using (var db = new unitconverterEntities())
            {

                ocen.RateValue = db.ocena.First().ocena1;
            }


            ConvertCommand = new RelayCommand(obj => Convert(), obj => textboxInput.Text.Length > 0 && comboboxKonwertujNa.SelectedItem != null && comboboxKonwertujZ.SelectedItem != null);

            buttonOblicz.Command = ConvertCommand;

        }

        private RelayCommand ConvertCommand;


        private void Ocen_RateValueChanged(object sender, Kontrolki.Rate.RateEventArgs e)
        {
            using (var db = new unitconverterEntities())
            {

                db.ocena.First().ocena1 = ocen.RateValue;
                db.SaveChanges();
            }

        }






        public void Convert()
        {
            if (comboboxKonwertujZ.SelectedValue.ToString() == comboboxKonwertujNa.SelectedValue.ToString())
            {
                textblockWynik.Text = textboxInput.Text;
            }
            else
            {

                string inputtext = textboxInput.Text;
                string value = inputtext;
                string result = ((IKonwerter)typKonwertera.SelectedItem).Convert(comboboxKonwertujZ.SelectedValue.ToString(), comboboxKonwertujNa.SelectedValue.ToString(), value);

                textblockWynik.Text = result.ToString();

                if (typKonwertera.SelectedItem.GetType() == typeof(KonwerterGodzin))
                {
                    DateTime time;
                    DateTime.TryParse(inputtext, out time);

                    godzinowa.RenderTransform = new RotateTransform(30 * time.Hour);
                    minutowa.RenderTransform = new RotateTransform(6 * time.Minute);

                }

            }

            ZapiszHistorie();
        }










        private void ZapiszHistorie()
        {
            ConversionHistory h = new ConversionHistory { Converter = ((IKonwerter)typKonwertera.SelectedItem).Name, Date = DateTime.Now, UnitFrom = ((string)comboboxKonwertujZ.SelectedItem), UnitTo = ((string)comboboxKonwertujNa.SelectedItem), ValueBefore=textboxInput.Text, ValueAfter=textblockWynik.Text };

            Dispatcher.Invoke(() =>
            {
                wczytywanie.Visibility = Visibility.Visible;

            });


            Task t = new Task(() =>
            {
            using (var db = new unitconverterEntities())
            {
                    Task.Delay(5000);
                    db.ConversionHistory.Add(h);

                    db.SaveChanges();

                }


                WczytajHistorie();




            });
            t.Start();


        }



        private void WczytajHistorie()
        {


            Dispatcher.Invoke(() =>
            {
                wczytywanie.Visibility = Visibility.Visible;

            });


            Task t = new Task(() =>
            {
                using (var db = new unitconverterEntities())
                {
                    Task.Delay(5000);


                    var lista = db.ConversionHistory.ToList();

                    Dispatcher.Invoke(() =>
                    {
                        Historia.ItemsSource = lista;
                        wczytywanie.Visibility = Visibility.Hidden;


                    });

                }

            });
            t.Start();


        }

















        private void TypKonwertera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboboxKonwertujZ.ItemsSource = ((IKonwerter)typKonwertera.SelectedItem).Units;
            comboboxKonwertujNa.ItemsSource = ((IKonwerter)typKonwertera.SelectedItem).Units;
            comboboxKonwertujZ.SelectedIndex = 0;
            comboboxKonwertujNa.SelectedIndex = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["Animacja"]).Begin();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             ((Storyboard)Resources["Animacja"]).Stop();
        }
    }
}


