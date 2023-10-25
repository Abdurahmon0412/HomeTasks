using FileExplorerApplication_Task.Common.Models.Filtering;

namespace FileExplorerApplication_Task.Common.Querying.Extensions;

public static class LinqExtensions
{
    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source, FilterPagination paginationOptions)
    {
        // var pageSize = paginationOptions.DynamicPageSize;
        // return source.Skip((int)((paginationOptions.PageToken - 1) * pageSize)).Take((int)pageSize);

        return source.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize)).Take((int)paginationOptions.PageSize);
    }

    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, FilterPagination paginationOptions)
    {
        // var pageSize = paginationOptions.DynamicPageSize;
        // return source.Skip((int)((paginationOptions.PageToken - 1) * pageSize)).Take((int)pageSize);

        return source.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize)).Take((int)paginationOptions.PageSize);
    }
}