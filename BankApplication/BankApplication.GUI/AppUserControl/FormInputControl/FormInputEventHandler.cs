namespace BankApplication.GUI.AppUserControl.FormInputControl
{
    /// <summary>
    /// Delegat odpowiedzialny za przechowywanie instancji metód, które będą się wywoływały w
    /// momencie dokonywania zmiany wartości kontrolki
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    /// <see cref="FormInputEventArgs"/>
    public delegate void FormInputEventHandler(object sender, FormInputEventArgs args);
}
