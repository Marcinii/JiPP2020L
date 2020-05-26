namespace UnitConverter.Library.OperationUtil.OpException
{

    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="OperationException"/>,
    /// która jest rzucana w momencie, gdy próbujemy odwołać się do operacji,
    /// która nie istnieje w repozytorium
    /// </summary>
    /// <see cref="OperationException"/>
    public class OperationNotFoundException : OperationException
    {
        public OperationNotFoundException() : base("Operacja o podanych parametrach nie istnieje") {}
    }
}
