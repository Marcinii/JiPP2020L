﻿using System.Windows.Controls;
using System.Windows.Media;

namespace UnitConverter.Application.Util
{

    /// <summary>
    /// Klasa zawierająca zestaw metód służących do zarządzania kontrolką <see cref=TextBox"/>
    /// <param name="textBox">
    ///     Pole tekstowe do zarządzania
    /// </param>
    /// <param name="valid">
    ///     Wartość logiczna, która przechowuje informacje odnośnie tego, czy wartość wprowadzona w pole tekstowe
    ///     jest prawidłowa
    /// </param>
    /// </summary>
    public class TextBoxUtils
    {
        public TextBox textBox { get; private set; }
        public bool valid { get; private set; }


        public TextBoxUtils(TextBox textBox)
        {
            this.textBox = textBox;
        }


        /// <summary>
        /// Metoda ustawia wartość <see cref="valid" /> na fałsz, która informuje o tym, że wprowadzona
        /// wartość w pole tekstowe jest nieprawidłowe. Dodatkowo zmienia kolor tła na czerwone
        /// </summary>
        public void setToInvalid()
        {
            valid = false;
            textBox.Background = Brushes.Red;
        }



        /// <summary>
        /// Metoda ustawia wartość <see cref="valid" /> na fałsz, która informuje o tym, że wprowadzona
        /// wartość w pole tekstowe jest prawidłowe. Dodatkowo zmienia kolor tła na białe
        /// </summary>
        public void setToValid()
        {
            valid = true;
            textBox.Background = Brushes.White;
        }



        /// <summary>
        /// Metoda, która sprawdza, czy wartość pola tekstowego nie jest pusta
        /// </summary>
        /// <returns>
        ///     Zwraca true jeżeli pole tektowe ma wprowadzoną wartość,
        ///     w przeciwnym przypadku false
        /// </returns>
        public bool isNullOrEmpty() => textBox.Text == null || textBox.Text == "";
    }
}