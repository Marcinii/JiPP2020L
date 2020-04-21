using UnitConverter.Library.TypeUtil.Number;
using UnitConverter.Terminal.Style;

namespace UnitConverter.Terminal.RatingUtil
{
    /// <summary>
    /// Klasa reprezentująca model danych widżetu do oceniania
    /// </summary>
    /// <param name="value">Aktualna wartość oceny użytkownika</param>
    /// <param name="maxValue">Maksymalna wartość oceny</param>
    /// <param name="padding">Odstęp między wyświetlaną gwiazdką w komórce a obramowaniem</param>
    /// <param name="borderStyle">Styl obramowania</param>
    /// <see cref="CustomInteger"/>
    /// <see cref="BorderStyle"/>
    public class RatingWidget
    {
        public CustomInteger value { get; private set; } = 1;
        public CustomInteger maxValue { get; private set; } = 5;
        public CustomInteger padding { get; set; } = 0;
        public BorderStyle borderStyle { get; private set; } = BorderStyle.DOUBLE_LINE;

        
        public RatingWidget() { }

        public RatingWidget(int value, int maxValue = 5)
        {
            this.value = value;
            this.maxValue = maxValue;
        }



        /// <summary>
        /// Metoda, która zwiększa wartość oceny. Wartość przestaje być zwiększana,
        /// gdy osiągnie wartość maksymalną
        /// </summary>
        public void increaseValue()
        {
            this.value++;
            if (this.value > this.maxValue)
                this.value = this.maxValue;
        }



        /// <summary>
        /// Metoda, która zmniejsza wartość oceny. Wartość przestaje być zmniejszana,
        /// gdy osiągnie wartość 1
        /// </summary>
        public void decreaseValue()
        {
            this.value--;
            if (this.value < 1)
                this.value = 1;
        }
    }
}
