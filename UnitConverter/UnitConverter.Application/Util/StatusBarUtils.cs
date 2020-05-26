using System.Collections.Generic;
using System.Windows.Controls;

namespace UnitConverter.Application.Util
{
    /// <summary>
    /// Klasa posiadająca zestaw metod, służące do kontrolowania paskiem stanu.
    /// </summary>
    /// <see cref="MainWindow"/>
    class StatusBarUtils
    {
        private Dictionary<Control, string> statusBarMessages;
        private Label label;

        public StatusBarUtils(Label label)
        {
            statusBarMessages = new Dictionary<Control, string>();
            this.label = label;
        }




        /// <summary>
        /// Metoda dodająca wiadomość, która będzie wyswietlana w pasku stanu w moencie, gdy najedziemy na odpowiednią kontrolkę
        /// przekazaną w parametrze {Control}
        /// </summary>
        /// <param name="control">
        ///     Kontrolka, do której chcemy dodać informacje na pasku stanu w momencie, gdy nad nią znajdzie się kursor
        /// </param>
        /// <param name="message">Wiadomość, która się wyświetli w pasku stanu</param>
        public void addStatusBarText(Control control, string message)
        {
            statusBarMessages.Add(control, message);
        }



        /// <summary>
        /// Metoda, która modyfikuje tekst w pasku stanu. Na podstawie wprowadzonego argumentu {control} wybierany jest odpowiedni tekst z listy <see cref="statusBarMessages"/>
        /// </summary>
        /// <param name="control">Dowolna kontrolka w aplikacji</param>
        /// <see cref="MainWindow"/>
        public void setStatusBarText(Control control)
        {
            label.Content = statusBarMessages.ContainsKey(control)
                            ? statusBarMessages[control]
                            : "";
        }
    }
}
