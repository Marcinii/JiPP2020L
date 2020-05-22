using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using Modul2;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Data.OleDb;
using System.Threading;

namespace UnitConverter.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            imageWait.Visibility = Visibility.Hidden;
            imageWait2.Visibility = Visibility.Hidden;

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Baza\Database.accdb; Persist Security Info = False;";
            connection.Open();
            OleDbCommand readRecords = new OleDbCommand();
            readRecords.CommandText = "SELECT TOP 20 * FROM [converted]";
            readRecords.Connection = connection;
            OleDbDataReader rd = readRecords.ExecuteReader();
            grid1.ItemsSource = rd;

            chooseSortBy.ItemsSource = new List<string>()
            {
                "(1) Temps",
                "(2) Distance",
                "(3) Weight",
                "(4) Bytes",
                "(5) All"
            };


            chooseConverter.ItemsSource = new List<string>()
            {
                "(1) Temps",
                "(2) Distance",
                "(3) Weight",
                "(4) Bytes"
            };

            hourBox.ItemsSource = new List<string>()
            {
                "00","01","02","03","04","05","06","07","08","09","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24"
            };

            minuteBox.ItemsSource = new List<string>()
            {
                "00","01","02","03","04","05","06","07","08","09","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50","51","52","53","54","55","56","57","58","59"
            };
        }


        private void chooseConverter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseConverter.SelectedItem == "(1) Temps")
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

            if (chooseConverter.Text != "" & chooseUnitFrom.Text != "" & chooseUnitTo.Text != "" & UnitValue.Text != "")
            {

                List<IConverter> converters = new List<IConverter>()
                {
                new TempConverter(),
                new DistConverter(),
                new WeightConverter(),
                new BytesConverter()
                };

                int choice = 0;

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

                double result = Math.Round(converters[choice].Convert(unitFrom, unitTo, value), 2);
                
                DateTime now = DateTime.Now;
                string actualTime = now.ToString("dd/MM/yyyy HH:mm:ss");

                MessageBox.Show(value.ToString() + " " + unitFrom + " = " + result.ToString() + " " + unitTo);

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Baza\Database.accdb; Persist Security Info = False;";
                connection.Open();
                OleDbCommand addRecord = new OleDbCommand();
                addRecord.Connection = connection;
                addRecord.CommandText = "insert into converted (Converter_type, Unit_from, Unit_to, Value_from, Value_to, Date_of_conversion) values('" + chooseConverter.Text + "','" + chooseUnitFrom.Text + "','" + chooseUnitTo.Text + "','"  + UnitValue.Text + "','" + result + "','" + actualTime + "')";
                addRecord.ExecuteNonQuery();
                connection.Close();
                
                
            }
            else
            {
                MessageBox.Show("Fill every box to convert!");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (hourBox.Text != "" & minuteBox.Text != "")
            {

                string time24 = hourBox.Text + ":" + minuteBox.Text;
                DateTime dt = DateTime.ParseExact(time24, "HH:mm", null, DateTimeStyles.None);
                string time12 = dt.ToString("hh:mm tt");
                MessageBox.Show(time12);

                string hour12 = dt.ToString("hh");
                string minute12 = dt.ToString("mm");
                double hr = double.Parse(hour12);
                double min = double.Parse(minute12);

                string hour24 = dt.ToString("HH");
                double hr24 = double.Parse(hour24);



                minute.LayoutTransform = new RotateTransform(min * 360 / 60);
                hour.LayoutTransform = new RotateTransform(hr * 360 / 12);

                if (hr24 > 6 & hr24 < 20)
                {
                    DoubleAnimation da = new DoubleAnimation
                    (360, 0, new Duration(TimeSpan.FromSeconds(10)));
                    RotateTransform rt = new RotateTransform();
                    imageSun.RenderTransform = rt;
                    imageSun.RenderTransformOrigin = new Point(0.5, 0.5);
                    rt.BeginAnimation(RotateTransform.AngleProperty, da);

                }
                else
                {
                    DoubleAnimation da = new DoubleAnimation
                    (360, 0, new Duration(TimeSpan.FromSeconds(10)));
                    RotateTransform rt = new RotateTransform();
                    imageMoon.RenderTransform = rt;
                    imageMoon.RenderTransformOrigin = new Point(0.5, 0.5);
                    rt.BeginAnimation(RotateTransform.AngleProperty, da);
                }



            }
            else
            {
                MessageBox.Show("Fill every box to convert!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string sortValue = chooseSortBy.Text;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Baza\Database.accdb; Persist Security Info = False;";
            connection.Open();
            OleDbCommand readRecords = new OleDbCommand();
            if (sortValue == "(5) All")
            {
                readRecords.CommandText = "SELECT TOP 20 * FROM [converted]";
            }
            else
            {
                readRecords.CommandText = "SELECT TOP 20 * FROM [converted] WHERE [Converter_type] ='" + sortValue + "'";
            }
                readRecords.Connection = connection;
            OleDbDataReader rd = readRecords.ExecuteReader();
            grid1.ItemsSource = rd;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            imageWait2.Visibility = Visibility.Visible;
           
            DoubleAnimation da = new DoubleAnimation
            (360, 0, new Duration(TimeSpan.FromSeconds(5)));
            RotateTransform rt = new RotateTransform();
            imageWait2.RenderTransform = rt;
            imageWait2.RenderTransformOrigin = new Point(0.5, 0.5);
            rt.BeginAnimation(RotateTransform.AngleProperty, da);

            Thread thread = new Thread(() => action());
            thread.Start();

        }

        private void action()
        {

            Thread.Sleep(5000);
            Dispatcher.Invoke(() =>
            {
            
            refreshGrid();
            imageWait2.Visibility = Visibility.Hidden;

            });
        }
        
        private void refreshGrid()
        {
            string dateFromVal = dateFrom.Text;
            string dateToVal = dateTo.Text;
            string sortValue = chooseSortBy.Text;

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Baza\Database.accdb; Persist Security Info = False;";
            connection.Open();
            OleDbCommand readRecords = new OleDbCommand();
            OleDbCommand whichMost = new OleDbCommand();

            if (sortValue == "(5) All" & dateFromVal == "" & dateToVal == "")
            {
                readRecords.CommandText = "SELECT TOP 20 * FROM [converted]";
                whichMost.CommandText = 
                  
                    "SELECT TOP 3 converted.[Unit_from] + \" -> \" + [Unit_to] AS Conversion, " +
                    "Count(converted.[Unit_from] + \" -> \" + [Unit_to]) AS Countof " +
                    "FROM converted GROUP BY converted.[Unit_from] + \" -> \" +[Unit_to] " +
                    "Order by Count(converted.[Unit_from]+\"-> \"+[Unit_to]) DESC";
            }
            else if (sortValue != "(5) All" & dateFromVal == "" & dateToVal == "")
            {
                readRecords.CommandText = "SELECT TOP 20 * FROM [converted] WHERE [Converter_type] ='" + sortValue + "'";
                whichMost.CommandText = 
                    
                    "SELECT TOP 3 converted.[Unit_from] + \" -> \" + [Unit_to] AS Conversion, " +
                    "Count(converted.[Unit_from] + \" -> \" + [Unit_to]) AS Countof " +
                    "FROM converted WHERE [Converter_type] ='" + sortValue + "' " +
                    "GROUP BY converted.[Unit_from] + \" -> \" +[Unit_to] " +
                    "Order by Count(converted.[Unit_from]+\"-> \"+[Unit_to]) DESC";
            }
            else if (sortValue == "(5) All" & dateFromVal != "" & dateToVal != "")
            {
                readRecords.CommandText = "SELECT TOP 20 * FROM [converted] WHERE(((converted.Date_of_conversion) >=#" + dateFromVal + "# And (converted.Date_of_conversion)<=#" + dateToVal + "#))";
                whichMost.CommandText = 
                    
                    "SELECT TOP 3converted.[Unit_from] + \" -> \" +[Unit_to] AS Conversion, " +
                    "Count(converted.[Unit_from] + \" -> \" +[Unit_to]) AS Countof " +
                    "FROM converted WHERE(((converted.Date_of_conversion) >=#" + dateFromVal + "# And (converted.Date_of_conversion)<=#" + dateToVal + "#)) " +
                    "GROUP BY converted.[Unit_from] + \" -> \" +[Unit_to] " +
                    "Order by Count(converted.[Unit_from]+\"-> \"+[Unit_to]) DESC";
            }
            else if (sortValue != "(5) All" & dateFromVal != "" & dateToVal != "")
            {
                readRecords.CommandText = "SELECT TOP 20 * FROM [converted] WHERE [Converter_type] ='" + sortValue + "' And(((converted.Date_of_conversion) >=#" + dateFromVal + "# And (converted.Date_of_conversion)<=#" + dateToVal + "#))";
                whichMost.CommandText = "SELECT TOP 3 converted.[Unit_from] + \" -> \" +[Unit_to] AS Conversion, " +
                    "Count(converted.[Unit_from] + \" -> \" +[Unit_to]) AS Countof " +
                    "FROM converted WHERE [Converter_type] ='" + sortValue + "' And (((converted.Date_of_conversion) >=#" + dateFromVal + "# And (converted.Date_of_conversion)<=#" + dateToVal + "#)) " +
                    "GROUP BY converted.[Unit_from] + \" -> \" +[Unit_to] " +
                    "Order by Count(converted.[Unit_from]+\"-> \"+[Unit_to]) DESC";
            }



            whichMost.Connection = connection;
            readRecords.Connection = connection;
            OleDbDataReader rd = readRecords.ExecuteReader();
            OleDbDataReader wm = whichMost.ExecuteReader();
            grid1.ItemsSource = rd;
            grid2.ItemsSource = wm;
        }



        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}