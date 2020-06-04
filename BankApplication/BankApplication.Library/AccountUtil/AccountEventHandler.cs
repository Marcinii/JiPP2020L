namespace BankApplication.Library.AccountUtil.Event
{
    /// <summary>
    /// Delegat, który posłuży do utworzenia nowych zdarzeń na koncie bankowym.
    /// </summary>
    /// <param name="account">Wynikowe konto bankowe</param>
    /// <see cref="Account"/>
    public delegate void AccountEventHandler(Account account);
}
