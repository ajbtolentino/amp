using System.Linq.Expressions;
using AMP.Infrastructure.Enums;
using AMP.Infrastructure.Pagination;
using AMP.Infrastructure.Sorting;

namespace AMP.Infrastructure.Extensions;

public static class CollectionExtensions
{
    public static IQueryable<T> ApplySorting<T>(
        this IQueryable<T> query,
        SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortField))
            return query;

        var parameter = Expression.Parameter(typeof(T), "x");
        Expression property = parameter;

        foreach (var member in sortingParameters.SortField.Split('.')) property = Expression.Property(property, member);

        var keySelector = Expression.Lambda(property, parameter);

        var methodName = sortingParameters.SortDirection == SortDirection.Descending
            ? "OrderByDescending"
            : "OrderBy";

        var method = typeof(Queryable).GetMethods()
            .First(m => m.Name == methodName && m.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), property.Type);

        return (IQueryable<T>)method.Invoke(null, new object[] { query, keySelector })!;
    }

    public static PagedResult<T> ApplyPagination<T>(
        this IQueryable<T> query,
        int pageNumber,
        int pageSize)
    {
        var collection = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return new PagedResult<T>
        {
            PageNumber = pageNumber,
            Result = collection,
            TotalRecords = query.Count()
        };
    }
}