using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using Modul2;

namespace UnitConverter.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            chooseConverter.ItemsSource = new List<string>()
            {
                "(1) Temps",
                "(2) Distance",
                "(3) Weight",
                "(4) Bytes"
            };
        }
        // asd

        private void chooseConverter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(chooseConverter.SelectedItem == "(1) Temps")
            {
                chooseUnitFrom.ItemsSource = new List<string>()
                {
                "C",
                "F",
                "K"
                };
            }
            else if (chooseConverter.SelectedItem == "(2) Distance")
            {
                chooseUnitFrom.ItemsSource = new List<string>()
                {
                "KM",
                "MI"
                };
            }
            else if (chooseConverter.SelectedItem == "(3) Weight")
            {
                chooseUnitFrom.ItemsSource = new List<string>()
                {
                "KG",
                "LB"
                };
            }
            else if (chooseConverter.SelectedItem == "(4) Bytes")
            {
                chooseUnitFrom.ItemsSource = new List<string>()
                {
                "GB",
                "MB"
                };
            }

        }

        private void chooseUnitFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseUnitFrom.SelectedItem == "C")
            {
                chooseUnitTo.ItemsSource = new List<string>()
                {
                "F",
                "K"
                };
            }
            else if (chooseUnitFrom.SelectedItem == "K")
            {
                chooseUnitTo.ItemsSource = new List<string>()
                {
                "C",
                "F"
                };
            }
            else if (chooseUnitFrom.SelectedItem == "F")
            {
                chooseUnitTo.ItemsSource = new List<string>()
                {
                "C",
                "K"
                };
            }
            else if (chooseUnitFrom.SelectedItem == "KM")
            {
                chooseUnitTo.ItemsSource = new List<string>()
                {
                "MI"
                };

            }
            else if (chooseUnitFrom.SelectedItem == "MI")
            {
                chooseUnitTo.ItemsSource = new List<string>()
                {
                "KM"
                };

            }
            else if (chooseUnitFrom.SelectedItem == "KG")
            {
                chooseUnitTo.ItemsSource = new List<string>()
                {
                "LB"
                };

            }
            else if (chooseUnitFrom.SelectedItem == "LB")
            {
                chooseUnitTo.ItemsSource = new List<string>()
                {
                "KG"
                };

            }
            else if (chooseUnitFrom.SelectedItem == "GB")
            {
                chooseUnitTo.ItemsSource = new List<string>()
                {
                "MB"
                };

            }
            else if (chooseUnitFrom.SelectedItem == "MB")
            {
                chooseUnitTo.ItemsSource = new List<string>()
                {
                "GB"
                };

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<IConverter> converters = new List<IConverter>()
            {
                new TempConverter(),
                new DistConverter(),
                new WeightConverter(),
                new BytesConverter()
            };

            int choice=0;
            
            if (chooseConverter.SelectedItem == "(1) Temps")
            {
                choice = 0;
            }

            else if (chooseConverter.SelectedItem == "(2) Distance")
            {
                choice = 1;
            }

            else if (chooseConverter.SelectedItem == "(3) Weight")
            {
                choice = 2;
            }
            else if (chooseConverter.SelectedItem == "(4) Bytes")
            {
                choice = 3;
            }

            string unitFrom = chooseUnitFrom.Text;
            string unitTo = chooseUnitTo.Text;


            string valueString = UnitValue.Text;
            double value = double.Parse(valueString);

            double result = Math.Round(converters[choice].Convert(unitFrom, unitTo, value),2);

            MessageBox.Show(value.ToString() + " " + unitFrom + " = " + result.ToString() + " " + unitTo);
            


        }
    }
}
