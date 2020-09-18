using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
using UnitConverter;
using UnitConverter.Desktop;

namespace desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            converterCombobox.ItemsSource = new List<Interface>()
            {
            new Speed(),
            new Length(),
            new Weight(),
            new Temperature(),
            new Time()
            };

            using (statystykiEntities context = new statystykiEntities())
            {
                List<statystyki> itemy = context.statystyki.ToList();
                statystyki.DataContext = itemy.Take(5).ToList();
                najczesciej.ItemsSource = itemy.GroupBy(b => new { b.Rodzaj })
                    .Select(c => new { c.Key.Rodzaj, count = c.Count() })
                    .OrderByDescending(d => d.count).ToList().Take(3);
            }
            //odczytac z bazy danych rateValue
            int feedback;
            using (ocenyEntities context = new ocenyEntities())
            {
                List<oceny> o1 = context.oceny.ToList();
                oceny o2 = o1.LastOrDefault();
                feedback = o2.feedback;
            }
            rateControl.RateValue = feedback;

            ConvertCommand = new RelayCommand(obj => Convert(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
            convertButton.Command = ConvertCommand;

            WyszukajCommand = new RelayCommand(obj => wyszukaj_Click(), obj =>
                                    OD.SelectedDate != null && DO.SelectedDate != null &&
                                    string.IsNullOrEmpty(STRONY.Text) != true &&
                                    int.TryParse(STRONY.Text, out int result) == true);
            wyszukaj.Command = WyszukajCommand;

            if (true)
            {
                WatchCommand1 = new RelayCommand(obj => Button_Click1(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton1.Command = WatchCommand1;
                WatchCommand2 = new RelayCommand(obj => Button_Click2(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton2.Command = WatchCommand2;
                WatchCommand3 = new RelayCommand(obj => Button_Click3(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton3.Command = WatchCommand3;
                WatchCommand4 = new RelayCommand(obj => Button_Click4(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton4.Command = WatchCommand4;
                WatchCommand5 = new RelayCommand(obj => Button_Click5(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton5.Command = WatchCommand5;
                WatchCommand6 = new RelayCommand(obj => Button_Click6(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton6.Command = WatchCommand6;
                WatchCommand7 = new RelayCommand(obj => Button_Click7(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton7.Command = WatchCommand7;
                WatchCommand8 = new RelayCommand(obj => Button_Click8(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton8.Command = WatchCommand8;
                WatchCommand9 = new RelayCommand(obj => Button_Click9(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton9.Command = WatchCommand9;
                WatchCommand10 = new RelayCommand(obj => Button_Click10(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton10.Command = WatchCommand10;
                WatchCommand11 = new RelayCommand(obj => Button_Click11(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton11.Command = WatchCommand11;
                WatchCommand12 = new RelayCommand(obj => Button_Click12(), obj =>
                                    unitFromCombobox.SelectedItem != null && unitToCombobox != null &&
                                    string.IsNullOrEmpty(inputTextbox.Text) != true);
                watchButton12.Command = WatchCommand12;


            }

        }


        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromCombobox.ItemsSource = ((Interface)converterCombobox.SelectedItem).Units;
            unitToCombobox.ItemsSource = ((Interface)converterCombobox.SelectedItem).Units;
        }

        private RelayCommand ConvertCommand;
        private RelayCommand WatchCommand1;
        private RelayCommand WatchCommand2;
        private RelayCommand WatchCommand3;
        private RelayCommand WatchCommand4;
        private RelayCommand WatchCommand5;
        private RelayCommand WatchCommand6;
        private RelayCommand WatchCommand7;
        private RelayCommand WatchCommand8;
        private RelayCommand WatchCommand9;
        private RelayCommand WatchCommand10;
        private RelayCommand WatchCommand11;
        private RelayCommand WatchCommand12;

        private RelayCommand WyszukajCommand;

        private void Convert()
        {
            string inputText = inputTextbox.Text;
            double inputValue = double.Parse(inputText);
            double result = ((Interface)converterCombobox.SelectedItem).Convert(
                unitFromCombobox.SelectedItem.ToString(),
                unitToCombobox.SelectedItem.ToString(),
                inputValue);

            outputTextBlock.Text = result.ToString();

            using (statystykiEntities context = new statystykiEntities())
            {
                statystyki nowyItem = new statystyki()
                {
                    Rodzaj = ((Interface)converterCombobox.SelectedItem).Name,
                    Jednostki = unitFromCombobox.SelectedItem + " -> " + unitToCombobox.SelectedItem,
                    Data = DateTime.Now,
                    WartoscPrzed = inputTextbox.Text,
                    WartoscPo = outputTextBlock.Text
                };
                context.statystyki.Add(nowyItem);
                context.SaveChanges();
            }

        }

        private void Button_Click1()
        {
            clock.Angle = -240;
        }

        private void Button_Click2()
        {
            clock.Angle = -210;
        }

        private void Button_Click3()
        {
            clock.Angle = -180;
        }

        private void Button_Click4()
        {
            clock.Angle = -150;
        }

        private void Button_Click5()
        {
            clock.Angle = -120;
        }

        private void Button_Click6()
        {
            clock.Angle = -90;
        }

        private void Button_Click7()
        {
            clock.Angle = -60;
        }

        private void Button_Click8()
        {
            clock.Angle = -30;
        }

        private void Button_Click9()
        {
            clock.Angle = 0;
        }

        private void Button_Click10()
        {
            clock.Angle = -330;
        }

        private void Button_Click11()
        {
            clock.Angle = -300;
        }

        private void Button_Click12()
        {
            clock.Angle = 90;
        }

        //private void wyszukaj_Click(object sender, RoutedEventArgs e)
        private void wyszukaj_Click()
        {
            using (statystykiEntities context = new statystykiEntities())
            {
                List<statystyki> itemy = context.statystyki.ToList();
                List<statystyki> wyszukaj = itemy.Where(a => a.Data >= OD.SelectedDate && a.Data < DO.SelectedDate && a.Rodzaj.StartsWith(RODZAJ.Text))
                    .ToList();
                statystyki.DataContext = wyszukaj
                    .Skip((int.Parse(STRONY.Text) - 1) * 5)
                    .Take(5)
                    .ToList();
                najczesciej.ItemsSource = wyszukaj
                    .GroupBy(a => new { a.Rodzaj })
                    .Select(b => new { b.Key.Rodzaj, count = b.Count() })
                    .OrderByDescending(c => c.count)
                    .ToList()
                    .Take(3);
            }
        }

        private bool start = true;
        private void rateControl_RateValueChanged(object sender, Common.Controls.RateEventArgs e)
        {
            // e.Value
            // zapisac do bazy danych
            int before;
            using (ocenyEntities context1 = new ocenyEntities())
            {
                int next;
                using (ocenyEntities context2 = new ocenyEntities())
                {
                    List<oceny> o1 = context2.oceny.ToList();
                    oceny o2 = o1.LastOrDefault();
                    next = o2.feedback;
                }
                before = next;
                oceny newOne = new oceny();
                if (!start)
                {
                    newOne = new oceny()
                    {
                        feedback = e.Value
                    };
                    context1.oceny.Add(newOne);
                    context1.SaveChanges();
                }
            }
            if (!(before != e.Value || start))
            {
                rateControl.Remove();
                using (ocenyEntities context = new ocenyEntities())
                {
                    List<oceny> o1 = context.oceny.ToList();
                    oceny o2 = o1.LastOrDefault();
                    o2.feedback = 0;
                    //context.oceny.Add(o2);
                    context.SaveChanges();
                }
            }
            start = false;
        }
    }
}
