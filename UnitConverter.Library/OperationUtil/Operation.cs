using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.OperationUtil
{

    /// <summary>
    /// Klasa abstrakcyjna reprezentującą zesta pól do wykonywania operacji
    /// 
    /// <param name="id">Numer operacji</param>
    /// <param name="nazwa">Nazwa wykonywanej operacji</param>
    /// </summary>
    /// <see cref="CustomInteger"/>
    public abstract class Operation
    {
        public CustomInteger id { get; }
        public string name { get; }

        protected Operation(CustomInteger id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
