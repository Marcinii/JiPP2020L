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
using Przelicznik_Jednostek;
using Przelicznik_Jednostek.Logic;

namespace Przelicznik_Jednostke.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            
            InitializeComponent();
            wyswietl();
            ComboBox_Unit.ItemsSource = new List<string>()
            {
                "Przelicz C na F",
                "Przelicz F na C",
                "Przelicz M na KM",
                "Przelicz KM na M",
                "Przelicz KM na Yd",
                "Przelicz Yd na KM",
                "Przelicz KG na Ibs",
                "Przelicz Ibs na KG",
                "Przelicz KG na Gram",
                "Przelicz Gram na KG",
                "Przelicz Kelvin na C",
                "Przelicz C na Kelvin",
                "Przelicz Dżul na KiloDżul",
                "Przelicz KiloDżul na Dżul",
                "Przelicz godziny z 24h na 12h",
            };
         //   wyswietlRekordy nowe = new wyswietlRekordy();
          //  DataGrid1.ItemsSource = nowe.stat();
            
        }
        public void wyswietl()
        {

            model_danych md = new model_danych();
            var data = from d in md.bazaDane.OrderBy(e => e.id_konwersja) select d;
            var ogranicz = data.Take(10);
            DataGrid1.ItemsSource = ogranicz.ToList();
            
        }
        private void ileNaStrone(int ile, int pomin)
        {
            model_danych md = new model_danych();
            var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja) select d;
            var ogranicz = date.Skip(pomin).Take(ile);
            DataGrid1.ItemsSource = ogranicz.ToList();
        }
        private int krok(int p, int krok)
        {
            if (p == 1)
            {
              
               
                if (krok == 0)
                {
                    ileNaStrone(10,0);
                }
                else
                {
                    for (int i = 0; i < krok; i++)
                    {
                        pomin += 10;
                     ileNaStrone(pomin,10);
                    }

                }
            }if (p == 2)
            {
               

                if (krok == 0)
                {
                    ileNaStrone(10, 0);
                }
                else
                {
                    for (int i = 0; i < krok; i++)
                    {
                        pomin -= 10;
                        ileNaStrone(pomin, 10);
                    }

                }
            }
            return 0;
        }

        private void Button_Convert_Click(object sender, RoutedEventArgs e)
        {
            //Dzialania operacja = new Dzialania();
            if (ComboBox_Unit.SelectedItem == "Przelicz C na F")
            {
                string input = TexBox_Number.Text;
                int q = 2;
                double jednostka = double.Parse(input);
                 
                TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz C na F", jednostka, po);
                
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz F na C")
            {
                string input = TexBox_Number.Text;
                int q = 1;
                double jednostka = double.Parse(input);
                
                TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz F na C", jednostka, po);
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz M na KM")
            {
                string input = TexBox_Number.Text;
                int q = 3;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz M na KM", jednostka, po);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz KM na M")
            {
                string input = TexBox_Number.Text;
                int q = 4;
                double jednostka = double.Parse(input);
                 
                TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz KM na M", jednostka, po);
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz KG na Ibs")
            {
                string input = TexBox_Number.Text;
                int q = 6;
                double jednostka = double.Parse(input);
               
                TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz KG na Ibs", jednostka, po);
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz Ibs na KG")
            {
                string input = TexBox_Number.Text;
                int q = 5;
                double jednostka = double.Parse(input);
               TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz Ibs na KG", jednostka, po);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz KM na Yd")
            {
                string input = TexBox_Number.Text;
                int q = 7;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz KM na Yd", jednostka, po);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz Yd na KM")
            {
                string input = TexBox_Number.Text;
                int q = 8;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz Yd na KM", jednostka, po);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz KG na Gram")
            {
                string input = TexBox_Number.Text;
                int q = 12;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz KG na Gram", jednostka, po);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz Gram na KG")
            {
                string input = TexBox_Number.Text;
                int q = 13;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz Gram na KG", jednostka, po);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz Kelvin na C")
            {
                string input = TexBox_Number.Text;
                int q = 10;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz Kelvin na C", jednostka, po);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz C na Kelvin")
            {
                string input = TexBox_Number.Text;
                int q = 11;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz C na Kelvin", jednostka, po);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz Dżul na KiloDżul")
            {
                string input = TexBox_Number.Text;
                int q = 14;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz Dżul na KiloDżul", jednostka, po);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz KiloDżul na Dżul")
            {
                string input = TexBox_Number.Text;
                int q = 15;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz KiloDżul na Dżul", jednostka, po);

            }

        }

        private void ComboBox_Unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_Unit.SelectedItem == "Przelicz godziny z 24h na 12h")
            {


                TextBlock_Converted.Visibility = System.Windows.Visibility.Hidden;
                Minutnik.Visibility = System.Windows.Visibility.Visible;
                Tarcza.Visibility = System.Windows.Visibility.Visible;
                Godzina.Visibility = System.Windows.Visibility.Visible;
                TexBox_Number.Visibility = System.Windows.Visibility.Hidden;
                Button_Convert.Visibility = System.Windows.Visibility.Hidden;
                Score_Field.Visibility = System.Windows.Visibility.Hidden;
                Set_Clock.Visibility = System.Windows.Visibility.Visible;
                TextBox_GG.Visibility = System.Windows.Visibility.Visible;
                MM.Visibility = System.Windows.Visibility.Visible;
                Button_Clock.Visibility = System.Windows.Visibility.Visible;
                Clock_define.Visibility = System.Windows.Visibility.Visible;
                Converted_Hours.Visibility = System.Windows.Visibility.Visible;
                Separator.Visibility = System.Windows.Visibility.Visible;
                Converted_Minuts.Visibility = System.Windows.Visibility.Visible;
                AM_PM.Visibility = System.Windows.Visibility.Visible;

            }
            else
            {

                TexBox_Number.Visibility = System.Windows.Visibility.Visible;
                Button_Convert.Visibility = System.Windows.Visibility.Visible;
                Score_Field.Visibility = System.Windows.Visibility.Visible;
                Set_Clock.Visibility = System.Windows.Visibility.Hidden;
                TextBox_GG.Visibility = System.Windows.Visibility.Hidden;
                MM.Visibility = System.Windows.Visibility.Hidden;
                Button_Clock.Visibility = System.Windows.Visibility.Hidden;
                Clock_define.Visibility = System.Windows.Visibility.Hidden;
                Converted_Hours.Visibility = System.Windows.Visibility.Hidden;
                Separator.Visibility = System.Windows.Visibility.Hidden;
                Converted_Minuts.Visibility = System.Windows.Visibility.Hidden;
                AM_PM.Visibility = System.Windows.Visibility.Hidden;
                Minutnik.Visibility = System.Windows.Visibility.Hidden;
                Tarcza.Visibility = System.Windows.Visibility.Hidden;
                Godzina.Visibility = System.Windows.Visibility.Hidden;
                TextBlock_Converted.Visibility = System.Windows.Visibility.Visible;


            }
        }
        private void Button_Clock_Click(object sender, RoutedEventArgs e)
        {
            string input = TextBox_GG.Text;
            string input1 = MM.Text;
            int q = 9;
            double godzina = double.Parse(input);
            double minuta = double.Parse(input1);
            if (minuta <= 5 && minuta > 0)
            {
                Minutnik_wskazowka.Angle = 30;
            }
            else if (minuta <= 10 && minuta > 5)
            {
                Minutnik_wskazowka.Angle = 60;
            }
            else if (minuta <= 15 && minuta > 10)
            {
                Minutnik_wskazowka.Angle = 90;
            }
            else if (minuta <= 20 && minuta > 15)
            {
                Minutnik_wskazowka.Angle = 120;
            }
            else if (minuta <= 25 && minuta > 20)
            {
                Minutnik_wskazowka.Angle = 150;
            }
            else if (minuta <= 30 && minuta > 25)
            {
                Minutnik_wskazowka.Angle = 180;
            }
            else if (minuta <= 35 && minuta > 30)
            {
                Minutnik_wskazowka.Angle = 210;
            }
            else if (minuta <= 40 && minuta > 35)
            {
                Minutnik_wskazowka.Angle = 240;
            }
            else if (minuta <= 45 && minuta > 40)
            {
                Minutnik_wskazowka.Angle = 270;
            }
            else if (minuta <= 50 && minuta > 45)
            {
                Minutnik_wskazowka.Angle = 300;
            }
            else if (minuta <= 55 && minuta > 50)
            {
                Minutnik_wskazowka.Angle = 330;
            }
            else
            {
                Minutnik_wskazowka.Angle = 0;
            }
            Converted_Hours.Text = new Dzialania().which_submition(q, godzina);
            Converted_Minuts.Text = MM.Text;
            if (godzina == 1 || godzina == 13)
            {
                Godzina_wskazowka.Angle = 30;
            }
            else if (godzina == 2 || godzina == 14)
            {
                Godzina_wskazowka.Angle = 60;
            }
            else if (godzina == 3 || godzina == 15)
            {
                Godzina_wskazowka.Angle = 90;
            }
            else if (godzina == 4 || godzina == 16)
            {
                Godzina_wskazowka.Angle = 120;
            }
            else if (godzina == 5 || godzina == 17)
            {
                Godzina_wskazowka.Angle = 150;
            }
            else if (godzina == 6 || godzina == 18)
            {
                Godzina_wskazowka.Angle = 180;
            }
            else if (godzina == 7 || godzina == 19)
            {
                Godzina_wskazowka.Angle = 210;
            }
            else if (godzina == 8 || godzina == 20)
            {
                Godzina_wskazowka.Angle = 240;
            }
            else if (godzina == 9 || godzina == 21)
            {
                Godzina_wskazowka.Angle = 270;
            }
            else if (godzina == 10 || godzina == 22)
            {
                Godzina_wskazowka.Angle = 300;
            }
            else if (godzina == 11 || godzina == 23)
            {
                Godzina_wskazowka.Angle = 330;
            }
            else
            {
                Godzina_wskazowka.Angle = 0;
            }

            if (godzina < 13)
            {
                AM_PM.Text = "AM";
            }
            else
            {
                AM_PM.Text = "PM";
            }

        }
        private int kroczek = 0;
        private int pomin = 0;
        private void nextStrona_Click(object sender, RoutedEventArgs e)
        {
            kroczek += 1;
            if (kroczek < 0)
            {
                krok(1, 0);
            }
            else if (kroczek > 0)
            {
                
                krok(1, kroczek);
            }
            else
            {
                krok(1, 0);
            }
        }

        private void poprzedniaStrona_Click(object sender, RoutedEventArgs e)
        {
            kroczek -= 1;
            if (kroczek==0)
            {
                krok(2, kroczek);
            }else if (kroczek <0)
            {
             //   MessageBox.Show("Pierwsza strona już jest załadowana");
                //    MessageBoxButton.OK;
                krok(2, 0);
            }
            else
            {
               
                krok(2, kroczek);
            }
        }
    }
}
