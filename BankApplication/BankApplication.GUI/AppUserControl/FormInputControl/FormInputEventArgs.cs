using System;

namespace BankApplication.GUI.AppUserControl.FormInputControl
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="EventArgs"/>. Ma ona za zadanie przechowywać wartość kontrolki po 
    /// wywołaniu zdarzenia nasłuchującego zmiany wartości kontrolki
    /// </summary>
    /// <param name="value">Wartość wprowadzona w kontrolkę</param>
    public class FormInputEventArgs : EventArgs
    {
        public string value { get; set; }

        public FormInputEventArgs(string value)
        {
            this.value = value;
        }
    }
}
