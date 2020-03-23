using UnitConverter.Library.TypeUtil.TypeException;
using UnitConverter.Library.Validator;

namespace UnitConverter.Library.TypeUtil
{
    public class CustomTypeValueParser
    {
        private ICustomType customObject;
        private CustomTypeException exception;
        private CustomTypeValidator validator;

        public CustomTypeValueParser(ICustomType customObject, CustomTypeValidator validator, CustomTypeException exception)
        {
            this.customObject = customObject;
            this.validator = validator;
            this.exception = exception;
        }


        public ICustomType parse(string value)
        {
            if(!validator.validate(value))
                throw exception;

            return customObject.fromString(value);
        }
    }
}
