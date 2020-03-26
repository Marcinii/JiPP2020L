using KonwerterJednostek.Logic;
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

namespace KonwerterJednostek.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            dziedzinaCombo.ItemsSource = new KonwerterService().GetConverters();
        }

        private void dziedzinaCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            jednFromCombo.ItemsSource = ((IConverter)dziedzinaCombo.SelectedItem).Units;
            jednToCombo.ItemsSource = ((IConverter)dziedzinaCombo.SelectedItem).Units;
            if (((IConverter)dziedzinaCombo.SelectedItem).Name == "Konwerter godziny")
            {
                ((System.Windows.Media.Animation.Storyboard)Resources["ChoosingConverterStoryboard"]).Begin();
            }
        }

        private void jednToCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)    
        {
            string wartoscText = wartoscBox.Text;
            string wartoscTextMinute = MinuteBox.Text;
            decimal wartoscValue = decimal.Parse(wartoscText);
            decimal wartoscMinute = decimal.Parse(wartoscTextMinute);

            string nameConverter = ((IConverter)dziedzinaCombo.SelectedItem).Name;

            if (nameConverter == "Konwerter godziny")
            {
                decimal resultHours = ((IConverter)dziedzinaCombo.SelectedItem).Convert(
                jednFromCombo.SelectedItem.ToString(), jednToCombo.SelectedItem.ToString(), wartoscValue);
                TimeConverter timeConverter = new TimeConverter();
                string time = timeConverter.Inscription(wartoscValue);
                wynikBlock.Text = resultHours.ToString() + " : " + wartoscTextMinute + " " + time;

                Double valueHours = (double)(-90 + resultHours * 30);
                Double valueMinute = (double)(-90 + wartoscMinute * 6);
                clockHourRotation.Angle = valueHours;
                clockMinuteRotation.Angle = valueMinute;
                ((System.Windows.Media.Animation.Storyboard)Resources["NextStoryboard"]).Begin();
            } else
            {
                decimal result = ((IConverter)dziedzinaCombo.SelectedItem).Convert(
                                jednFromCombo.SelectedItem.ToString(), jednToCombo.SelectedItem.ToString(), wartoscValue);

                wynikBlock.Text = result.ToString();
            }
        }
    }
}
