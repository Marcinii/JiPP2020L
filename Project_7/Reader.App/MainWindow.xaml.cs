using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Data.OleDb;
using System.Threading;
using Microsoft.Win32;
using Project_7;

namespace Reader.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            imageWait.Visibility = Visibility.Hidden;

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Baza\Database.accdb; Persist Security Info = False;";
            connection.Open();
            OleDbCommand readRecords = new OleDbCommand();
            readRecords.CommandText = "SELECT TOP 20 * FROM [counted]";
            readRecords.Connection = connection;
            OleDbDataReader rd = readRecords.ExecuteReader();
            grid1.ItemsSource = rd;

            chooseType.ItemsSource = new List<string>()
            {
                "Words",
                "Characters"
            };

            chooseSort.ItemsSource = new List<string>()
            {
                "All",
                "Words",
                "Characters"
            };
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Text Files (*.txt)|*.txt";
            fileDialog.DefaultExt = ".txt";
            bool? dialogOK = fileDialog.ShowDialog();
            if (dialogOK == true)
            {
                string sFilenames = "";
                foreach (string sFilename in fileDialog.FileNames)
                {
                    sFilenames += ";" + sFilename;
                }
                sFilenames = sFilenames.Substring(1);
                filePath.Text = sFilenames;
            }
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            if(filePath.Text != "")
            {
                List<iCzytnik> czytnik = new List<iCzytnik>()
                {
                new textFile()
                };
                int wynik = czytnik[0].Przelicz(chooseType.Text, filePath.Text);
                value.Text = czytnik[0].Przelicz(chooseType.Text, filePath.Text).ToString() + " " + chooseType.Text;
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Baza\Database.accdb; Persist Security Info = False;";
                connection.Open();
                OleDbCommand addRecord = new OleDbCommand();
                addRecord.Connection = connection;
                addRecord.CommandText = "insert into counted ([FilePath],[Count],[Type]) values ('" + filePath.Text + "','" + wynik + "','" + chooseType.Text + "')";
                addRecord.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Sciezka do pliku nie zostala podana");
            } 
        }


        private void sorting()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Baza\Database.accdb; Persist Security Info = False;";
            connection.Open();
            OleDbCommand readRecords = new OleDbCommand();
            OleDbCommand whichMost = new OleDbCommand();
            if (chooseSort.Text == "All")
            {
                readRecords.CommandText = "SELECT TOP 20 * FROM [counted] ";
                whichMost.CommandText =
                    "SELECT TOP 3 * From counted " +
                    "Order by Count DESC";
            }
            else if (chooseSort.Text == "Words")
            {
                readRecords.CommandText = "SELECT TOP 20 * FROM [counted] WHERE(((counted.Type) = \"Words\"))";
                whichMost.CommandText =
                    "SELECT TOP 3 * From counted " +
                    "WHERE(((counted.Type) = \"Words\")) " +
                    "Order by Count DESC;";
            }
            else if (chooseSort.Text == "Characters")
            {
                readRecords.CommandText = "SELECT TOP 20 * FROM [counted] WHERE(((counted.Type) = \"Characters\"))";
                whichMost.CommandText =
                    "SELECT TOP 3 * From counted " +
                    "WHERE(((counted.Type) = \"Characters\")) " +
                    "Order by Count DESC;";
            }
            whichMost.Connection = connection;
            readRecords.Connection = connection;
            OleDbDataReader rd = readRecords.ExecuteReader();
            OleDbDataReader wm = whichMost.ExecuteReader();
            grid1.ItemsSource = rd;
            grid2.ItemsSource = wm;
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            imageWait.Visibility = Visibility.Visible;
            waitAnimation();
            Thread thread = new Thread(() => action());
            thread.Start();
        }

        private void action()
        {
            Thread.Sleep(5000);
            Dispatcher.Invoke(() =>
            {
                sorting();
                imageWait.Visibility = Visibility.Hidden;

            });
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void waitAnimation()
        {
            DoubleAnimation da = new DoubleAnimation
            (360, 0, new Duration(TimeSpan.FromSeconds(5)));
            RotateTransform rt = new RotateTransform();
            imageWait.RenderTransform = rt;
            imageWait.RenderTransformOrigin = new Point(0.5, 0.5);
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
        }
    }
}
