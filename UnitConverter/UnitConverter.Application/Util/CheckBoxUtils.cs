using System.Windows.Controls;

namespace UnitConverter.Application.Util
{
    /// <summary>
    /// Klasa zawierająca zestaw metod do zarządzania kontrolką <see cref="CheckBox"/>
    /// </summary>
    /// <param name="checkBox">
    ///     Pole przechowujące referencję do kontrolki, którą będziemy zarządzać.
    /// </param>
    public class CheckBoxUtils
    {
        private CheckBox checkBox;



        public CheckBoxUtils(CheckBox checkBox)
        {
            this.checkBox = checkBox;
        }


        
        /// <summary>
        /// Metoda ta sprawdza, czy kontrolka jest zaznaczona
        /// </summary>
        /// <returns>
        ///     Zwraca true jeżeli jest ona zaznaczona.
        ///     W przeciwnym przypadku - false.
        /// </returns>
        public bool isChecked() => (bool) checkBox.IsChecked;



        /// <summary>
        /// Metoda ustawia stan zazznaczenia kontrolki zgodnie z wprowadzonym parametrem
        /// </summary>
        /// <param name="_checked">
        ///     Stan, na który chcey kontrolkę ustawić
        /// </param>
        public void setChecked(bool _checked) => checkBox.IsChecked = _checked;



        /// <summary>
        /// Metoda, która zmienia stan kontrolki na zmianę (raz zaznacza, raz odznacza)
        /// </summary>
        public void toggle() => checkBox.IsChecked = !checkBox.IsChecked;



        /// <summary>
        /// Metoda sprawdzająca, czy kontrolka jest aktywna
        /// </summary>
        /// <returns>
        ///     Zwraca true, jeżeli kontrolka jest aktywna.
        ///     Zwraca false w przeciwnym przypadku.
        /// </returns>
        public bool isEnabled() => checkBox.IsEnabled;
    }
}
