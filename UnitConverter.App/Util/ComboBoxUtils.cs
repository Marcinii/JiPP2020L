using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace UnitConverterApp.Util
{
    class ComboBoxUtils<T> : ISelectorUtils<ComboBox, T>
    {

        public void initialize(ComboBox selector, List<T> list) => list.ForEach(item => {
            ComboBoxItem comboBoxItem = new ComboBoxItem();

            comboBoxItem.Content = item;
            comboBoxItem.Cursor = Cursors.Hand;

            selector.Items.Add(comboBoxItem);
        });
    }
}
