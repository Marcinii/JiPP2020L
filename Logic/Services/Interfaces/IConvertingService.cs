namespace Logic.Services.Interfaces
{
    public interface IConvertingService
    {
        float ConvertFromCelsiusToFahrenheit(float cTemp);
        float ConvertFromFahrenheitToCelsius(float fTemp);
        float ConvertFromMilesToKilometers(float miles);
        float ConvertFromKilometersToMiles(float km);
        float ConvertFromKilogramsToPounds(float kg);
        float ConvertFromPoundsToKilograms(float lb);
        float ConvertFromMetersToKilometers(float m);
        float ConvertFromKilometersToMeters(float km);
    }
}
