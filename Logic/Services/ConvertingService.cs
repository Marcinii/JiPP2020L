using Logic.Services.Interfaces;

namespace Logic.Services
{
    public class ConvertingService : IConvertingService
    {
        public float ConvertFromCelsiusToFahrenheit(float cTemp)
            => (cTemp * 1.8f) + 32f;

        public float ConvertFromFahrenheitToCelsius(float fTemp)
            => (fTemp - 32f) / 1.8f;

        public float ConvertFromMilesToKilometers(float miles)
            => miles / 0.62137f;

        public float ConvertFromKilometersToMiles(float km)
            => km * 0.62137f;

        public float ConvertFromKilogramsToPounds(float kg)
            => kg * 2.2046f;

        public float ConvertFromPoundsToKilograms(float lb)
            => lb / 2.2046f;

        public float ConvertFromMetersToKilometers(float m)
            => m * 0.001f;

        public float ConvertFromKilometersToMeters(float km)
            => km * 1000;
    }
}