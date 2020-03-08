using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace UnitConverterApp.Util
{
    class ListBoxUtils<T> : ISelectorUtils<ListBox, T>
    {
        public void initialize(ListBox selector, List<T> list)
        {
            list.ForEach(item =>
            {
                ListBoxItem listBoxItem = new ListBoxItem();

                listBoxItem.Content = item;
                listBoxItem.Cursor = Cursors.Hand;

                selector.Items.Add(listBoxItem);
            });
        }
    }
}
