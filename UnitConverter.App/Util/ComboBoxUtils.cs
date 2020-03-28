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
    public class ComboBoxUtils<T> : ISelectorUtils<ComboBox, T>
    {
        
        public ComboBoxUtils(ComboBox selector) : base(selector) {}

        public override void initialize(List<T> list)
        {
            selector.ItemsSource = list.Select(item => new ComboBoxItem
            {
                Content = item,
                Cursor = Cursors.Hand
            }).ToList();
        }


        /// <summary>
        /// Metoda zwracająca zaznaczoną wartość jako typ, który jest przechowywany w liście rozwijalnej
        /// </summary>
        /// <returns></returns>
        public T getSelectedContent() => (T)((ComboBoxItem)selector.SelectedItem).Content;
    }
}
