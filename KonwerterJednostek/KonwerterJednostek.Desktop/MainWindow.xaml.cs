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
        static int statisticNumber = 1;
        static int previousStatisticNumber = 1;

        public MainWindow()
        {
            InitializeComponent();

            dziedzinaCombo.ItemsSource = new KonwerterService().GetConverters();
            FiltrPoRodzKonw.ItemsSource = new KonwerterService().GetConverters();
            view(statisticView(statisticNumber));
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
            string UnitFrom = jednFromCombo.SelectedItem.ToString();
            string UnitTo = jednToCombo.SelectedItem.ToString();

            decimal result = ((IConverter)dziedzinaCombo.SelectedItem).Convert(
                                jednFromCombo.SelectedItem.ToString(), jednToCombo.SelectedItem.ToString(), wartoscValue);

            if (nameConverter == "Konwerter godziny")
            {
                decimal resultHours = ((IConverter)dziedzinaCombo.SelectedItem).Convert(
                jednFromCombo.SelectedItem.ToString(), jednToCombo.SelectedItem.ToString(), wartoscValue);
                TimeConverter timeConverter = new TimeConverter();
                string time = timeConverter.Inscription(wartoscValue);
                wynikBlock.Text = resultHours.ToString() + " : " + wartoscTextMinute + " " + time;

                decimal valueRegis = wartoscValue + (wartoscMinute / 100);
                registration(nameConverter, UnitFrom, UnitTo, valueRegis, resultHours.ToString() + " : " + wartoscTextMinute + " " + time);

                Double valueHours = (double)(-90 + resultHours * 30);
                Double valueMinute = (double)(-90 + wartoscMinute * 6);
                clockHourRotation.Angle = valueHours;
                clockMinuteRotation.Angle = valueMinute;
                ((System.Windows.Media.Animation.Storyboard)Resources["NextStoryboard"]).Begin();
            } else
            {
                registration(nameConverter, UnitFrom, UnitTo, wartoscValue, result.ToString());
                wynikBlock.Text = result.ToString();
            }

            view(statisticView(statisticNumber));
        }

        private void FiltrPoRodzKonw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nameConverter = ((IConverter)FiltrPoRodzKonw.SelectedItem).Name;
            if (nameConverter == "Konwerter masy")
            {
                previousStatisticNumber = statisticNumber;
                statisticNumber = 2;
                view(statisticView(statisticNumber));
            }
            else if (nameConverter == "Konwerter objętości")
            {
                previousStatisticNumber = statisticNumber;
                statisticNumber = 3;
                view(statisticView(statisticNumber));
            }
            else if (nameConverter == "Konwerter godziny")
            {
                previousStatisticNumber = statisticNumber;
                statisticNumber = 4;
                view(statisticView(statisticNumber));
            }
            else if (nameConverter == "Konwerter temperatury")
            {
                previousStatisticNumber = statisticNumber;
                statisticNumber = 5;
                view(statisticView(statisticNumber));
            }
            else if (nameConverter == "Konwerter długości")
            {
                previousStatisticNumber = statisticNumber;
                statisticNumber = 6;
                view(statisticView(statisticNumber));
            }
        }

        private void dateStatisticBaton_Click(object sender, RoutedEventArgs e)
        {
            previousStatisticNumber = statisticNumber;
            statisticNumber = 7;
            view(statisticView(previousStatisticNumber));
        }

        static int numberOfPage = 1;
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfPage > 1)
            {
                if(statisticNumber == 7)
                {
                    numberOfPage = numberOfPage - 1;
                    numberPage.Text = numberOfPage.ToString();
                    view(statisticView(previousStatisticNumber));
                } else
                {
                    numberOfPage = numberOfPage - 1;
                    numberPage.Text = numberOfPage.ToString();
                    view(statisticView(statisticNumber));
                }
            }
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (statisticNumber == 7)
            {
                numberOfPage = numberOfPage + 1;
                numberPage.Text = numberOfPage.ToString();
                view(statisticView(previousStatisticNumber));
            } else
            {
                numberOfPage = numberOfPage + 1;
                numberPage.Text = numberOfPage.ToString();
                view(statisticView(statisticNumber));
            } 
        }

        private void showTheMostPopularBaton_Click(object sender, RoutedEventArgs e)
        {
            previousStatisticNumber = 1;
            statisticNumber = 8;
            view(statisticView(previousStatisticNumber));
        }

        private List<Wpis> statisticView(int number)
        {
            using (KonwerterBaza context = new KonwerterBaza())
            {
                if (number == 1)
                {
                    List<Wpis> list = context.registrations.OrderBy(w => w.Id).ToList();
                    return list;
                } else if (number == 2)
                {
                    List<Wpis> list = context.registrations.Where(w => w.ConverterName == "Konwerter masy").OrderBy(w => w.Id).ToList();
                    return list;
                } else if (number == 3)
                {
                    List<Wpis> list = context.registrations.Where(w => w.ConverterName == "Konwerter objętości").OrderBy(w => w.Id).ToList();
                    return list;
                }
                else if (number == 4)
                {
                    List<Wpis> list = context.registrations.Where(w => w.ConverterName == "Konwerter godziny").OrderBy(w => w.Id).ToList();
                    return list;
                }
                else if (number == 5)
                {
                    List<Wpis> list = context.registrations.Where(w => w.ConverterName == "Konwerter temperatury").OrderBy(w => w.Id).ToList();
                    return list;
                }
                else if (number == 6)
                {
                    List<Wpis> list = context.registrations.Where(w => w.ConverterName == "Konwerter długości").OrderBy(w => w.Id).ToList();
                    return list;
                }
                return null;
            }
        }

        private void view(List<Wpis> list)
        {
            if(statisticNumber == 7)
            {
                DateTime date1 = DateTime.Parse(wartoscOd.Text);
                DateTime date2 = DateTime.Parse(wartoscDo.Text);
                DataGridHistory.ItemsSource = list.Where(w => w.Data > date1).Where(w => w.Data < date2).Skip(5 * (numberOfPage - 1)).Take(5);
            } else if (statisticNumber == 8)
            {
                DataGridHistory.ItemsSource = list.GroupBy(w => w.ConverterName).Select(w => new { Str = w.Key, Count = w.Count() }).OrderByDescending(w => w.Count).Take(3);
            } else
            {
                DataGridHistory.ItemsSource = list.Skip(5 * (numberOfPage - 1)).Take(5);
            }
        }

        private void registration(string ConverterName, string UnitFrom, string UnitTo, decimal ValueFrom, string ValueTo)
        {
            DateTime nowTime = DateTime.Now;

            using (KonwerterBaza context = new KonwerterBaza())
            {
                Wpis newRegistration = new Wpis()
                {
                    ConverterName = ConverterName,
                    UnitFrom = UnitFrom,
                    UnitTo = UnitTo,
                    Data = nowTime,
                    ValueFrom = ValueFrom,
                    ValueTo = ValueTo
                   
                };
                context.registrations.Add(newRegistration);
                context.SaveChanges();
            }
        }
    }
}
