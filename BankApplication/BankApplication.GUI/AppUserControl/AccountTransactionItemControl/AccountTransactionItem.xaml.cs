using BankApplication.Library.AccountUtil;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BankApplication.GUI.AppUserControl.AccountTransactionItemControl
{
    /// <summary>
    /// Interaction logic for AccountTransactionItem.xaml
    /// </summary>
    /// <param name="name">Nazwa transakcji</param>
    /// <param name="createdAt">Data wykonania trnsakcji</param>
    /// <param name="transactionType">Rodzaj wykonanej transakcji</param>
    /// <param name="price">Kwota, która została przelana na konto w trakcie transakcji</param>
    /// <param name="accountNumber">Konto, na które pieniądze zostały przelane</param>
    public partial class AccountTransactionItem : UserControl
    {
        public string name
        {
            get { return (string)GetValue(nameProperty); }
            set { SetValue(nameProperty, value); }
        }

        public static readonly DependencyProperty nameProperty =
            DependencyProperty.Register("name", typeof(string), typeof(AccountTransactionItem), new PropertyMetadata(""));


        public DateTime createdAt
        {
            get { return (DateTime)GetValue(createdAtProperty); }
            set { SetValue(createdAtProperty, value); }
        }

        public static readonly DependencyProperty createdAtProperty =
            DependencyProperty.Register("createdAt", typeof(DateTime), typeof(AccountTransactionItem), new PropertyMetadata(new DateTime()));




        public AccountTransactionType transactionType
        {
            get { return (AccountTransactionType)GetValue(transactionTypeProperty); }
            set { SetValue(transactionTypeProperty, value); }
        }

        public static readonly DependencyProperty transactionTypeProperty =
            DependencyProperty.Register("transactionType", typeof(AccountTransactionType), typeof(AccountTransactionItem), new PropertyMetadata(null));



        public decimal price
        {
            get { return (decimal)GetValue(priceProperty); }
            set { SetValue(priceProperty, value); }
        }

        public static readonly DependencyProperty priceProperty =
            DependencyProperty.Register("price", typeof(decimal), typeof(AccountTransactionItem), new PropertyMetadata(0.0M));




        public string accountNumber
        {
            get { return (string)GetValue(accountNumberProperty); }
            set { SetValue(accountNumberProperty, value); }
        }

        public static readonly DependencyProperty accountNumberProperty =
            DependencyProperty.Register("accountNumber", typeof(string), typeof(AccountTransactionItem), new PropertyMetadata(""));






        public AccountTransactionItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        public override void OnApplyTemplate()
        {   
            if(transactionType.id == 1)
            {
                this.transactionIconImage.Source = new BitmapImage(new Uri("../../img/right.png", UriKind.Relative));
                this.priceLabel.Foreground = Brushes.LightGreen;
                this.priceLabel.Content = "+" + this.priceLabel.Content + "zł";
            }
            else
            {
                this.transactionIconImage.Source = new BitmapImage(new Uri("../../img/left.png", UriKind.Relative));
                this.priceLabel.Foreground = Brushes.Red;
                this.priceLabel.Content = "-" + this.priceLabel.Content + "zł";
                this.accountNumberTextBlock.Visibility = Visibility.Collapsed;
            }
        }
    }
}
