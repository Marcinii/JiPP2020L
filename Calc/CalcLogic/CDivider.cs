namespace CalcLogic
{
    public class CDivider : IOperation
    {
        public string Name => "Divider";

        public CDivider()
        {
        }

        public double Execute(double x, double y)
        {
            return x / y;
        }
    }
}
