namespace UnitConverter.Library.TypeUtil.Void
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="IObject" />, który służy do wywołania odpowiednich operacji
    /// bez zwracania wyniku
    /// </summary>
    /// <param name="function">Pole przechowujące funckję, która ma się uruchommić</param>
    public class CustomVoid : IObject
    {
        private CustomVoidFunction function;

        public CustomVoid(CustomVoidFunction function)
        {
            this.function = function;
        }

        /// <summary>
        /// Metoda, która uruchamia funkcję
        /// </summary>
        public void run() => function();
    }
}
