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
    public class ListBoxUtils<T> : ISelectorUtils<ListBox, T>
    {
        public ListBoxUtils(ListBox selector) : base(selector) {}



        public override void initialize(List<T> list)
        {
            selector.ItemsSource = list.Select(item => new ListBoxItem
            {
                Content = item,
                Cursor = Cursors.Hand
            }).ToList();
        }
    }
}
