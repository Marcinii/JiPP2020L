using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

namespace UnitConverterApp.Util
{
    /// <summary>
    /// Klasa implementująca interface ISelectorUtils. Służy do zarządzania listą rozwijalną
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref="ISelectorUtils{T, I}"/>
    class ComboBoxUtils<T> : ISelectorUtils<ComboBox, T>
    {
        public void initialize(ComboBox selector, List<T> list)
        {
            selector.ItemsSource = list.Select(item =>
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();

                comboBoxItem.Content = item;
                comboBoxItem.Cursor = Cursors.Hand;

                return comboBoxItem;
            }).ToList();
        }
    }
}
