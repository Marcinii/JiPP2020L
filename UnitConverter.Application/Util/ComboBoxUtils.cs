using System.Collections.Generic;
using System.Windows.Controls;

namespace UnitConverter.Application.Util
{
    /// <summary>
    /// Klasa implementująca interface ISelectorUtils. Służy do zarządzania listą rozwijalną
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref="ISelectorUtils{T, I}"/>
    public class ComboBoxUtils<T> : ISelectorUtils<ComboBox, T>
    {
        public ComboBoxUtils(ComboBox selector) : base(selector) { }

        public override void initialize(List<T> list) => selector.ItemsSource = list;
        public override T getSelectedContent() => (T)selector.SelectedItem;
    }
}
