using System.Collections.Generic;

namespace UnitConverterApp.Util
{
    interface ISelectorUtils<T, I>
    {
        void initialize(T selector, List<I> list);
    }
}
