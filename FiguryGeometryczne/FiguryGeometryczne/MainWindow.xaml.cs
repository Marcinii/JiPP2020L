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
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Threading;
using UnitFile.Logic;

namespace FiguryGeometryczne
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            figureComboBox.ItemsSource = new List<IFigure>()
            {
                new Parallelogram(),
                new RectangleF(),
                new Square(),
                new Trapeze(),
                new Triangle()
            };
        }

        public void WaitFunction()
        {
            Task.Delay(3000).Wait();
            Dispatcher.Invoke(() =>
            {
                resultTextBlock.Visibility = Visibility.Visible;
            });
            
        }
        
        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
              
            string sideA = sideATextBox.Text;
            string sideB = sideBTextBox.Text;
            string sideH = sideHTextBox.Text;

            double valueA = double.Parse(sideA);
            double valueB = double.Parse(sideB);
            double valueH = double.Parse(sideH);

            double result = ((IFigure)figureComboBox.SelectedItem).Calculate(valueA, valueB, valueH);
            resultTextBlock.Text = result.ToString();

            loaderGrid.Visibility = Visibility.Visible;
            ((Storyboard)Resources["loadingBoard"]).Begin();
            Task t1 = new Task(() => WaitFunction());
            t1.Start();

            Task.WhenAll(t1).ContinueWith(t =>
            {
                loaderGrid.Visibility = Visibility.Hidden;
                ((Storyboard)Resources["loadingBoard"]).Stop();
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void figureComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (figureComboBox.SelectedIndex == 0)
            {
                sideAGrid.Visibility = Visibility.Visible;
                sideHGrid.Visibility = Visibility.Visible;
            }
            else if (figureComboBox.SelectedIndex == 1)
            {
                sideAGrid.Visibility = Visibility.Visible;
                sideBGrid.Visibility = Visibility.Visible;
                sideHGrid.Visibility = Visibility.Hidden;
            }
            else if (figureComboBox.SelectedIndex == 2)
            {
                sideAGrid.Visibility = Visibility.Visible;
                sideBGrid.Visibility = Visibility.Hidden;
                sideHGrid.Visibility = Visibility.Hidden;
            }
            else if (figureComboBox.SelectedIndex == 3)
            {
                sideAGrid.Visibility = Visibility.Visible;
                sideBGrid.Visibility = Visibility.Visible;
                sideHGrid.Visibility = Visibility.Visible;
            }
            else if (figureComboBox.SelectedIndex == 4)
            {
                sideAGrid.Visibility = Visibility.Visible;
                sideBGrid.Visibility = Visibility.Hidden;
                sideHGrid.Visibility = Visibility.Visible;
            }
        }

        private void personalData_OcenaValueChanged(object sender, Custom.Controls.personalData.personalDataEventArgs e)
        {
            //zapisywanie informacji do bazy danych

            using (konwenterBazaEntities2 context = new konwenterBazaEntities2())
            {
                Visitors1 newtest = new Visitors1()
                {
                    Imie = e.FirstName,
                    Nazwisko = e.LastName,
                    Wiek= int.Parse(e.Age)
                };
                context.Visitors1.Add(newtest);
                context.SaveChanges();
            }

        }

        private  void DisplayPersonalData()
        {
           
            using (konwenterBazaEntities2 context = new konwenterBazaEntities2())
            {
                List<Visitors1> dane_wszystkie = context.Visitors1.ToList();

                Dispatcher.Invoke(() =>
                {
                    daneDataGrid.ItemsSource = dane_wszystkie;
                    daneDataGrid.ItemsSource = dane_wszystkie.OrderByDescending(el => el.id);
                    daneDataGrid.ItemsSource = dane_wszystkie.Take(20);
                });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t2 = new Task(() => DisplayPersonalData());
            t2.Start();
        }
    }
}
