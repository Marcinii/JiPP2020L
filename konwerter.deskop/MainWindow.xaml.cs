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
using konwerter.logic;
using Microsoft.VisualBasic;
using System.Windows.Media.Animation;

namespace konwerter.deskop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combobox.ItemsSource = Converters;
            rodzaj_statystyki.ItemsSource = Converters;
        }
        public List<string> Converters => new List<string>()
        {
            "Temperatura",
            "Długosci",
            "Masa",
            "Dane",
        };

        private void buttonPrzelicz_Click(object sender, RoutedEventArgs e)
        {
            string unitFrom = InputText.Text;
            string unitTo = InputText2.Text;
            string inputValue = InputText3.Text;

            decimal value = decimal.Parse(inputValue);

            string input = combobox.Text;

            switch (input)
            {
                case "Temperatura":
                    decimal result1 = new temp_converter().Convert(unitFrom, unitTo, value);
                    OutputText.Text = result1.ToString();
                    break;
                case "Długosci":
                    decimal result2 = new length_converter().Convert(unitFrom, unitTo, value);
                    OutputText.Text = result2.ToString();
                    break;
                case "Masa":
                    decimal result3 = new weight_conventer().Convert(unitFrom, unitTo, value);
                    OutputText.Text = result3.ToString();
                    break;
                case "Dane":
                    decimal result4 = new data_converter().Convert(unitFrom, unitTo, value);
                    OutputText.Text = result4.ToString();
                    break;
            }
            DateTime TimeNow = DateTime.Now;
            using (ProgramowanieEntities context = new ProgramowanieEntities())
            {
                Baza001 newbaza001 = new Baza001()
                {
                    converter = input,
                    unitFrom = unitFrom,
                    unitTo = unitTo,
                    inputValue = value,
                    outputValue = OutputText.Text,
                    time = TimeNow,

                };
                context.Baza001.Add(newbaza001);
                context.SaveChanges();
            }

        }
        private void buttonTime_Click(object sender, RoutedEventArgs e)
        {
            int godz1 = (int)InputTime.Text[0] - '0';
            int godz2 = (int)InputTime.Text[1] - '0';
            int godz = godz1 * 10 + godz2;

            int min1 = (int)InputTime.Text[3] - '0';
            int min2 = (int)InputTime.Text[4] - '0';
            int min = min1 * 10 + min2;

            string ty, x = ":";
            if (godz <= 12)
                ty = " AM";
            else
                ty = " PM";

            decimal Time = new time_converter().ConvTime(godz, min);

            OutputTime.Text = Time.ToString() + x + min.ToString() + ty;

            int angel1 = 0;
            if (godz == 0) angel1 = 90;
            else if (godz == 1) angel1 = 120;
            else if (godz == 2) angel1 = 150;
            else if (godz == 3) angel1 = 180;
            else if (godz == 4) angel1 = 210;
            else if (godz == 5) angel1 = 240;
            else if (godz == 6) angel1 = 270;
            else if (godz == 7) angel1 = 300;
            else if (godz == 8) angel1 = 330;
            else if (godz == 9) angel1 = 0;
            else if (godz == 10) angel1 = 30;
            else if (godz == 11) angel1 = 60;
            else if (godz == 12) angel1 = 90;
            godzRotation.Angle = angel1;

            int angel2 = 0;
            if (min == 0) angel2 = 90;
            else if (min == 1) angel2 = 96;
            else if (min == 2) angel2 = 102;
            else if (min == 3) angel2 = 108;
            else if (min == 4) angel2 = 114;
            else if (min == 5) angel2 = 120;
            else if (min == 6) angel2 = 126;
            else if (min == 7) angel2 = 132;
            else if (min == 8) angel2 = 138;
            else if (min == 9) angel2 = 144;
            else if (min == 10) angel2 = 150;
            else if (min == 11) angel2 = 156;
            else if (min == 12) angel2 = 162;
            else if (min == 13) angel2 = 168;
            else if (min == 14) angel2 = 174;
            else if (min == 15) angel2 = 180;
            else if (min == 16) angel2 = 186;
            else if (min == 17) angel2 = 192;
            else if (min == 18) angel2 = 198;
            else if (min == 19) angel2 = 204;
            else if (min == 20) angel2 = 210;
            else if (min == 21) angel2 = 216;
            else if (min == 22) angel2 = 222;
            else if (min == 23) angel2 = 228;
            else if (min == 24) angel2 = 234;
            else if (min == 25) angel2 = 240;
            else if (min == 26) angel2 = 246;
            else if (min == 27) angel2 = 252;
            else if (min == 28) angel2 = 258;
            else if (min == 29) angel2 = 264;
            else if (min == 30) angel2 = 270;
            else if (min == 31) angel2 = 276;
            else if (min == 32) angel2 = 282;
            else if (min == 33) angel2 = 288;
            else if (min == 34) angel2 = 294;
            else if (min == 35) angel2 = 300;
            else if (min == 36) angel2 = 306;
            else if (min == 37) angel2 = 312;
            else if (min == 38) angel2 = 318;
            else if (min == 39) angel2 = 324;
            else if (min == 40) angel2 = 330;
            else if (min == 41) angel2 = 336;
            else if (min == 42) angel2 = 342;
            else if (min == 43) angel2 = 348;
            else if (min == 44) angel2 = 354;
            else if (min == 45) angel2 = 360;
            else if (min == 46) angel2 = 366;
            else if (min == 47) angel2 = 372;
            else if (min == 48) angel2 = 378;
            else if (min == 49) angel2 = 384;
            else if (min == 50) angel2 = 390;
            else if (min == 51) angel2 = 396;
            else if (min == 52) angel2 = 402;
            else if (min == 53) angel2 = 408;
            else if (min == 54) angel2 = 414;
            else if (min == 55) angel2 = 420;
            else if (min == 56) angel2 = 426;
            else if (min == 57) angel2 = 432;
            else if (min == 58) angel2 = 438;
            else if (min == 59) angel2 = 444;
            else if (min == 60) angel2 = 450;

            minRotation.Angle = angel2;
        }

        public void filtr_rodzaj_konwertera()
        {
            string rodzajbox = rodzaj_statystyki.Text;

            if (rodzajbox == "Temperatura")
                using (ProgramowanieEntities context = new ProgramowanieEntities())
                {
                    List<Baza001> Baza001 = context.Baza001
                        .Where(b => b.converter == "Temperatura")
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    BazaStatystyk.ItemsSource = Baza001;
                }
            else if (rodzajbox == "Długosci")
                using (ProgramowanieEntities context = new ProgramowanieEntities())
                {
                    List<Baza001> Baza001 = context.Baza001
                        .Where(b => b.converter == "Długosci")
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    BazaStatystyk.ItemsSource = Baza001;
                }
            else if (rodzajbox == "Masa")
                using (ProgramowanieEntities context = new ProgramowanieEntities())
                {
                    List<Baza001> Baza001 = context.Baza001
                        .Where(b => b.converter == "Masa")
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    BazaStatystyk.ItemsSource = Baza001;
                }
            else if (rodzajbox == "Dane")
                using (ProgramowanieEntities context = new ProgramowanieEntities())
                {
                    List<Baza001> Baza001 = context.Baza001
                        .Where(b => b.converter == "Dane")
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    BazaStatystyk.ItemsSource = Baza001;
                }
        }

        public void data_konwersji()
        {
            if (databox2.Text == "Brak daty" && databox1.Text == "Brak daty")
            {
            }
            else
            {
                string date1 = databox1.Text;
                DateTime date11 = DateTime.Parse(date1);

                string date2 = databox2.Text;
                DateTime date22 = DateTime.Parse(date2);

                using (ProgramowanieEntities context = new ProgramowanieEntities())
                {
                    List<Baza001> Baza001 = context.Baza001
                        .Where(b => b.time > date11)
                        .Where(b => b.time < date22)
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    foreach (Baza001 b in Baza001)
                    {
                        BazaStatystyk.ItemsSource = Baza001;
                    }
                }
            }
        }

        public void buttonDataGrid_Click(object sender, RoutedEventArgs e)
        {
            filtr_rodzaj_konwertera();
        }

        private void buttonDataGrid1_Click(object sender, RoutedEventArgs e)
        {
            data_konwersji();
        }

        private int nextpage = 0;

        public void Next_Click(object sender, RoutedEventArgs e)
        {
            nextpage = nextpage + 20;
            coutpage.Text = nextpage.ToString();
            filtr_rodzaj_konwertera();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            nextpage = nextpage - 20;
            coutpage.Text = nextpage.ToString();
            filtr_rodzaj_konwertera();
        }

        private void stat_Click(object sender, RoutedEventArgs e)
        {
            using (ProgramowanieEntities context = new ProgramowanieEntities())
            {

                if (databox2.Text == "Brak daty" && databox1.Text == "Brak daty")
                {
                    var result = context.Baza001.AsEnumerable()
                                   .GroupBy(b => b.converter)
                                   .Select(b => new { Str = b.Key, Count = b.Count() })
                                   .OrderByDescending(b => b.Count)
                                   .Take(3);

                    foreach (var item in result)
                    {
                        BazaStatystyk.ItemsSource = result;
                    }
                }
                else
                {
                    string date1 = databox1.Text;
                    DateTime date11 = DateTime.Parse(date1);

                    string date2 = databox2.Text;
                    DateTime date22 = DateTime.Parse(date2);

                    var result = context.Baza001.AsEnumerable()
                                   .Where(b => b.time > date11)
                                   .Where(b => b.time < date22)
                                   .GroupBy(b => b.converter)
                                   .Select(b => new { Str = b.Key, Count = b.Count() })
                                   .OrderByDescending(b => b.Count)
                                   .Take(3);

                    foreach (var item in result)
                    {
                        BazaStatystyk.ItemsSource = result;
                    }
                }

            }

        }
    }
}
