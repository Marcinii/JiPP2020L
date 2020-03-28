using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UnitConverter.App.AppUserControl.ClockControl
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="IValueConverter" />, która słuzy do konwertowania wartości marginesu.
    /// Wprowadzona wartość zmiennoprzecinkowa jest konwertowana na klasę <see cref="Thickness"/>, któa zwraca margines
    /// w postaci: <-- wprowadzona wartość -->,0,0,0
    /// 
    /// Dla przykładu:
    /// dla wartości 10 => zwrócona wartość będzie wynosiła 10,0,0,0
    /// </summary>
    class RectangleMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => 
            new Thickness(System.Convert.ToDouble(value), 0, 0, 0);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
