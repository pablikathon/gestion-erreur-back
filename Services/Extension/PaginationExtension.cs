using Services.Models.Common;
using System.Linq.Expressions;
using System.Reflection;

public static class PaginationExtension
{
    public static IQueryable<T> Pagination<T>(this IQueryable<T> query, PaginationParameters paginationParameters)
        where T : class
    {
        if (paginationParameters.PageNumber.GetHashCode() != 0)
        {
            query = query
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
        }

        return query;
    }

    public static IQueryable<T> DateSearchQuery<T>(this IQueryable<T> query, DateParameters DateParam)
        where T : DateEntity
    {
        switch (DateParam.DateField)
        {
            case nameof(DateEntity.CreatedAt):
                query = query.Where(a =>
                    a.CreatedAt >= DateParam.StartDate && a.CreatedAt <= DateParam.EndDate);
                break;
            case nameof(DateEntity.UpdatedAt):
                query = query.Where(a =>
                    a.UpdatedAt >= DateParam.StartDate && a.UpdatedAt <= DateParam.EndDate);
                break;
            default:
                throw new ArgumentException("Bad column date name");
        }

        return query;
    }

    public static IQueryable<T> SortBy<T>(this IQueryable<T> source, SortParameters sort) where T : class
    {
        if (string.IsNullOrEmpty(sort.SortBy))
        {
            return source;
        }

        var entityType = typeof(T);
        var properties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // On ne garde que `string`, `int` ou `DateTime`
        var property = properties.FirstOrDefault(p =>
            string.Equals(p.Name, sort.SortBy, StringComparison.OrdinalIgnoreCase) &&
            (p.PropertyType == typeof(string) || p.PropertyType == typeof(int) || p.PropertyType == typeof(DateTime)));

        if (property == null)
        {
            throw new ArgumentException(
                $"La propriété '{sort.SortBy}' n'existe pas ou n'est pas triable sur le type '{entityType.Name}'.");
        }

        // Créer un paramètre pour l'expression lambda (exemple: x => x.Property)
        var parameter = Expression.Parameter(entityType, "x");

        // Créer l'expression pour accéder à la propriété (exemple: x.Property)
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);
        var methodName = sort.Ascending ? "OrderBy" : "OrderByDescending";
        var method = typeof(Queryable).GetMethods()
            .First(m => m.Name == methodName && m.GetParameters().Length == 2);

        // Rendre la méthode générique pour le type `T` et le type de la propriété
        var genericMethod = method.MakeGenericMethod(entityType, property.PropertyType);
        return (IQueryable<T>)genericMethod.Invoke(null, new object[] { source, orderByExpression });
    }


    public static IQueryable<T> TextSearch<T>(this IQueryable<T> query,
        SearchParameters searchParameters
    ) where T : class
    {
        if (!searchParameters.SearchColumn.IsNullOrWithSpaceOrEmpty() &&
            !searchParameters.SearchTerm.IsNullOrWithSpaceOrEmpty())
        {
            var entityType = typeof(T);
            var properties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // On ne garde que les propriétés de type `string`
            var property = properties.FirstOrDefault(p =>
                string.Equals(p.Name, searchParameters.SearchColumn, StringComparison.OrdinalIgnoreCase) &&
                p.PropertyType == typeof(string));

            if (property == null)
            {
                throw new ArgumentException(
                    $"La propriété '{searchParameters.SearchColumn}' n'existe pas ou n'est pas triable sur le type '{entityType.Name}'.");
            }

            var parameter = Expression.Parameter(entityType, "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            if (toLowerMethod != null && containsMethod != null)
            {
                var toLowerExpression = Expression.Call(propertyAccess, toLowerMethod);
                var searchExpression = Expression.Constant(searchParameters.SearchTerm.ToLower());
                var containsExpression = Expression.Call(toLowerExpression, containsMethod, searchExpression);

                // Crée l'expression lambda : x => x.Property.ToLower().Contains("searchTerm")
                var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);
                return query.Where(lambda);
            }
        }

        return query;
    }
}