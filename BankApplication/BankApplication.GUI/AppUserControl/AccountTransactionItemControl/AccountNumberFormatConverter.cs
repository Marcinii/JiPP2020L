using BankApplication.Library.AccountUtil;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BankApplication.GUI.AppUserControl.AccountTransactionItemControl
{
    /// <summary>
    /// Klasa, implementująca interfejs <see cref="IValueConverter"/>, która jest odpowiedzialna za konwersję wyświetlanego
    /// numeru konta bankowego w aplikacji. Ma ona za zadanie podzielić długi ciąg liczbowy na mniejsze segmenty za pomocą spacji.
    /// Dzieki czemu numer konta bankowego jest łatwiejszy do odczytania
    /// </summary>
    public class AccountNumberFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AccountNumberUtils.toFormattedAccountNumber(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
