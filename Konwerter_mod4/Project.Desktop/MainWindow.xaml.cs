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
using Project.Logic;

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
            SetPosition();
            InputValue.Focus();
            InputValue.SelectAll();
            if(Button2.Content.ToString() == "Utwórz tabelę")
            {
                Button2.Click += Button2_Click_1;
            }
            else 
            {
                Button2.Click -= Button2_Click_1;
                Button2.Click += Button2_Click_2;
            }
        }

        private static System.Timers.Timer TimerClock;
        
        protected void ConverterInitialize(object sender,RoutedEventArgs e)
        {
            string inputT = InputValue.Text;
            string inputU1 = InputUnit1.Text;
            string inputU2 = InputUnit2.Text;
            string ConverterName = "", sValue = "";
            int k = 0, j = 0, tempLength = inputT.Length - 3,timeV = 0,Rating = -1;
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
                                    sValue = I.VarUnit(Convert.ToDouble(inputT), k).ToString();
                                }
                                else
                                {
                                    if ((((Convert.ToInt32(inputT.Remove(2)) > 10) && (Convert.ToInt32(inputT.Remove(2)) <= 12)) || (Convert.ToInt32(inputT.Remove(2)) > 22)) && (inputU2 == ""))
                                    {
                                        sValue = I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1)), k).ToString().Insert(I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1)), k).ToString().Length - 2, ":");
                                        inputT = "Wartość otrzymana to " + I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1)), k).ToString().Insert(I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1)), k).ToString().Length - 2, ":");
                                    }
                                    else if (((Convert.ToInt32(inputT.Remove(2)) < 10) || ((Convert.ToInt32(inputT.Remove(2)) > 12) && (Convert.ToInt32(inputT.Remove(2)) < 22))) && (inputU2 == ""))
                                    {
                                        sValue = I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1)), k).ToString().Insert(I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1)), k).ToString().Length - 2, ":").Insert(0, "0");
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
                                            sValue = I.VarUnit(Convert.ToDouble((inputT.Remove(2, 1)).Remove(tempLength)), 1).ToString().Insert(I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1).Remove(tempLength)), 1).ToString().Length - 2, ":");
                                            inputT = "Wartość otrzymana to " + I.VarUnit(Convert.ToDouble((inputT.Remove(2, 1)).Remove(tempLength)), 1).ToString().Insert(I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1).Remove(tempLength)), 1).ToString().Length - 2, ":");
                                            if (inputT.Length == 25) inputT = inputT.Insert(21, "0");
                                            timeV = 96000 * Convert.ToInt32(InputValue.Text.Remove(2)) / 24 + 4000 * Convert.ToInt32(InputValue.Text.Substring(3, 2)) / 60;
                                        }
                                        else if ((inputT.Remove(0, inputT.Length - 2) == "PM") || (inputT.Remove(0, inputT.Length - 2) == "pm"))
                                        {
                                            sValue = I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1).Remove(tempLength)), 2).ToString().Insert(I.VarUnit(Convert.ToDouble(inputT.Remove(2, 1).Remove(tempLength)), 2).ToString().Length - 2, ":");
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
                                ConverterName = I.Name;
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
            SaveDataToConverters(ConverterName,inputU1,inputU2,sValue,Rating);
        }

        private void SetPosition()
        {
            this.Left = 110;
            this.Top = 110;
            this.MinHeight = this.Height;
            this.MinWidth = this.Width;
            this.MaxHeight = this.Height;
            this.MaxWidth = this.Width;
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

        public static void SaveDataToConverters(string C_Type, string U_from, string U_to, string C_Value, int? R_Value)
        {
            int ID = 0;
            DateTime date = DateTime.Now;
            if (R_Value == -1) R_Value = null;
            using (ConverterData context = new ConverterData())
            {
                
                foreach (Converter i in context.Converters.ToList()) ID++;
                context.Converters.Add(new Converter()
                {
                    ID_Converter = ID + 1,
                    Converter_Type = C_Type,
                    Unit_from = U_from,
                    Unit_to = U_to,
                    Date_of_Conversion = date,
                    Converted_Value = C_Value,
                    Rating_Value = R_Value
                }
                    );



                context.SaveChanges();
                
                
            }
        }

        private void Button2_Click_1(object sender, RoutedEventArgs e)
        {
            Database WindowData = new Database(this);
            WindowData.Show();
            Button2.Content = "Aktualizuj tabelę";
            Button.Click += OnButtonClickWhileDGActive;
            InputUnit2.KeyDown += OnKeyPressWhileDGActive;
            //WindowData.Loaded += new RoutedEventHandler
            

            
        }

        private void Button2_Click_2(object sender, RoutedEventArgs e)
        {

        }
        
        private void OnButtonClickWhileDGActive(object sender, RoutedEventArgs e)
        {
            
        }

        private void OnKeyPressWhileDGActive(object sender, KeyEventArgs e)
        {

        }
    }
}

