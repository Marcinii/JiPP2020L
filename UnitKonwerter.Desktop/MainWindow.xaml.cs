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
                new KonwerterTemperatury()
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



                decimal value;
                Decimal.TryParse(textboxInput.Text, out value);
                decimal result = ((IKonwerter)typKonwertera.SelectedItem).Convert(comboboxKonwertujZ.SelectedValue.ToString(), comboboxKonwertujNa.SelectedValue.ToString(), value);

                textblockWynik.Text = result.ToString();
            }


        }


        private void TypKonwertera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboboxKonwertujZ.ItemsSource = ((IKonwerter)typKonwertera.SelectedItem).Units;
            comboboxKonwertujNa.ItemsSource = ((IKonwerter)typKonwertera.SelectedItem).Units;
            comboboxKonwertujZ.SelectedIndex = 0;
            comboboxKonwertujNa.SelectedIndex = 1;
        }
    }
}


