﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Konwerter_jedn;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        public MainWindow()
        {
            InitializeComponent();
            combobox_konwertery.ItemsSource = new List<IKonwerter_jedn>()
            {
                new cisnienia(),
                new masy(),
                new odleglosci(),
                new temperatury(),
                new zegar(),
            };

            Tarcza_Zegara.Visibility = Visibility.Hidden;
            Wskazowka_Godzinowa.Visibility = Visibility.Hidden;
            Wskazowka_Minutowa.Visibility = Visibility.Hidden;
        }

        private void Combobox_konwertery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combobox_jednostki_z.ItemsSource = ((IKonwerter_jedn)combobox_konwertery.SelectedItem).Jednostki;
            combobox_jednostki_do.ItemsSource = ((IKonwerter_jedn)combobox_konwertery.SelectedItem).Jednostki;

            switch (((IKonwerter_jedn)combobox_konwertery.SelectedItem).Nazwa)
            {
                case "zegar":
                    Tarcza_Zegara.Visibility = Visibility.Visible;
                    Wskazowka_Godzinowa.Visibility = Visibility.Visible;
                    Wskazowka_Minutowa.Visibility = Visibility.Visible;
                    ((Storyboard)FindResource("Zegar_Pokaz")).Begin();
                    break;
                default:
                    ((Storyboard)FindResource("Zegar_Ukryj")).Begin();
                    break;

            }
        }



        private void Button_konwertuj_Click(object sender, RoutedEventArgs e)
        {
            
            if (!double.TryParse(textbox_wpisz_wartosc.Text, out double wpisanaWartoscDouble) &&
                ((IKonwerter_jedn)combobox_konwertery.SelectedItem).Nazwa != "zegar")
            {
                MessageBox.Show("Nieprawidlowa wartosc!");
            }
            else
            {
                string wynik = (
                (IKonwerter_jedn)combobox_konwertery.SelectedItem).naWybr(combobox_jednostki_z.SelectedItem.ToString(),
                combobox_jednostki_do.SelectedItem.ToString(),
                textbox_wpisz_wartosc.Text); 

                textbox_wynik.Text = wynik.ToString();

                
                if (((IKonwerter_jedn)combobox_konwertery.SelectedItem).Nazwa =="zegar")
                {
                    if (DateTime.TryParse(wynik, out DateTime czas_na_zegarze))
                    {
                        MinuteRotation.Angle = (czas_na_zegarze.Minute * 6.0)+90;
                        HourRotation.Angle = (czas_na_zegarze.Hour * 30.0) + (czas_na_zegarze.Minute / 60.0 * 30.0)+90;
                    }
                }
            }
        }
    }
}