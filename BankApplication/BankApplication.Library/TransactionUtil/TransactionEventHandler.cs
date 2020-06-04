using BankApplication.Library.AccountUtil;

namespace BankApplication.Library.TransactionUtil
{
    /// <summary>
    /// Delegat służący do wywoływania zdarzeń związanych z transakcjami
    /// </summary>
    /// <param name="transaction">Wynikowa transakcja</param>
    /// <see cref="AccountTransaction"/>
    public delegate void TransactionEventHandler(AccountTransaction transaction);
}
