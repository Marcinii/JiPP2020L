using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using FunctionDrawer.Logic;
using FunctionDrawer.Database;
using System.Threading;

namespace Zadanie7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<IPolynomial> FunctionList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FunctionList = new List<IPolynomial>()
            {
                new Linear(),
                new Quadratic(),
                new Logarithmic()
            };
            FunctionList.ForEach(x =>
            {
                FunctionComboBox.Items.Add(x.GetType().ToString().Split('.')[2]);
            });
            FunctionComboBox.SelectedIndex = 0;
            MainGrid.Cursor = Cursor;
        }

        private async void CalculateButtonClick(object sender, RoutedEventArgs e)
        {
            PlotC.ResetPlot();
            WaitCanvas.Visibility = Visibility.Visible;
            IPolynomial ipl = FunctionList[FunctionComboBox.SelectedIndex];
            List<double> prms = new List<double>();

            foreach (object el in PrmGrid.Children)
            {
                if (!(el is TextBox)) continue;
                TextBox txb = (TextBox)el;
                if (double.TryParse(txb.Text, out double prm)) prms.Add(prm);
                else if (txb.Text == "") prms.Add(0);
                else
                {
                    MessageBox.Show("Insert correct parameter");
                    return;
                }
            }

            if (!double.TryParse(FieldTo.Text, out double ft) || !double.TryParse(FieldFrom.Text, out double ff))
            {
                MessageBox.Show("Insert correct range");
                return;
            }

            var t = Task.Run(async () =>
            {
                await Task.Delay(5000);
                ipl.Calculate(ff, ft, prms);
                Dispatcher.Invoke(() =>
                {
                    foreach (PlotPoint plotValue in ipl.PlotPoints)
                    {
                        PlotC.AddToThePlot(plotValue.X, plotValue.Y);
                    }
                });
            });
            await Task.Factory.StartNew(() =>
            {
                int i = 2;
                Dispatcher.Invoke(async () =>
                {
                    while (!t.IsCompleted)
                    {
                        LoadingMark.StrokeThickness = i;
                        if (i == 50) i = 2;
                        i++;
                        await Task.Delay(10);
                    }
                    WaitCanvas.Visibility = Visibility.Hidden;
                });
            });
            await DatabaseIO.AddToDatabaseAsync(FunctionComboBox.Text, prms);
        }
        private void OnResetClick(object sender, RoutedEventArgs e)
        {
            PlotC.ResetPlot();
        }

        private async void LoadLastUsedButton_Click(object sender, RoutedEventArgs e)
        {
            List<UsedPolynomial> up;
            up = await DatabaseIO.LoadFromDatabaseAsync();
            LastUsed.ItemsSource = up;
        }

        private void FunctionComboBox_DropDownClosed(object sender, EventArgs e)
        {
            IPolynomial ipl = FunctionList[FunctionComboBox.SelectedIndex];
            InfoBox.Text = ipl.Info;
        }
    }
}
