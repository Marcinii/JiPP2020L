namespace UnitConverter.Library.OperationUtil.OpException
{

    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="OperationException"/>,
    /// która jest rzutowana w momencie, gdy próbujemy odwłać się do jednostki, która nie istnieje
    /// </summary>
    /// <see cref="OperationException"/>
    class UnitOperationNotFoundException : OperationException
    {
        public UnitOperationNotFoundException() : base("Nie można odnaleść jednostki o podanym numerze") {}
    }
}
