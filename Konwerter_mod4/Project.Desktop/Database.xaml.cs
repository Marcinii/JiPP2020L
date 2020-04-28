using Project.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Project.Desktop
{
    /// <summary>
    /// Interaction logic for Database.xaml
    /// </summary>
    public partial class Database : Window
    {
        public Database(MainWindow mainWindow)
        {
            this.Loaded += SetTableToFill;
            ConverterService = new ConverterService();
            CList = new List<Converter>();
            this.Left = mainWindow.Left;
            this.Top = mainWindow.Top + mainWindow.Height;

            using(ConverterData context = new ConverterData())
            {
                List<Converter> Converters = context.Converters.ToList();

                foreach(Converter i in Converters)
                {
                    CList.Add(i);
                }
            }
            DataContext = this;
            InitializeComponent();
            foreach(IKonwerter I in ConverterService.GetConverters())
            {
                ConverterBox.Items.Add(I.Name);
            }
            this.CLView = CollectionViewSource.GetDefaultView(CList);
            UserData.ItemsSource = this.CLView;
            DatabaseCal.Visibility = Visibility.Collapsed;
            ConverterBox.SelectionChanged += FilterUD;
            // Adjusting the cursor/caret by creating a new one
            /*TextBox1.SelectionChanged += (sender, e) => MoveCustomCaret1();
            TextBox1.LostFocus += (sender, e) => Cursor1.Visibility = Visibility.Collapsed;
            TextBox1.GotFocus += (sender, e) => Cursor1.Visibility = Visibility.Visible;
            TextBox2.SelectionChanged += (sender, e) => MoveCustomCaret2();
            TextBox2.LostFocus += (sender, e) => Cursor1.Visibility = Visibility.Collapsed;
            TextBox2.GotFocus += (sender, e) => Cursor1.Visibility = Visibility.Visible;*/
        }

        List<Converter> CList { get; set; }
        ICollectionView CLView;
        ConverterService ConverterService;
        

        // Methods to polish the display

        /*void MoveCustomCaret1()
        {
            var caretLocation = TextBox1.GetRectFromCharacterIndex(TextBox1.CaretIndex).Location;
            if(!double.IsInfinity(caretLocation.X))
            {
                Canvas.SetLeft(Cursor1, caretLocation.X);
            }
            if(!double.IsInfinity(caretLocation.Y))
            {
                Canvas.SetTop(Cursor1, caretLocation.Y);
            }
        }

        void MoveCustomCaret2()
        {
            var caretLocation = TextBox1.GetRectFromCharacterIndex(TextBox2.CaretIndex).Location;
            if (!double.IsInfinity(caretLocation.X))
            {
                Canvas.SetLeft(Cursor2, caretLocation.X);
            }
            if (!double.IsInfinity(caretLocation.Y))
            {
                Canvas.SetTop(Cursor2, caretLocation.Y);
            }
        }*/

        // Methods for the Table

        void SetTableToFill(object sender, EventArgs e)
        {
            foreach(DataGridColumn column in UserData.Columns)
            {
                column.MinWidth = column.ActualWidth;
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }

            UserData.Height = UserData.ColumnHeaderHeight * (UserData.Items.Count + 1);
        
        }

        void FilterUD(object sender, SelectionChangedEventArgs e)
        {
            string name = ((ComboBox)sender).SelectedItem as string;
            List<Converter> temp = new List<Converter>();
            using(ConverterData context = new ConverterData())
            {
                List<Converter> Converters = context.Converters.ToList();
                //CList.Clear();
                for(int i = 0;i < Converters.Count - 1;i++) // Converter I in Converters)
                {
                    if(name == Converters[i].Converter_Type.Substring(0, Converters[i].Converter_Type.IndexOf(" ", Converters[i].Converter_Type.IndexOf(" ") + 1)))
                    {
                        //temp.Remove(Converters[i]);
                        temp.Add(CList[i]);
                        //CList.Add(CList[i]);
                    }
                }
                this.CLView = CollectionViewSource.GetDefaultView(temp);
                UserData.ItemsSource = this.CLView;
                this.CLView.Refresh();
            }
        }
    }
}
