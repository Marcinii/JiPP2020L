using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;

namespace UnitConverterApp.Util
{
    /// <summary>
    /// Klasa implementująca interface ISelectorUtils. Służy do zarządzania listą
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref="ISelectorUtils{T, I}"/>
    class ListBoxUtils<T> : ISelectorUtils<ListBox, T>
    {
        public void initialize(ListBox selector, List<T> list)
        {
            selector.ItemsSource = list.Select(item =>
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = item;
                listBoxItem.Cursor = Cursors.Hand;
                return listBoxItem;
            }).ToList();
        }
    }
}
