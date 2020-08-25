namespace CalcLogic
{
    public class CAdder : IOperation
    {
        public string Name => "Adder";

        public CAdder()
        {
        }

        public double Execute(double x, double y)
        {
            return x + y;
        }
    }
}
