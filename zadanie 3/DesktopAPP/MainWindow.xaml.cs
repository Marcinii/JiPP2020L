using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using przelicznik;
using przelicznik.Logic;

namespace DesktopAPP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int clock = 0;
        

        public MainWindow()
        {

            InitializeComponent();
            convCombobox.ItemsSource = new KonwerterService().GetConverters();
            
            
        }
        public void saveinDatabase()
        {

            DATABASE.insertdatausingEF();
        }
        public void DisplayData()
        {
            DATABASE.DisplayDataUsingEF();
        

        }
        private void convCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFrombox.ItemsSource = ((IConverter)convCombobox.SelectedItem).Units;
            unitTobox.ItemsSource = ((IConverter)convCombobox.SelectedItem).Units;
           
             



        }
        private void clockbutton_Click(object sender, RoutedEventArgs e)
        {
           
           
            dwukropektext.Text = ":";
            minutybox.Visibility = 0;
            minutesb.Visibility = 0;
            clock = 1;
           

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           


            string inputText = inputTextBox.Text;
            decimal inputValue = decimal.Parse(inputText);
            decimal result = ((IConverter)convCombobox.SelectedItem).Convert(
                unitFrombox.SelectedItem.ToString(),
                unitTobox.SelectedItem.ToString(),
                inputValue);

            unitFrombox.SelectedItem.ToString();

            outputText.Text = result.ToString();
            if (clock == 1)
            {
                if (inputValue < 12)
                {
                    clocktextblock.Text = "AM";                  
                }
                if (inputValue >= 12)
                {
                    clocktextblock.Text = "PM";                   
                }
                minutesb.Text = ":" + minutybox.Text;
                double min = Decimal.ToInt32(result)*30 + ((Convert.ToDouble(minutybox.Text) * 0.5));             
                clockRotation.Angle = min+90;


                ((Storyboard)Resources["Storyboard1"]).Begin();
               

                using (companydataEntities1 context = new companydataEntities1())
                {
                    tabelakonw newbaza001 = new tabelakonw()
                    {
                        konwerter = "a",
                        UnitFrom = "b",
                        UnitTo = "c",
                        inputValue = "c",
                        outputValue = "c",
                        time = DateTime.Now,

                    };
                    context.tabelakonw.Add(newbaza001);
                    context.SaveChanges();
                }

            }
        }



    

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void unitFrombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}

