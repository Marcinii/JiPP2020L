using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace Project.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            InputValue.Focus();
            InputValue.SelectAll();
        }

        private static System.Timers.Timer TimerClock;
        
        protected void ConverterInitialize(object sender,RoutedEventArgs e)
        {
            string inputT = InputValue.Text;
            string inputU1 = InputUnit1.Text;
            string inputU2 = InputUnit2.Text;
            int k = 0, j = 0, tempLength = inputT.Length - 3,timeV = 0;
            Object Temp = sender;
            Clock WindowClock = new Clock();

            List<IKonwerter> Konwertery = new ConverterService().GetConverters();

            

            foreach (IKonwerter I in Konwertery)
            {
                foreach (string t in I.Units)
                {
                    if (inputU1 == t)
                    {
                        foreach (string b in I.Units)
                        {

                            if (inputU2 == b)
                            {
                                if (I != Konwertery[4])
                                {
                                    Output.Text = "Wartość otrzymana z " + inputU1 + " do " + inputU2 + " to " + I.VarUnit(Convert.ToDouble(inputT), k).ToString();
                                }
                                else
                                {
                                    if ((((Convert.ToInt32(inputT.Remove(2)) > 10) && (Convert.ToInt32(inputT.Remove(2)) <= 12)) || (Convert.ToInt32(inputT.Remove(2)) > 22)) && (inputU2 == ""))
                                    {
                                        inputT = "Wartość otrzymana to " + I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1)), k).ToString().Insert(I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1)), k).ToString().Length - 2, ":");
                                    }
                                    else if (((Convert.ToInt32(inputT.Remove(2)) < 10) || ((Convert.ToInt32(inputT.Remove(2)) > 12) && (Convert.ToInt32(inputT.Remove(2)) < 22))) && (inputU2 == ""))
                                    {
                                        inputT = "Wartość otrzymana to " + I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1)), k).ToString().Insert(I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1)), k).ToString().Length - 2, ":").Insert(0, "0");
                                    }
                                    if (inputU1 == "AM/PM")
                                    {
                                        if (Convert.ToInt32(InputValue.Text.Remove(2, 1)) < 1200)
                                        {
                                            Output.Text = inputT + " AM";
                                            WindowClock.AmPmDisplay.Text = "AM";
                                            
                                        }
                                        else
                                        {
                                            Output.Text = inputT + " PM";
                                            WindowClock.AmPmDisplay.Text = "PM";
                                        }
                                        WindowClock.AmPmDisplayLabel.Visibility = Visibility.Visible;
                                        timeV = 96000 * Convert.ToInt32(InputValue.Text.Remove(2)) / 24 + 4000 * Convert.ToInt32(InputValue.Text.Substring(3, 2)) / 60;
                                    }
                                    else if (inputU2 == "AM/PM")
                                    {
                                        if ((inputT.Remove(0, inputT.Length - 2) == "AM") || (inputT.Remove(0, inputT.Length - 2) == "am"))
                                        {
                                            inputT = "Wartość otrzymana to " + I.VarUnit(Convert.ToDouble((inputT.Remove(2, 1)).Remove(tempLength)), 1).ToString().Insert(I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1).Remove(tempLength)), 1).ToString().Length - 2, ":");
                                            if (inputT.Length == 25) inputT = inputT.Insert(21, "0");
                                            timeV = 96000 * Convert.ToInt32(InputValue.Text.Remove(2)) / 24 + 4000 * Convert.ToInt32(InputValue.Text.Substring(3, 2)) / 60;
                                        }
                                        else if ((inputT.Remove(0, inputT.Length - 2) == "PM") || (inputT.Remove(0, inputT.Length - 2) == "pm"))
                                        {
                                            inputT = "Wartość otrzymana to " + I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1).Remove(tempLength)), 2).ToString().Insert(I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1).Remove(tempLength)), 2).ToString().Length - 2, ":");
                                            if (inputT.Length == 24) inputT = inputT.Insert(21, "00");
                                            timeV = 96000 * Convert.ToInt32(InputValue.Text.Remove(2)) / 24 + 4000 * Convert.ToInt32(InputValue.Text.Substring(3, 2)) / 60 + 96000/2;
                                        }

                                        Output.Text = inputT;
                                    }
                                    
                                    WindowClock.Left = this.Left + this.Width;
                                    WindowClock.Top = this.Top + (this.Height - this.Height) / 2;
                                    WindowClock.Show();
                                    TimerClock = new System.Timers.Timer(timeV);
                                    TimerClock.Elapsed += WindowClock.OnTimerClock_Elapsed;
                                    WindowClock.Closing += OnWindowClock_Closed;
                                    TimerClock.Start();
                                    
                                    
                                }
                            }
                            if (t != b) k++;

                        }

                    }
                    j++;
                    k = (I.Units.Count - 1) * j;
                }
                k = 0;
                j = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConverterInitialize(sender,e);
        }
    

        private void OnKeyPress(object sender, KeyEventArgs e)
        {
           
            if (e.Key == Key.Enter)
            {
                ConverterInitialize(sender,e);
            }
            else if(e.Key == Key.Escape)
            {
                
                this.Close();
                
            }
        }

        public void OnGotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            Output.Text = "Do obsługiwanych obecnie jednostek należą: km, mi, cbl, °C, °F, °R, W, KM, BTU/h, kg, f, st. Aby konwertować czas wpisz w pole jednostki AM/PM.";
        }
      

        public void OnWindowClock_Closed(object sender,EventArgs e)
        {
            
            InputValue.GotFocus += OnGotKeyboardFocus;
            InputValue.Focus();
            InputValue.SelectAll();
        }

        public static void DisplayDataUsingADONET()
        {
            using (SqlConnection connection =
                    new SqlConnection("Data Source=localhost;Initial Catalog=ConverterData;Integrated Security=True"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Converters", connection);

                IDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Console.WriteLine();
                }
            }
        }
    }
}

