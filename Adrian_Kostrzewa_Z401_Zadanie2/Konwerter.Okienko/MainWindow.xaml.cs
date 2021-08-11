﻿using System;
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

namespace Konwerter.Okienko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Lista.ItemsSource = new KonwerterSerwis().NazwyK();
        }

        private void Oblicz_Click(object sender, RoutedEventArgs e)
        {
            string a = Wartosc.Text;
            double b = double.Parse(a);
            double wynikowa = ((Ikonwenter)Lista.SelectedItem).Konwer("a","b",b);
            Wynik.Text = wynikowa.ToString();
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
