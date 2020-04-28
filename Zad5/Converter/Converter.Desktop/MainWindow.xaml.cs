using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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
using Common.Controls;
using Converter.Logic;

namespace Converter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combo.ItemsSource = new ConverterService().GetNames();

            //ODCZYTUJE OCENE
            rateControl.RateValue = PodajOceneZBazy();
            
            ConvertCommand = new RelayCommand(obj => Convert(),
                                            obj => combo.SelectedItem != null &&
                                            string.IsNullOrEmpty(box.Text) != true);
            button.Command = ConvertCommand;
        }

        public static int PodajOceneZBazy()
        {
            using (DreamsEntities context = new DreamsEntities())
            {
                List<Dreams> dreams = context.Dreams.ToList();
                Dreams d = dreams.LastOrDefault();
                return d.Rate;
            }
        }

        private RelayCommand ConvertCommand;

        private void Convert()
        {
            wynik.Text = ((IConverter)combo.SelectedItem).Konwertuj(box.Text);

            if (((IConverter)combo.SelectedItem).ToString() == "Converter.Logic.zegar")
            {
                int g = int.Parse((wynik.Text).Substring(0, 2));
                int m = int.Parse((wynik.Text).Substring(3, 2));

                big.RenderTransform = new RotateTransform(g * 30);
                small.RenderTransform = new RotateTransform(m * 6);
            }
        }
        private void button_Click(object sender, RoutedEventArgs e) // 
        {
            wynik.Text = ((IConverter)combo.SelectedItem).Konwertuj(box.Text);

            if (((IConverter)combo.SelectedItem).ToString() == "Converter.Logic.zegar")
            {
                int g = int.Parse((wynik.Text).Substring(0, 2));
                int m = int.Parse((wynik.Text).Substring(3, 2));

                big.RenderTransform = new RotateTransform(g * 30);
                small.RenderTransform = new RotateTransform(m * 6);
            };
        }
        private bool _isFirst = true;
        private void rateControl_RateValueChanged(object sender, Common.Controls.RateEventArgs e)
        {
            //ZAPISUJE DO BAZY NOWA WARTOSC OCENY
            int stara;
            using (DreamsEntities context = new DreamsEntities())
            {
                stara = PodajOceneZBazy();
                Dreams newDream = new Dreams()
                {
                    Rate = e.Value
                };
                context.Dreams.Add(newDream);
                context.SaveChanges();
            }
            if (!_isFirst && stara == e.Value)
            {
                rateControl.Odznacz();
                using (DreamsEntities context = new DreamsEntities())
                {
                    List<Dreams> dreams = context.Dreams.ToList();
                    Dreams d = dreams.LastOrDefault();
                    d.Rate = 0;
                    context.SaveChanges();
                }
            }
            _isFirst = false;
        }
    }
}
