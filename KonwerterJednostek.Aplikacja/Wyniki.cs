namespace KonwerterJednostek.Aplikacja
{
    public partial class Wyniki
    {
        public int id { get; set; }
        public string konwerter { get; set; }
        public System.DateTime data { get; set; }
        public double wartoscWejsciowa { get; set; }
        public string jednostkaWejsciowa { get; set; }
        public double wartoscWyjsciowa { get; set; }
        public string jednostkaWyjsciowa { get; set; }
    }
}
