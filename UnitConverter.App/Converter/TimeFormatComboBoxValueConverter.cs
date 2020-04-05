using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.App.Converter
{
    /// <summary>
    /// Klasa, która posłuży do konwersji enumeracji <see cref="Custom12HTimeType"/> na ciąg wyrazów,
    /// który posłuży do wyświetlenia opcji w liście rozwijalnej
    /// </summary>
    /// <see cref="Custom12HTimeType"/>
    public class TimeFormatComboBoxValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = typeof(Custom12HTimeType);
            var name = Enum.GetName(type, value);
            FieldInfo fi = type.GetField(name);
            var descriptionAttrib = (DescriptionAttribute)
                Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));

            return descriptionAttrib.Description;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
