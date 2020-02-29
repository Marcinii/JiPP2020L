using System;
using System.Windows;
using UnitConverterLogic;
using UnitConverterLogic.Model;
using UnitConverterLogic.Plugins;


namespace UnitConverterWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            InitializeValues();
            
            
        }

        WeightConverter Weight = new WeightConverter();
        LenghtConverter Lenght = new LenghtConverter();
        TempConverter Temp = new TempConverter();
        sqlconnectionEntities context = new sqlconnectionEntities();
        NPBProcessor proces = new NPBProcessor();
        public void InitializeValues()
        {

            string[] CategoryList = new string[] { "Masa", "Odległość", "Temperatura" };
            string[] MassList = new string[] { "kg", "g" };
            string[] LenghtList = new string[] { "km", "m" };
            string[] TempList = new string[] { "C", "K" };

            CurrentNBP.Text = proces.Testnbp();
            CategoryCB.ItemsSource = CategoryList;
            
            if(CategoryCB.SelectedItem=="Masa")
            {
                UnitFromCB.ItemsSource = MassList;
                UnitFromCB.SelectedIndex = 0;
                UnitToCB.ItemsSource = MassList;
                UnitToCB.SelectedIndex = 1;
            }
            if (CategoryCB.SelectedItem == "Odległość")

            {
                UnitFromCB.ItemsSource = LenghtList;
                UnitFromCB.SelectedIndex = 0;
                UnitToCB.ItemsSource = LenghtList;
                UnitToCB.SelectedIndex = 1;
            }
            if (CategoryCB.SelectedItem == "Temperatura")

            {
                UnitFromCB.ItemsSource = TempList;
                UnitFromCB.SelectedIndex = 0;
                UnitToCB.ItemsSource = TempList;
                UnitToCB.SelectedIndex = 1;
            }
        }
        private void CategoryCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            InitializeValues();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryCB.SelectedItem == "Masa")
            {
                ResultTextBox.Text = Convert.ToString(Weight.Converter(InputTextBox.Text, UnitFromCB.Text, UnitToCB.Text));
                SendStatistics();
            }
            if (CategoryCB.SelectedItem == "Odległość")
            {
                ResultTextBox.Text = Convert.ToString(Lenght.Converter(InputTextBox.Text, UnitFromCB.Text, UnitToCB.Text));
                SendStatistics();
            }
            if (CategoryCB.SelectedItem == "Temperatura")
            {
                ResultTextBox.Text = Convert.ToString(Temp.Converter(InputTextBox.Text, UnitFromCB.Text, UnitToCB.Text));
                SendStatistics();
            }


        }
        public void FillDataGrid()
        {

            //this.DataGrid.ItemsSource = repository.GetStatistics();
            //List<DataRow> list = new List<DataRow>();
            //IEnumerable < DataRow > sequence = dt.AsEnumerable();
            


        }

        public void SendStatistics()
        {
            Statistic statistic = new Statistic();
            {
                statistic.ConvertedValue = int.Parse(ResultTextBox.Text);
                statistic.UnitFrom = UnitFromCB.Text;
                statistic.UnitTo = UnitToCB.Text;                
                statistic.DateTime = DateTime.Now;
                statistic.Type = CategoryCB.Text;
                statistic.RawValue = int.Parse(InputTextBox.Text);
            }
            context.Add(statistic);

            context.SaveChanges();
        }
    }

}
