using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Przelicznik_Jednostek;
using System.Data.Entity;
using System;

namespace Przelicznik_Jednostke.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            string v = "Przelicz C na F";
            string v1 = "Przelicz F na C";
            string v2 = "Przelicz M na KM";
            string v3 = "Przelicz KM na M";
            string v4 = "Przelicz KM na Yd";
            string v5 = "Przelicz Yd na KM";
            string v6 = "Przelicz KG na Ibs";
            string v7 = "Przelicz Ibs na KG";
            string v8 = "Przelicz KG na Gram";
            string v9 = "Przelicz Gram na KG";
            string v10 = "Przelicz Kelvin na C";
            string v11 = "Przelicz C na Kelvin";
            string v12 = "Przelicz Dżul na KiloDżul";
            string v13 = "Przelicz KiloDżul na Dżul";
            string v14 = "Przelicz godziny z 24h na 12h";
        public MainWindow()
        {
            


            InitializeComponent();
            wyswietl();
            ComboBox_Unit.ItemsSource = new List<string>()
            {
               v,
               v1,
               v2,
               v3,
               v4,
               v5,
               v6,
               v7,
               v8,
               v9,
               v10,
               v11,
               v12,
               v13,
               v14

            };
            ComboBox_Filtr.ItemsSource = new List<string>()
            {
                "--Brak--",
               v,
               v1,
               v2,
               v3,
               v4,
               v5,
               v6,
               v7,
               v8,
               v9,
               v10,
               v11,
               v12,
               v13,
               v14

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
        private void filtry(int pkt, int pomin)
        {
            model_danych md = new model_danych();
            if(pkt == 0)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 1)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v1) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 2)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v2) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 3)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v3) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 4)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v4) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 5)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v5) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 6)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v6) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 7)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v7) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 8)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v8) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 9)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v9) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 10)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v10) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 11)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v11) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 12)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v12) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 13)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v13) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
            else if (pkt == 14)
            {
                var date = from d in md.bazaDane.OrderBy(e => e.id_konwersja).Where(g => g.typ_konwersji == v14) select d;
                var ogranicz = date.Skip(pomin).Take(10);
                DataGrid1.ItemsSource = ogranicz.ToList();
            }
        }
        private int krok(int p, int krok,int w)
        {
            if (p == 01)
            {
                pomin += 10;

                if (krok == 0 && w == 101)
                {
                    ileNaStrone(10,0);
                }
                else if(krok > 0 && w == 101)
                {
                   
                     ileNaStrone(10,pomin);
                    

                }
                if (krok == 0 && w == 0)
                {
                    filtry(0, 0);
                }
                else if (krok > 0 && w == 0)
                {
                   
                        filtry(0, pomin);
                    

                }
                if (krok == 0 && w == 1)
                {
                    filtry(1, 0);
                }
                else if (krok > 0 && w == 1)
                {
                    
                        filtry(1, pomin);
                    
                
                }
                if (krok == 0 && w == 2)
                {
                    filtry(2, 0);
                }
                else if (krok > 0 && w == 2)
                {
                   
                        filtry(2, pomin);
                    

                }
                if (krok == 0 && w == 3)
                {
                    filtry(3, 0);
                }
                else if (krok > 0 && w == 3)
                {
                    
                        filtry(3, pomin);
                    

                }
                if (krok == 0 && w == 4)
                {
                    filtry(4, 0);
                }
                else if (krok > 0 && w == 4)
                {
                 
                        filtry(4, pomin);
                    

                }
                if (krok == 0 && w == 5)
                {
                    filtry(5, 0);
                }
                else if (krok > 0 && w == 5)
                {
                   
                        filtry(5, pomin);
                    

                }
                if (krok == 0 && w == 6)
                {
                    filtry(6, 0);
                }
                else if (krok > 0 && w == 6)
                {
                    
                        filtry(6, pomin);
                    

                }
                if (krok == 0 && w == 7)
                {
                    filtry(7, 0);
                }
                else if (krok > 0 && w == 7)
                {
                   
                        filtry(7, pomin);
                    

                }
                if (krok == 0 && w == 8)
                {
                    filtry(8, 0);
                }
                else if (krok > 0 && w == 8)
                {
                    
                        filtry(8, pomin);
                    

                }
                if (krok == 0 && w == 9)
                {
                    filtry(9, 0);
                }
                else if (krok > 0 && w == 9)
                {
                    
                        filtry(9, pomin);
                    

                }
                if (krok == 0 && w == 10)
                {
                    filtry(10, 0);
                }
                else if (krok > 0 && w == 10)
                {
                   
                      //  pomin += 10;
                        filtry(10, pomin);
                    

                }
                if (krok == 0 && w == 11)
                {
                    filtry(11, 0);
                }
                else if (krok > 0 && w == 11)
                {
                    
                      //  pomin += 10;
                        filtry(11, pomin);
                    

                }
                if (krok == 0 && w == 12)
                {
                    filtry(12, 0);
                }
                else if (krok > 0 && w == 12)
                {
                  
                       // pomin += 10;
                        filtry(12, pomin);
                    

                }
                if (krok == 0 && w == 13)
                {
                    filtry(13, 0);
                }
                else if (krok > 0 && w == 13)
                {
                   
                        filtry(13, pomin);
                    

                }
                if (krok == 0 && w == 14)
                {
                    filtry(14, 0);
                }
                else if (krok > 0 && w == 14)
                {
                  
                        filtry(14, pomin);
                    

                }
            }
            if (p == 02)
            {
                pomin -= 10;

                if (krok == 0 && w == 100)
                {
                    ileNaStrone(10, 0);
                }
                else if (krok > 0 && w == 100)
                {
                   
                        
                        ileNaStrone(10, pomin);
                    

                }
                if (krok == 0 && w == 0)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 0)
                {
                   
                        filtry(w, pomin);
                    
                }
                          if (krok == 0 && w == 1)
                          {
                              filtry(w, 0);
                         }
                           else if (krok > 0 && w == 1)
                {
                               
                                    filtry(w, pomin);
                                

                             }
                if (krok == 0 && w == 2)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 2)
                {
                      filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 3)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 3)
                {
                     filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 4)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 4)
                {
                    filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 5)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 5)
                {
                     filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 6)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 6)
                {
                    filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 7)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 7)
                {
                    filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 8)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 8)
                {
                    
                        filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 9)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 9)
                {
                    
                        filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 10)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 10)
                {
                    
                        filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 11)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 11)
                {
                   
                        filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 12)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 12)
                {
                    
                        filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 13)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 13)
                {
                    
                        filtry(w, pomin);
                    

                }
                if (krok == 0 && w == 14)
                {
                    filtry(w, 0);
                }
                else if (krok > 0 && w == 14)
                {
                    
                        filtry(w, pomin);
                    

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
                dodanieRekordu.dodajRekord("Przelicz C na F", input, input2);
                
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz F na C")
            {
                string input = TexBox_Number.Text;
                int q = 1;
                double jednostka = double.Parse(input);
                
                TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz F na C", input, input2);
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz M na KM")
            {
                string input = TexBox_Number.Text;
                int q = 3;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz M na KM", input, input2);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz KM na M")
            {
                string input = TexBox_Number.Text;
                int q = 4;
                double jednostka = double.Parse(input);
                 
                TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz KM na M", input, input2);
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz KG na Ibs")
            {
                string input = TexBox_Number.Text;
                int q = 6;
                double jednostka = double.Parse(input);
               
                TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz KG na Ibs", input, input2);
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz Ibs na KG")
            {
                string input = TexBox_Number.Text;
                int q = 5;
                double jednostka = double.Parse(input);
               TextBlock_Converted.Text = new Dzialania().which_submition(q,jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz Ibs na KG", input, input2);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz KM na Yd")
            {
                string input = TexBox_Number.Text;
                int q = 7;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz KM na Yd", input, input2);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz Yd na KM")
            {
                string input = TexBox_Number.Text;
                int q = 8;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz Yd na KM", input, input2);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz KG na Gram")
            {
                string input = TexBox_Number.Text;
                int q = 12;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz KG na Gram", input, input2);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz Gram na KG")
            {
                string input = TexBox_Number.Text;
                int q = 13;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz Gram na KG", input, input2);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz Kelvin na C")
            {
                string input = TexBox_Number.Text;
                int q = 10;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz Kelvin na C", input, input2);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz C na Kelvin")
            {
                string input = TexBox_Number.Text;
                int q = 11;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz C na Kelvin", input, input2);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz Dżul na KiloDżul")
            {
                string input = TexBox_Number.Text;
                int q = 14;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz Dżul na KiloDżul", input, input2);

            }
            if (ComboBox_Unit.SelectedItem == "Przelicz KiloDżul na Dżul")
            {
                string input = TexBox_Number.Text;
                int q = 15;
                double jednostka = double.Parse(input);
                TextBlock_Converted.Text = new Dzialania().which_submition(q, jednostka);
                string input2 = TextBlock_Converted.Text;
                double po = double.Parse(input2);
                dodanieRekordu.dodajRekord("Przelicz KiloDżul na Dżul", input, input2);

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

            string przed = input + " : " + input1;
            string po = Converted_Hours.Text + " : " + Converted_Minuts.Text;
           // double przed1 = godzina + minuta;
           // double po1 = double.Parse(po);
            dodanieRekordu.dodajRekord("Przelicz godziny z 24h na 12h", przed ,po);

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
                krok(01, 0,101);
            }
            else if (kroczek > 0)
            {
                
                krok(01, kroczek,101);
            }
            else
            {
                krok(01, 0,101);
            }
            if (ComboBox_Filtr.SelectedItem == v)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,0);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                   
                    krok(01, kroczek,0);
                }
                else
                {
                    krok(01, 0,0);
                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v1)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,1);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,1);
                }
                else
                {
                    krok(01, 0,1);
                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v2)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,2);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,2);
                }
                else
                {
                    krok(01, 0,2);
                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v3)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,3);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,3);
                }
                else
                {
                    krok(01, 0,3);
                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v4)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,4);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,4);
                }
                else
                {
                    krok(01, 0,4);
                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v5)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,5);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                   
                    krok(01, kroczek,5);
                }
                else
                {
                    krok(01, 0,5);

                }

            }
            else if (ComboBox_Filtr.SelectedItem == v6)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,6);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,6);
                }
                else
                {
                    krok(01, 0,6);
                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v7)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,7);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,7);
                }
                else
                {
                    krok(01, 0,7);
                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v8)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,8);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,8);
                }
                else
                {
                    krok(01, 0,8);

                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v9)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,9);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,9);
                }
                else
                {
                    krok(01, 0,9);
                    
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v10)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,10);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,10);
                }
                else
                {
                    krok(01, 0,10);
                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v11)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,11);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,11);
                }
                else
                {
                    krok(01, 0,11);
                    
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v12)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,12);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,12);
                }
                else
                {
                    krok(01, 0,12);

                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v13)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,13);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,13);
                }
                else
                {
                    krok(01, 0,13);
                   
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v14)
            {
                if (kroczek == 0)
                {
                    krok(01, kroczek,14);
                }
                else if (kroczek > 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(01, kroczek,14);
                }
                else
                {
                    krok(01, 0,14);
                    
                }

            }
        }

        private void poprzedniaStrona_Click(object sender, RoutedEventArgs e)
        {
            kroczek -= 1;
            if (kroczek==0)
            {
                krok(02, kroczek,100);
            }else if (kroczek <0)
            {
            
                krok(02, 0,100);
            }
            else
            {
               
                krok(02, kroczek,100);
            }
            if (ComboBox_Filtr.SelectedItem == v)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,0);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,0);
                }
                else
                {

                    krok(02, kroczek,0);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v1)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,1);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,1);
                }
                else
                {

                    krok(02, kroczek,1);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v2)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,2);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,2);
                }
                else
                {

                    krok(02, kroczek,2);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v3)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,2);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,3);
                }
                else
                {

                    krok(02, kroczek,3);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v4)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,4);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,4);
                }
                else
                {

                    krok(02, kroczek,4);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v5)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,5);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,5);
                }
                else
                {

                    krok(02, kroczek,5);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v6)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,6);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,6);
                }
                else
                {

                    krok(02, kroczek,6);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v7)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,7);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,7);
                }
                else
                {

                    krok(02, kroczek,7);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v8)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,8);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,8);
                }
                else
                {

                    krok(02, kroczek,8);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v9)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,9);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,8);
                }
                else
                {

                    krok(02, kroczek,9);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v10)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,10);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,10);
                }
                else
                {

                    krok(02, kroczek,10);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v11)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,11);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,11);
                }
                else
                {

                    krok(02, kroczek,11);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v12)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,12);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,12);
                }
                else
                {

                    krok(02, kroczek,12);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v13)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,13);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,13);
                }
                else
                {

                    krok(02, kroczek,13);
                }

            }
            else if (ComboBox_Filtr.SelectedItem == v14)
            {
                if (kroczek == 0)
                {
                    krok(02, kroczek,14);
                }
                else if (kroczek < 0)
                {
                    //   MessageBox.Show("Pierwsza strona już jest załadowana");
                    //    MessageBoxButton.OK;
                    krok(02, 0,14);
                }
                else
                {

                    krok(02, kroczek,14);
                }

            }
        }

        private void ComboBox_Filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_Filtr.SelectedItem == v)
            {
                kroczek = 0;
                pomin = 0;
                filtry(0, 0);

            }
            else if (ComboBox_Filtr.SelectedItem == v1)
            {
                kroczek = 0;
                pomin = 0;
                filtry(1, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v2)
            {
                kroczek = 0;
                pomin = 0;
                filtry(2, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v3)
            {
                kroczek = 0;
                pomin = 0;
                filtry(3, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v4)
            {
                kroczek = 0;
                pomin = 0;
                filtry(4, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v5)
            {
                kroczek = 0;
                pomin = 0;
                filtry(5, 0);
                
            }
            else if (ComboBox_Filtr.SelectedItem == v6)
            {
                kroczek = 0;
                pomin = 0;
                filtry(6, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v7)
            {
                kroczek = 0;
                pomin = 0;
                filtry(7, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v8)
            {
                kroczek = 0;
                pomin = 0;
                filtry(8, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v9)
            {
                kroczek = 0;
                pomin = 0;
                filtry(9, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v10)
            {
                kroczek = 0;
                pomin = 0;
                filtry(10, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v11)
            {
                kroczek = 0;
                pomin = 0;
                filtry(11, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v12)
            {
                kroczek = 0;
                pomin = 0;
                filtry(12, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v13)
            {
                kroczek = 0;
                pomin = 0;
                filtry(13, 0);
            }
            else if (ComboBox_Filtr.SelectedItem == v14)
            {
                kroczek = 0;
                pomin = 0;
                filtry(14, 0);
            }
            else
            {
                kroczek = 0;
                pomin = 0;
                wyswietl();
            }
        }

        private void Sprawdz_Click(object sender, RoutedEventArgs e)
        {

           using(var data = new model_danych())
            {
                var target = data.bazaDane.GroupBy(TOP => new { TOP.typ_konwersji });
                var naj3 = target.Select(top => new { licz = top.Count(), top.Key.typ_konwersji })
                    .OrderByDescending(x => x.licz)
                    .Take(3);
                DataGrid1.ItemsSource = naj3.ToList();
            }

        }
    }
}
