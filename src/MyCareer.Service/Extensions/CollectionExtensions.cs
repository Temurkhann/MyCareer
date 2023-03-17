using System.Linq;
using MyCareer.Domain.Configurations;

namespace MyCareer.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
        {
            return @params.PageIndex > 0 && @params.PageSize >= 0
                ? source.Take(((@params.PageIndex - 1) * @params.PageSize)..@params.PageSize)
                : source;
        }
    }
}
