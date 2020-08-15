namespace UnitConverter.Desktop
{
    public partial class Statistic
    {
        public int Id { get; set; }
        public string Converter { get; set; }
        public System.DateTime Date { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
        public double OutputValue { get; set; }
        public string OutputUnit { get; set; }
    }
}
