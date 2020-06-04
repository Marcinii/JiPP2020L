using FinancialSettlementApp.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace FinancialSettlementApp.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PrincipleCombo.ItemsSource = new FaAService().GetOperations();
            StatusCombo.ItemsSource = new List<string>()
            {
                "private",
                "company"
            };

            AddTakingCommand = new RelayCommand(obj => AddTakings(), obj => string.IsNullOrEmpty(AmountBox.Text) != true &&
            string.IsNullOrEmpty(DecriptionBox.Text) != true && string.IsNullOrEmpty(monthValue) != true);
            AddTakingsButton.Command = AddTakingCommand;

            AddCostCommand = new RelayCommand(obj => AddCost(), obj => string.IsNullOrEmpty(AmountBox.Text) != true &&
            string.IsNullOrEmpty(DecriptionBox.Text) != true && string.IsNullOrEmpty(monthValue) != true && StatusCombo.SelectedItem != null);
            AddCostButton.Command = AddCostCommand;

            CalculateCommand = new RelayCommand(obj => Calculate(), obj => PrincipleCombo.SelectedItem !=null && string.IsNullOrEmpty(monthValue) != true);
            CalculateButton.Command = CalculateCommand;
        }

        static string monthValue = "";
        static string operationValue = "";

        private RelayCommand CalculateCommand;
        //private void CalculateButton_Click(object sender, RoutedEventArgs e)
        private void Calculate()
        {
            string typeOfOperation = PrincipleCombo.Text;
            if(typeOfOperation == "FinancialSettlementApp.Logic.GeneralRules")
            {
                Decimal sumOfTaking = TakeSumOfTaking(1);
                Decimal sumOfCost = TakeSumOfCost(1);
                bool discount = (bool)discountCheck.IsChecked;
                string type = "Normal";
                if (discount)
                {
                    type = "Start relief";
                }
                GeneralRules generalRules = new GeneralRules();
                decimal incomeTaxAdvance = generalRules.Calculate(type, sumOfCost, sumOfTaking, monthValue);
               
                ScoreBlock.Text = incomeTaxAdvance.ToString();
                AmountBox.Text = incomeTaxAdvance.ToString();
                DecriptionBox.Text = "Zaliczka na podatek dochodowy";

                startAnimation(sumOfTaking, sumOfCost);
                decimal a = (incomeTaxAdvance / sumOfTaking) * 100m;
                AnswerText.Text = "Zaliczka stanowi " + (Math.Round(a, 0)) + " %";
            } else if (typeOfOperation == "FinancialSettlementApp.Logic.FlatTax")
            {
                Decimal sumOfTaking = TakeSumOfTaking(1);
                Decimal sumOfCost = TakeSumOfCost(1);
                bool discount = (bool)discountCheck.IsChecked;
                string type = "Normal";
                if (discount)
                {
                    type = "Start relief";
                }
                FlatTax flatTax = new FlatTax();
                decimal incomeTaxAdvance = flatTax.Calculate(type, sumOfCost, sumOfTaking, monthValue);
                ScoreBlock.Text = incomeTaxAdvance.ToString();
                AmountBox.Text = incomeTaxAdvance.ToString();
                DecriptionBox.Text = "Zaliczka na podatek dochodowy";

                startAnimation(sumOfTaking, sumOfCost);
                decimal a = (incomeTaxAdvance / sumOfTaking) * 100m;
                AnswerText.Text = "Zaliczka stanowi " + (Math.Round(a, 0)) + " %";
            } else if (typeOfOperation == "FinancialSettlementApp.Logic.MonthlyBudgetPlan")
            {
                Decimal sumOfTaking = TakeSumOfTaking(1);
                Decimal sumOfCost = TakeSumOfCost(2);
                string type = "Normal";
                MonthlyBudgetPlan monthlyBudgetPlan = new MonthlyBudgetPlan();
                decimal incomeTaxAdvance = monthlyBudgetPlan.Calculate(type, sumOfCost, sumOfTaking, monthValue);
                ScoreBlock.Text = incomeTaxAdvance.ToString();

                startAnimation(sumOfTaking, sumOfCost);
                decimal a = (sumOfCost / sumOfTaking) * 100m;
                AnswerText.Text = "Wydatki stanowią " + (Math.Round(a,0)) +" %";
                HowScoreText.Text = "Oszczędności: [zł]";
            }
        }

        
        private void startAnimation(decimal first, decimal second)
        {
            double st = decimal.ToDouble(first);
            double sc = decimal.ToDouble(second);
            double one = 95.0 * (sc / st);
            double two = 188.0 * (sc / st);

            ((DoubleAnimationUsingKeyFrames)((Storyboard)Resources["StateStoryboard"]).Children[1]).KeyFrames[1].Value = one;
            ((DoubleAnimationUsingKeyFrames)((Storyboard)Resources["StateStoryboard"]).Children[2]).KeyFrames[1].Value = two;
            Dispatcher.Invoke(() => ((Storyboard)Resources["StateStoryboard"]).Begin());
        }

        private Decimal TakeSumOfTaking(int number)
        {
            using (FinancialSettlementAppBase context = new FinancialSettlementAppBase())
            {
                if (number == 1)
                {
                    List<Taking> takings = context.taking.Where(w => w.Month == monthValue).ToList();
                    Decimal sumOfAmount = 0m;
                    foreach (Taking t in takings)
                    {
                        sumOfAmount += t.Amount;
                    }
                    return sumOfAmount;
                }
            }
                    return 0;
        }

        private Decimal TakeSumOfCost(int number)
        {
            using (FinancialSettlementAppBase context = new FinancialSettlementAppBase())
            {
                if (number == 1)
                {
                    List<Cost> costs = context.cost.Where(w => w.Month == monthValue).Where(w => w.Status == "company").ToList();
                    Decimal sumOfCost = 0m;
                    foreach (Cost c in costs)
                    {
                        sumOfCost += c.Amount;
                    }
                    return sumOfCost;
                } else if (number == 2)
                {
                    List<Cost> costs = context.cost.Where(w => w.Month == monthValue).ToList();
                    Decimal sumOfCost = 0m;
                    foreach (Cost c in costs)
                    {
                        sumOfCost += c.Amount;
                    }
                    return sumOfCost;
                }
            }
            return 0;
        }

        private RelayCommand AddTakingCommand;
        //private void AddTakingsButton_Click(object sender, RoutedEventArgs e)
        private void AddTakings()
        {
            string takingText = AmountBox.Text;
            decimal takingValue = decimal.Parse(takingText);
            string whichmonth = monthValue;
            string descriptionText = DecriptionBox.Text;
            operationValue = "AddTakings";

            registerTaking(takingValue, whichmonth, descriptionText);
            //viewTaking(whichTakingView(1));

            //--------------
            startAnimation(1m, 1m);
            Task t1 = new Task(() => viewTaking(whichTakingView(1)));
            t1.Start();
            Task.WhenAll(t1).ContinueWith(t =>
            {
                
            }, TaskScheduler.FromCurrentSynchronizationContext());
            //--------------
        }

        private RelayCommand AddCostCommand;
       // private void AddCostButton_Click(object sender, RoutedEventArgs e)
        private void AddCost()
        {
            string costText = AmountBox.Text;
            decimal costValue = decimal.Parse(costText);
            string whichmonth = monthValue;
            string descriptionText = DecriptionBox.Text;
            string status = StatusCombo.Text;
            operationValue = "AddCost";

            registerCost(costValue, whichmonth, descriptionText, status);
            viewCost(whichCostView(1));
        }
        
        private List<Taking> whichTakingView(int number)
        {
            using (FinancialSettlementAppBase context = new FinancialSettlementAppBase())
            {
                if(number ==1)
                {
                    List<Taking> takings = context.taking.Where(w => w.Month == monthValue).ToList();
                    return takings;
                }
                return null;
            }
        }

        private List<Cost> whichCostView(int number)
        {
            using (FinancialSettlementAppBase context = new FinancialSettlementAppBase())
            {
                if (number == 1)
                {
                    List<Cost> cost = context.cost.Where(w => w.Month == monthValue).ToList();
                    return cost;
                }
                return null;
            }
        }

        private void viewTaking(List<Taking> list)
        {
            Task.Delay(2000).Wait();

            Dispatcher.Invoke(() =>
            {
                DisplayGrid.ItemsSource = list;
            });
        }

        private void viewCost(List<Cost> list)
        {
            DisplayGrid.ItemsSource = list;
        }

        private void calendarControl_CalendarMonthChanged(object sender, Common.Controls.Calendar.CalendarEventArgs e)
        {
            monthValue = e.Value;
        }

        private void registerTaking(decimal amount, string month, string description)
        {
            DateTime nowTime = DateTime.Now;

            using (FinancialSettlementAppBase context = new FinancialSettlementAppBase())
            {
                Taking newTaking = new Taking()
                {
                    Amount = amount,
                    Month = month,
                    Description = description,
                    Data = nowTime
                };
                context.taking.Add(newTaking);
                context.SaveChanges(); 
            }
        }

        private void registerCost(decimal amount, string month, string description, string status)
        {
            DateTime nowTime = DateTime.Now;

            using (FinancialSettlementAppBase context = new FinancialSettlementAppBase())
            {
                Cost newCost = new Cost()
                {
                    Amount = amount,
                    Month = month,
                    Description = description,
                    Data = nowTime,
                    Status = status
                };
                context.cost.Add(newCost);
                context.SaveChanges();
            }
        }

        private void registerTaxPrepayment(decimal amount, string month, string description)
        {
            DateTime nowTime = DateTime.Now;

            using (FinancialSettlementAppBase context = new FinancialSettlementAppBase())
            {
                TaxPrepayment newTaxPrepayment = new TaxPrepayment()
                {
                    Amount = amount,
                    Month = month,
                    Description = description,
                    Data = nowTime
                };
                context.taxPrepayment.Add(newTaxPrepayment);
                context.SaveChanges();
            }
        }

        
        private void DeleteLastButton_Click(object sender, RoutedEventArgs e)
        {
            using (FinancialSettlementAppBase context = new FinancialSettlementAppBase())

                if (operationValue == "AddTakings")
                {
                    bool oldValidateOnSaveEnabled = context.Configuration.ValidateOnSaveEnabled;

                    try
                    {
                        context.Configuration.ValidateOnSaveEnabled = false;

                        Taking takingToRemove = (Taking)DisplayGrid.SelectedItem;

                        context.Entry(takingToRemove).State = System.Data.Entity.EntityState.Deleted;
                        context.SaveChanges();
                    }
                    finally
                    {
                        context.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                    }
                    viewTaking(whichTakingView(1));
                }
                else if (operationValue == "AddCost")
                {
                    bool oldValidateOnSaveEnabled = context.Configuration.ValidateOnSaveEnabled;

                    try
                    {
                        context.Configuration.ValidateOnSaveEnabled = false;

                        Cost costToRemove = (Cost)DisplayGrid.SelectedItem;

                        context.Entry(costToRemove).State = System.Data.Entity.EntityState.Deleted;
                        context.SaveChanges();
                    }
                    finally
                    {
                        context.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                    }
                    viewCost(whichCostView(1));
                }
        }
    }
}
