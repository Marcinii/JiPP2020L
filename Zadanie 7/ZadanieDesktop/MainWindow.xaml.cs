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
using ZadanieLogic;

namespace ZadanieDesktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combobox.ItemsSource = new CheckShow().GetCheck();
            CheckCommand = new RelayCommand(obj=>przelicz());
            sprawdz.Command = CheckCommand;
            CheckCommand = new RelayCommand(obj => showtask());
            pokaz.Command = CheckCommand;
        }


        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combobox2.ItemsSource = ((IChecker)combobox.SelectedItem).Units;
        }
       
        private RelayCommand CheckCommand;
        

        private void przelicz()
        {
                string inputText = wartosc.Text;
                string inputValue = inputText;
                string result = ((IChecker)combobox.SelectedItem).Check(
                    combobox2.SelectedItem.ToString(),
                    inputValue);
                wynik.Text = result;

            using (DaneEntities context = new DaneEntities())
            {
                Zad7 t = new Zad7()
                {
                    Podzielna = combobox2.Text,
                    Liczba = int.Parse(inputValue),
                    taknie = wynik.Text
                };
                context.Zad7.Add(t);
                context.SaveChanges();
            }
        }
        private void show()
        {
            using (DaneEntities historia2 = new DaneEntities())
            {
                Dispatcher.Invoke(() =>
                { 
                    animacja.Visibility = Visibility.Visible;
                    var dane = historia2.Zad7.AsQueryable();
                    historia.ItemsSource = dane.OrderBy(LP => LP.lp).ToList();
                });
                Task.Delay(4000).Wait();
            }
        }
        private void showtask()
        {
            Task click = new Task(() => show());
            click.Start();
            Task.WhenAll(click).ContinueWith(load =>
            {
                animacja.Visibility = Visibility.Hidden;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
