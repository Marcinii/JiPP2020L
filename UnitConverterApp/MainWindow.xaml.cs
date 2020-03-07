using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using UnitConverter.Core;
using UnitConverter.OperationUtil;
using UnitConverter.UnitUtil;

namespace UnitConverterApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private OperationRepository operationRepository;
        private Operation operation;
        private Unit fromUnit;
        private Unit toUnit;

        public MainWindow()
        {
            InitializeComponent();
            this.operationRepository = new OperationRepository();
            OperationRepositoryInitializer.initializeRepository(this.operationRepository);


            this.providedValueTextBox.IsEnabled = false;
            this.fromValueListBox.IsEnabled = false;
            this.toValueListBox.IsEnabled = false;

            this.operationRepository.operations.ForEach(operation =>
            {
                this.measurementUnitComboBox.Items.Add(operation.name);
            });
        }

        private void measurementUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.providedValueTextBox.IsEnabled = false;
            this.providedValueTextBox.Text = "";
            this.fromValueListBox.IsEnabled = true;
            this.toValueListBox.IsEnabled = true;
            this.fromUnit = null;
            this.toUnit = null;

            this.convertedValueGrid.Visibility = Visibility.Hidden;

            this.operation = this.operationRepository.operations[this.measurementUnitComboBox.SelectedIndex];

            this.fromValueListBox.Items.Clear();
            this.toValueListBox.Items.Clear();
            this.operation.units.ForEach(unit =>
            {
                this.fromValueListBox.Items.Add(unit.name);
                this.toValueListBox.Items.Add(unit.name);
            });
        }

        private void fromValueListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.fromValueListBox.SelectedIndex < 0)
                return;

            this.fromUnit = this.operation.units[this.fromValueListBox.SelectedIndex];
            if(this.toUnit != null)
            {
                this.providedValueTextBox.IsEnabled = true;

                if(this.providedValueTextBox.Text != "")
                {
                    this.convertedValueLabel.Content = this.operation.convert(
                        Convert.ToDouble(this.providedValueTextBox.Text),
                        this.fromUnit,
                        this.toUnit
                    );
                }
            }
        }

        private void toValueListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.toValueListBox.SelectedIndex < 0)
                return;

            this.toUnit = this.operation.units[this.toValueListBox.SelectedIndex];
            if (this.fromUnit != null)
            {
                this.providedValueTextBox.IsEnabled = true;

                if (this.providedValueTextBox.Text != "")
                {
                    this.convertedValueLabel.Content = this.operation.convert(
                        Convert.ToDouble(this.providedValueTextBox.Text),
                        this.fromUnit,
                        this.toUnit
                    );
                }
            }
        }

        private void providedValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = this.providedValueTextBox.Text;

            if(value == null || value == "")
            {
                this.convertedValueLabel.Content = "0";
                this.providedValueTextBox.Background = Brushes.White;
            }
            else if(!Regex.IsMatch(value, @"^[-]?[0-9]+(\\.[0-9]+)?$"))
            {
                this.providedValueTextBox.Background = Brushes.Red;
            }
            else
            {
                this.providedValueTextBox.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFABADB3");
                this.providedValueTextBox.Background = Brushes.White;
                this.convertedValueGrid.Visibility = Visibility.Visible;
                this.convertedValueLabel.Content = this.operation.convert(
                    Convert.ToDouble(this.providedValueTextBox.Text),
                    this.fromUnit,
                    this.toUnit
                );
            }
        }
    }
}
