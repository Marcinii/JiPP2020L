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

        }

        private void ButtonOblicz_Click(object sender, RoutedEventArgs e)
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

                if(typKonwertera.SelectedItem.GetType() == typeof(KonwerterGodzin))
                {
                    DateTime time;
                    DateTime.TryParse(inputtext, out time);

                    godzinowa.RenderTransform = new RotateTransform(30 * time.Hour);
                    minutowa.RenderTransform = new RotateTransform(6 * time.Minute);

                }

            }

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


