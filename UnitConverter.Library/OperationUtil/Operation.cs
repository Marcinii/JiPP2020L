namespace UnitConverter.Library.OperationUtil
{
    public abstract class Operation
    {
        public int id { get; }
        public string name { get; }

        protected Operation(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
