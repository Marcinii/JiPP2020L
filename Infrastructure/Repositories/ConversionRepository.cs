using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Externals;
using Logic.Model;
using Logic.Model.Enums;
using Logic.Model.Queries;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ConversionRepository : IConversionRepository
    {
        private readonly ConversionContext _conversionContext;
        public ConversionRepository(ConversionContext conversionContext)
        {
            _conversionContext = conversionContext;
        }

        public async Task Add(Conversion conversion)
        {
            await _conversionContext.Conversions.AddAsync(conversion);
        }

        public async Task<QueryResult<Conversion>> ApplySortAsync(IQueryable<Conversion> queryable, ConversionQuery query)
        {
            var totalItems = await queryable.CountAsync();

            if (query.SortMethod == ESortType.Asc)
                queryable = queryable.OrderBy(d => d.ConverterKind.Name);
            else if (query.SortMethod == ESortType.Desc)
                queryable = queryable.OrderByDescending(d => d.ConverterKind.Name);
                    
                
            List<Conversion> conversions = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                .Take(query.ItemsPerPage)
                .ToListAsync();

            return new QueryResult<Conversion>
            {
                Items = conversions,
                TotalItems = totalItems
            };
        }
    }
}
