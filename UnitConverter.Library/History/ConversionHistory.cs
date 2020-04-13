using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitConverter.Library.History
{
    /// <summary>
    /// Klasa, która reprezentuje model danych tabeli "conversion_history"
    /// </summary>
    /// <param name="id">Numer konwersji</param>
    /// <param name="converterName">Nazwa konwertera</param>
    /// <param name="fromConversionUnit">Jednostka, z której wykonywano konwersję</param>
    /// <param name="toConversionUnit">Jednostka, na którą wykonywano konwersję</param>
    /// <param name="input">
    ///     Wprowadzona wartość wejściowa. Powodem, dla którego typ tego pola jest string jest to,
    ///     iż mamy tutaj do czynienia z wieloma typami danych wprowadzanych wartości.
    ///     Mota tutaj oczywiscie o liczbach zmiennoprzecinkowych i godzinie
    /// </param>
    /// <param name="output">Skonwertowana wartośc wyjściowa</param>
    /// <param name="createdAt">Data wykonania konwersji</param>
    [Table("conversion_history")]
    public class ConversionHistory
    {
        public int id { get; set; }

        [Column("converter_name")]
        public string converterName { get; set; }

        [Column("from_conversion_unit")]
        public string fromConversionUnit { get; set; }

        [Column("to_conversion_unit")]
        public string toConversionUnit { get; set; }

        public string input { get; set; }
        public string output { get; set; }

        [Column("created_at")]
        public DateTime createdAt { get; set; }


        public ConversionHistory() { }

        public ConversionHistory(string converterName, string fromConversionUnit, string toConversionUnit, string input, string output, DateTime createdAt)
        {
            this.converterName = converterName;
            this.fromConversionUnit = fromConversionUnit;
            this.toConversionUnit = toConversionUnit;
            this.input = input;
            this.output = output;
            this.createdAt = createdAt;
        }
    }
}
