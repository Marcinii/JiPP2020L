using System;
using System.Globalization;
using System.Windows.Data;

namespace UnitConverter.App.AppUserControl.ClockControl
{

    /// <summary>
    /// Klasa implementująca interfejs <see cref="IValueConverter" />, która słuzy do konwertowania wprowadzonych stopnii.
    /// Jest to implementacja wprowadzająca obejście na niedziałającą transformację wzglęgem obrotu
    /// </summary>
    public class AngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
