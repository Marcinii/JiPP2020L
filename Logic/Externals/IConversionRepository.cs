using System.Linq;
using System.Threading.Tasks;
using Logic.Model;
using Logic.Model.Queries;

namespace Logic.Externals
{
    public interface IConversionRepository
    {
        Task Add(Conversion conversion);
        Task<QueryResult<Conversion>> ApplySortAsync(IQueryable<Conversion> queryable, ConversionQuery query);
    }
}
