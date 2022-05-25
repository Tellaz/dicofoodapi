using System.Collections.Generic;

namespace DicoFoodAPI.Data.Converter.Interface
{
    public interface IParser<O,D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
