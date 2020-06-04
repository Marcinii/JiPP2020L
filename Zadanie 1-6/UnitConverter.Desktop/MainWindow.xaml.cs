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
using UnitConverter.Logic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            converterCombobox.ItemsSource = new ConverterService().GetConverters();

            clockRotation.Angle = 0;

            using (DaneEntities4 Rate = new DaneEntities4())
            {
                var dane = Rate.ocena.AsQueryable();
                List<ocena> tmp = dane.OrderByDescending(LP => LP.ID).Take(1).ToList();
                foreach (var a in tmp)
                {
                    RateControl.RateValue = a.ocena1;
                }
            }

            ConvertCommand = new RelayCommand(obj => convert(), obj => unitFromCombobox.SelectedItem != null && unitFromCombobox.SelectedItem != null && string.IsNullOrEmpty(inputTextBox.Text) != true);
            convertButton.Command = ConvertCommand;

            ConvertCommand = new RelayCommand(obj => next(), obj => numerstrony.Content != null);
            next1.Command = ConvertCommand;

            ConvertCommand = new RelayCommand(obj => back(), obj => numerstrony.Content != null);
            back1.Command = ConvertCommand;

            ConvertCommand = new RelayCommand(obj => show());
            show1.Command = ConvertCommand;

            ConvertCommand = new RelayCommand(obj => Naj3());
            button.Command = ConvertCommand;

        }

        private void RateControl_RateValueChanged(object sender, Common.Control.RateEventArgs e)
        {
            using (DaneEntities4 cont = new DaneEntities4())
            {
                ocena rec = new ocena()
                {
                    ocena1 = e.value
                };
                cont.ocena.Add(rec);
                cont.SaveChanges();
            }
        }
        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromCombobox.ItemsSource = ((IConverter)converterCombobox.SelectedItem).Units;
            unitToCombobox.ItemsSource = ((IConverter)converterCombobox.SelectedItem).Units;
        }

        private RelayCommand ConvertCommand;

        private void convert()
        {
            string inputText = inputTextBox.Text;
            string inputValue = inputText; // !! TryParse

            string result = ((IConverter)converterCombobox.SelectedItem).Convert(
                unitFromCombobox.SelectedItem.ToString(),
                unitToCombobox.SelectedItem.ToString(),
                inputValue);

            outputTextBlock.Text = result.ToString();

            using (DaneEntities2 context = new DaneEntities2())
            {
                Tabelaa t = new Tabelaa()
                {

                    Converter = unitFromCombobox.Text,
                    ConverterTo = unitToCombobox.Text,
                    Data = System.DateTime.Now
                };
                context.Tabelaa.Add(t);
                context.SaveChanges();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Text = inputTextBox.Text;
            string inputValue = System.Convert.ToString(Text);

            string result = ((IConverter)converterCombobox.SelectedItem).Convert(
                unitFromCombobox.SelectedItem.ToString(),
                unitToCombobox.SelectedItem.ToString(),
                inputValue);
            outputTextBlock.Text = result.ToString();

            if (Convert.ToString(unitFromCombobox.SelectedItem) == "24h")
            {
                double hour, minutes, h, min;

                int index = result.IndexOf(":");
                if (index == 1)
                {
                    h = Convert.ToDouble(result.Substring(0, 1));
                    min = Convert.ToDouble(result.Substring(2, 2));
                }
                else
                {
                    h = Convert.ToDouble(result.Substring(0, 2));
                    min = Convert.ToDouble(result.Substring(3, 2));
                }
                hour = h * 30 + 90;
                minutes = min * 6 + 90;

                clockRotation2.Angle = hour;
                clockRotation.Angle = minutes;
            }
        }

        public void historia_show()
        {
            
            Dispatcher.Invoke(() =>
            {
                w8.Visibility = Visibility.Visible;
                animation.Visibility = Visibility.Visible;

                var biezaca = int.Parse(numerstrony.Content.ToString());
                using (DaneEntities2 historia = new DaneEntities2())
                {
                    var dane = historia.Tabelaa.AsQueryable();
                    if (od.SelectedDate != null)
                    {
                        dane = dane.Where(DATE => DATE.Data >= od.SelectedDate);
                    }
                    if (dodata.SelectedDate != null)
                    {
                        dane = dane.Where(DATE => DATE.Data <= dodata.SelectedDate);
                    }
                    Stat.ItemsSource = dane.OrderBy(LP => LP.ID).Skip(10 * (biezaca - 1)).Take(10).ToList();
                    
                }
            });
            Task.Delay(5000).Wait();
        }
        
        private void Naj5(object sender, RoutedEventArgs e)
        {
            using (var dane = new DaneEntities2())
            {
                var items = dane.Tabelaa.GroupBy(X => new { X.Converter, X.ConverterTo});
                var top5 = items.Select(x => new { ile = x.Count(), x.Key.Converter, x.Key.ConverterTo})
                    .OrderByDescending(x => x.ile)
                    .Take(5);
                Stat.ItemsSource = top5.ToList();
            }
        }

        private void next()
        {
            var biezaca = int.Parse(numerstrony.Content.ToString());
            numerstrony.Content = biezaca + 1;
            historia_show();
        }

        private void back()
        {
            var biezaca = int.Parse(numerstrony.Content.ToString());
            if (biezaca > 1)
            {
                numerstrony.Content = biezaca - 1;
            }
            historia_show();
        }
        private void show()
        {
            Task click = new Task(() => historia_show());
            click.Start();
            Task.WhenAll(click).ContinueWith(load =>
            {
                w8.Visibility = Visibility.Hidden;
                animation.Visibility = Visibility.Hidden;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void Naj3()
        {
            using (var dane = new DaneEntities2())
            {
                var items = dane.Tabelaa.GroupBy(TOP => new { TOP.Converter, TOP.ConverterTo });
                var top3 = items.Select(top => new { ile = top.Count(), top.Key.Converter, top.Key.ConverterTo })
                    .OrderByDescending(x => x.ile)
                    .Take(3);
                Stat.ItemsSource = top3.ToList();
            }
        }

        private void RateControl_RateValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
