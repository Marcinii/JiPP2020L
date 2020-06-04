namespace BankApplication.GUI.AppUserControl.FormInputControl
{
    /// <summary>
    /// Enumeracja reprezentująca rodzaj kontrolki
    /// </summary>
    public enum FormInputType
    {
        /// <summary>
        /// Kontrolka będzie zwykłym polem tekstowym
        /// </summary>
        TEXT,

        /// <summary>
        /// Kontrolka będzie polem do wprowadzania hasła
        /// </summary>
        PASSWORD,
        
        /// <summary>
        /// Kontrolka umożliwi wybór daty
        /// </summary>
        DATE,
        
        /// <summary>
        /// Kontrolka będzie pole tekstowym przechowującą wartości numeryczne
        /// </summary>
        NUMBER
    }
}
