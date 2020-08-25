namespace CalcLogic
{
    public class CMultiplier : IOperation
    {
        public string Name => "Multiplier";

        public CMultiplier()
        {
        }

        public double Execute(double x, double y)
        {
            return x * y;
        }
    }
}
