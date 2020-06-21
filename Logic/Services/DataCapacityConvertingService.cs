using Logic.Services.Interfaces;

namespace Logic.Services
{
    public class DataCapacityConvertingService : IDataCapacityConvertingService
    {
        private float _bits;
        private float _kiloBits;
        private float _megaBits;
        private float _bytes;
        private float _kiloBytes;
        private float _megaBytes;

        public float Bites
        {
            get => _bits;
            set
            {
                _bits = value;
                _kiloBits = value / 1000;
                _megaBits = value / 1000000;
                _bytes = value * 0.125f;
                _kiloBytes = value * 0.000125f;
                _megaBytes = value * 0.000000125f;
            }
        }

        public float KiloBits
        {
            get => _kiloBits;
            set => _bits = value * 1000;
        }

        public float MegaBits
        {
            get => _megaBits;
            set => Bites = value * 1000000;
        }

        public float Bytes
        {
            get => _bytes;
            set => Bites = value * 8;
        }

        public float KiloBytes
        {
            get => _kiloBytes;
            set => Bites = value * 8000;
        }

        public float MegaBytes
        {
            get => _megaBytes;
            set => Bites = value * 8000000;
        }
    }
}
