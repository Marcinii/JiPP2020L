using UnitConverter.Library.TypeUtil.TypeException;
using UnitConverter.Library.Validator;

namespace UnitConverter.Library.TypeUtil
{
    public abstract class CustomObject<T> : ICustomType
    {
        protected abstract string validationRegex { get; }
        protected CustomTypeValueParser typeParser { get; }
        protected CustomTypeValidator validator { get; }
        protected abstract CustomTypeException exception { get; }
        internal T value { get; set; }


        protected CustomObject(T value)
        {
            this.value = value;
            this.validator = new CustomTypeValidator(validationRegex);
            this.typeParser = new CustomTypeValueParser(this, validator, exception);
        }


        public override string ToString() => $"{value}";
        public ICustomType fromString(string input)
        {
            if(!validator.validate(input)) throw exception;

            this.value = this.parseValue(input);
            return this;
        }

        protected abstract T parseValue(string input);
    }
}
