namespace CalcLogic
{
    public class CSubstractor : IOperation
    {
        public string Name => "Substractor";

        public CSubstractor()
        {
        }

        public double Execute(double x, double y)
        {
            return x - y;
        }
    }
}
