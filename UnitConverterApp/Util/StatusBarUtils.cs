using System.Collections.Generic;
using System.Windows.Controls;

namespace UnitConverterApp.Util
{
    /// <summary>
    /// Klasa posiadająca zestaw metod, służące do kontrolowania paskiem stanu.
    /// </summary>
    /// <see cref="MainWindow"/>
    class StatusBarUtils
    {
        private Dictionary<Control, string> statusBarMessages;
        private MainWindow mainWindow;

        public StatusBarUtils(MainWindow mainWindow)
        {
            this.statusBarMessages = new Dictionary<Control, string>();
            this.mainWindow = mainWindow;
        }



        /// <summary>
        /// Metoda inicjalizuje zestaw wiadomości dla odpowiednich kontrolek w oknie <see cref="MainWindow"/>
        /// </summary>
        public void initStatusBarHelp()
        {
            this.statusBarMessages.Add(this.mainWindow.measurementUnitComboBox, "Wprowadż wartość do skonwertowania");
            this.statusBarMessages.Add(this.mainWindow.providedValueTextBox, "Wprowadź wartość do przekonwertowania");
            this.statusBarMessages.Add(this.mainWindow.fromUnitListBox, "Wybierz jednostkę, z której chcesz skonwertować liczbę");
            this.statusBarMessages.Add(this.mainWindow.toUnitListBox, "Wybierz jednostkę, na którą chcesz skonwertować liczbę");
            this.statusBarMessages.Add(this.mainWindow.swapButton, "Zamień jednosti miejscami");
            this.statusBarMessages.Add(this.mainWindow.commaDigitCountComboBox, "Wybierz liczbę widocznych cyfer po przecinku");
        }



        /// <summary>
        /// Metoda, która modyfikuje tekst w pasku stanu. Na podstawie wprowadzonego argumentu {control} wybierany jest odpowiedni tekst z listy <see cref="statusBarMessages"/>
        /// </summary>
        /// <param name="control">Dowolna kontrolka w aplikacji</param>
        /// <see cref="MainWindow"/>
        public void setStatusBarText(Control control)
        {
            if(this.statusBarMessages.ContainsKey(control))
            {
                mainWindow.helperTextStatusBar.Content = this.statusBarMessages[control];
            }
            else
            {
                mainWindow.helperTextStatusBar.Content = "";
            }
        }
    }
}
