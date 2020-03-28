namespace UnitConverter.Library.OperationUtil.OpException
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="OperationException"/>,
    /// która jest rzucana w momencie, gdy próbujemy dodać nową operację, gdzie jej
    /// numer już istnieje w repozytorium
    /// </summary>
    /// <see cref="OperationException"/>
    class OperationExistsException : OperationException
    {
        public OperationExistsException() : base("Operacja o podanym numerze już istnieje") {}
    }
}
