using KonwerterJednostek.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            showRate();

            DateStatisticCommand = new RelayCommand(obj => dateStatisticBaton_Click(), obj =>
            string.IsNullOrEmpty(wartoscOd.Text) != true && string.IsNullOrEmpty(wartoscDo.Text) != true);
          
            dateStatisticBaton.Command = DateStatisticCommand;

            BackCommand = new RelayCommand(obj => BackC());
            Back.Command = BackCommand;

            NextCommand = new RelayCommand(obj => NextC());
            Next.Command = NextCommand;

            showTheMostPopularCommand = new RelayCommand(obj => showTheMostPopularBatonC());
            showTheMostPopularBaton.Command = showTheMostPopularCommand;

            //private RelayCommand BackCommand;
            //private RelayCommand NextCommand;
            //private RelayCommand showTheMostPopularCommand;
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

        private RelayCommand DateStatisticCommand;

        private void dateStatisticBaton_Click()
        {
            previousStatisticNumber = statisticNumber;
            statisticNumber = 7;
            view(statisticView(previousStatisticNumber));
        }


        static int numberOfPage = 1;

        private RelayCommand BackCommand;

        private void BackC()
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

        private RelayCommand NextCommand;

        private void NextC()
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

        private RelayCommand showTheMostPopularCommand;

        private void showTheMostPopularBatonC()
        {
            previousStatisticNumber = 1;
            statisticNumber = 8;

            //loaderRectangle.Visibility = Visibility.Visible;

            ((System.Windows.Media.Animation.Storyboard)Resources["LoadStoryboard"]).Begin();

            Task t1 = new Task(() => view(statisticView(previousStatisticNumber)));
            t1.Start();

            Task.WhenAll(t1).ContinueWith(t =>
            {
                //loaderRectangle.Visibility = Visibility.Hidden;
            }, TaskScheduler.FromCurrentSynchronizationContext());
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
            Task.Delay(6000).Wait();

            if (statisticNumber == 7)
            {
                DateTime date1 = DateTime.Parse(wartoscOd.Text);
                DateTime date2 = DateTime.Parse(wartoscDo.Text);
                DataGridHistory.ItemsSource = list.Where(w => w.Data > date1).Where(w => w.Data < date2).Skip(5 * (numberOfPage - 1)).Take(5);
            } else if (statisticNumber == 8)
            {
                Dispatcher.Invoke(() => DataGridHistory.ItemsSource = list.GroupBy(w
                    => w.ConverterName).Select(w => new { Str = w.Key, Count = w.Count() }).OrderByDescending(w => w.Count).Take(3));
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

        private void showRate()
        {
            using (KonwerterBaza context = new KonwerterBaza())
            {
                rateControl.RateValue = context.newStar.OrderByDescending(o => o.Id).Select(o => o.valueOfStar).FirstOrDefault();
            }
        }

        private void rateControl_RateValueChanged(object sender, Common.Controls.RateEventArgs e)
        {
            using (KonwerterBaza context2 = new KonwerterBaza())
            {
                Star newRegistrationStar = new Star()
                {
                    valueOfStar = e.Value  
                };
                context2.newStar.Add(newRegistrationStar);
                context2.SaveChanges();
            }
        }
    }
}
